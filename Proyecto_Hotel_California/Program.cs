using System;
using System.Windows.Forms;

namespace HotelCalifornia
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                // Inicializar la base de datos
                if (DatabaseHelper.TestConnection())
                {
                    DatabaseHelper.InitializeDatabase();
                    Application.Run(new LoginForm());
                }
                else
                {
                    // Si no hay base de datos, usar login simple
                    MessageBox.Show("No se pudo conectar a la base de datos. Usando modo sin base de datos.", 
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Run(new LoginForm());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar la aplicación: " + ex.Message, 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}