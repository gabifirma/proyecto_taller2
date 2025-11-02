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

                // Carpeta destino para el backup
                string backupFolder = @"C:\Users\Jonii\Desktop\proyecto_taller2\packages\Backups";

                // Crear la carpeta si no existe
                if (!Directory.Exists(backupFolder))
                    Directory.CreateDirectory(backupFolder);

                // Generar nombre único con fecha/hora
                string backupFileName = $"{databaseName}_backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string backupFilePath = Path.Combine(backupFolder, backupFileName);

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
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Backup creado correctamente en:\n{backupFilePath}",
                    "Backup exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el backup:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
