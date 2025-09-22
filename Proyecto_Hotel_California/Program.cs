using System;
using System.Windows.Forms;

namespace HotelCalifornia
{
    /// <summary>
    /// Clase principal que contiene el punto de entrada de la aplicación Hotel California.
    /// Se encarga de inicializar la aplicación, configurar la base de datos y mostrar el formulario de login.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación Hotel California.
        /// Configura los estilos visuales, inicializa la base de datos y ejecuta el formulario de login.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilitar estilos visuales modernos de Windows
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                // Intentar inicializar la conexión a la base de datos
                if (DatabaseHelper.TestConnection())
                {
                    // Si la conexión es exitosa, inicializar las tablas y datos por defecto
                    DatabaseHelper.InitializeDatabase();
                    Application.Run(new LoginForm());
                }
                else
                {
                    // Si no hay conexión a la base de datos, continuar en modo offline
                    MessageBox.Show("No se pudo conectar a la base de datos. Usando modo sin base de datos.", 
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Run(new LoginForm());
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error crítico durante la inicialización
                MessageBox.Show("Error al inicializar la aplicación: " + ex.Message, 
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}