using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelCalifornia
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void BGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                // Nombre de tu base de datos
                string databaseName = "Hotel1";

                // Sugerir una carpeta raíz que SQL Server pueda acceder
                string defaultBackupPath = @"C:\SQLBackups";

                // Mostrar mensaje informativo al usuario
                DialogResult result = MessageBox.Show(
                    "SQL Server necesita permisos especiales para escribir backups.\n\n" +
                    $"Se recomienda usar la carpeta: {defaultBackupPath}\n" +
                    "(Se creará automáticamente si no existe)\n\n" +
                    "¿Desea usar esta ubicación?\n\n" +
                    "Presione 'No' para elegir otra carpeta (puede requerir configuración manual de permisos)",
                    "Seleccionar ubicación de backup",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Cancel)
                    return;

                string backupFolder;

                if (result == DialogResult.Yes)
                {
                    backupFolder = defaultBackupPath;

                    // Intentar crear la carpeta si no existe
                    try
                    {
                        if (!Directory.Exists(backupFolder))
                        {
                            Directory.CreateDirectory(backupFolder);

                            // Intentar otorgar permisos a todos (para que SQL Server pueda acceder)
                            try
                            {
                                DirectoryInfo dInfo = new DirectoryInfo(backupFolder);
                                DirectorySecurity dSecurity = dInfo.GetAccessControl();

                                // Agregar permisos para "Everyone" (Todos)
                                dSecurity.AddAccessRule(new FileSystemAccessRule(
                                    new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                                    FileSystemRights.FullControl,
                                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                                    PropagationFlags.None,
                                    AccessControlType.Allow));

                                dInfo.SetAccessControl(dSecurity);
                            }
                            catch
                            {
                                // Si falla al establecer permisos, continuar de todas formas
                                // SQL Server puede tener permisos por defecto en C:\"
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"No se pudo crear la carpeta {backupFolder}\n" +
                            $"Error: {ex.Message}\n\n" +
                            "Intente:\n" +
                            "1. Ejecutar la aplicación como Administrador\n" +
                            "2. Crear la carpeta manualmente\n" +
                            "3. Elegir otra ubicación",
                            "Error al crear carpeta",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    // El usuario eligió seleccionar otra carpeta
                    using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                    {
                        folderDialog.Description = "IMPORTANTE: SQL Server debe tener permisos de escritura en esta carpeta.\n" +
                                                  "Se recomienda elegir carpetas en la raíz (C:\\) en lugar de carpetas de usuario.";
                        folderDialog.SelectedPath = @"C:\";

                        if (folderDialog.ShowDialog() != DialogResult.OK)
                            return;

                        backupFolder = folderDialog.SelectedPath;
                    }
                }

                // Generar nombre único con fecha/hora
                string backupFileName = $"{databaseName}_backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string backupFilePath = Path.Combine(backupFolder, backupFileName);

                // Verificar que la carpeta existe y es accesible
                if (!Directory.Exists(backupFolder))
                {
                    MessageBox.Show(
                        $"La carpeta {backupFolder} no existe.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Consulta SQL para hacer el backup
                string sqlBackup = $@"
                    BACKUP DATABASE [{databaseName}]
                    TO DISK = N'{backupFilePath}'
                    WITH FORMAT,
                    INIT,
                    NAME = N'Backup completo de {databaseName}',
                    SKIP,
                    NOREWIND,
                    NOUNLOAD,
                    STATS = 10;";

                // Ejecutar el comando en SQL Server
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sqlBackup, conn))
                    {
                        // Aumentar timeout para backups grandes
                        cmd.CommandTimeout = 300; // 5 minutos
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    $"✓ Backup creado correctamente\n\n" +
                    $"Ubicación:\n{backupFilePath}\n\n" +
                    $"Base de datos: {databaseName}\n" +
                    $"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm:ss}",
                    "Backup exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (SqlException sqlEx)
            {
                // Error específico de SQL Server
                string errorMessage = $"Error de SQL Server al crear el backup:\n\n{sqlEx.Message}\n\n";

                if (sqlEx.Message.Contains("Operating system error 5") ||
                    sqlEx.Message.Contains("Access is denied") ||
                    sqlEx.Message.Contains("Acceso denegado"))
                {
                    errorMessage += "PROBLEMA DE PERMISOS:\n" +
                                    "SQL Server no tiene permisos para escribir en la carpeta seleccionada.\n\n" +
                                    "SOLUCIONES:\n" +
                                    "1. Use la carpeta recomendada C:\\SQLBackups\n" +
                                    "2. Ejecute esta aplicación como Administrador\n" +
                                    "3. Configure permisos manualmente:\n" +
                                    "   - Click derecho en la carpeta → Propiedades → Seguridad\n" +
                                    "   - Agregar permisos de 'Control total' para:\n" +
                                    "     • 'Todos' (Everyone)\n" +
                                    "     • 'NT SERVICE\\MSSQLSERVER' (o el servicio de SQL Server)\n" +
                                    "     • 'NETWORK SERVICE'\n\n" +
                                    "4. Consulte la documentación en:\n" +
                                    "   https://learn.microsoft.com/sql/relational-databases/backup-restore/backup-devices-sql-server";
                }
                else if (sqlEx.Message.Contains("BACKUP DATABASE is terminating abnormally"))
                {
                    errorMessage += "POSIBLES CAUSAS:\n" +
                                    "• La base de datos 'Hotel1' no existe\n" +
                                    "• La base de datos está en uso y no se puede hacer backup\n" +
                                    "• Espacio en disco insuficiente\n" +
                                    "• Problemas de permisos en la carpeta de destino";
                }

                MessageBox.Show(errorMessage, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error inesperado al crear el backup:\n\n{ex.Message}\n\n{ex.GetType().Name}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
