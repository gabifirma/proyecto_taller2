using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
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
                // Nombre de tu base de datos (ajustá si es distinto)
                string databaseName = "Hotel1";

                // Permitir al usuario elegir la carpeta de destino
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Seleccione la carpeta donde desea guardar el backup";

                    // Usar el escritorio del usuario actual como ubicación inicial
                    folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    if (folderDialog.ShowDialog() != DialogResult.OK)
                    {
                        // El usuario canceló la selección
                        return;
                    }

                    string backupFolder = folderDialog.SelectedPath;

                    // Crear subcarpeta "Backups" si no existe
                    string backupSubFolder = Path.Combine(backupFolder, "Backups");
                    if (!Directory.Exists(backupSubFolder))
                        Directory.CreateDirectory(backupSubFolder);

                    // Generar nombre único con fecha/hora
                    string backupFileName = $"{databaseName}_backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                    string backupFilePath = Path.Combine(backupSubFolder, backupFileName);

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

                    MessageBox.Show($"Backup creado correctamente en:\n{backupFilePath}",
                        "Backup exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error de SQL Server al crear el backup:\n{sqlEx.Message}\n\nAsegúrese de que:\n" +
                    "- SQL Server tenga permisos de escritura en la carpeta seleccionada\n" +
                    "- La base de datos Hotel1 existe\n" +
                    "- Tiene permisos de administrador",
                    "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el backup:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
