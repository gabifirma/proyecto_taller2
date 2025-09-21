using System;
using System.Data.SqlClient;
using System.Configuration;

namespace HotelCalifornia
{
    class TestConnection
    {
        static void Main()
        {
            Console.WriteLine("=== PRUEBA DE CONEXIÓN A BASE DE DATOS ===");
            Console.WriteLine();

            // Cadenas de conexión a probar
            string[] connectionStrings = {
                "Data Source=DESKTOP-1Q3KGFE\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True",
                "Data Source=DESKTOP-9V9JJ39\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True"
            };

            bool connected = false;
            string workingConnection = "";

            foreach (string connStr in connectionStrings)
            {
                Console.WriteLine("Probando conexión a: " + GetServerName(connStr));
                
                try
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        connection.Open();
                        Console.WriteLine("✓ CONEXIÓN EXITOSA!");
                        workingConnection = connStr;
                        connected = true;
                        
                        // Probar una consulta simple
                        using (SqlCommand cmd = new SqlCommand("SELECT @@VERSION", connection))
                        {
                            string version = cmd.ExecuteScalar().ToString();
                            Console.WriteLine("Versión del servidor: " + version.Split('\n')[0]);
                        }
                        
                        // Verificar si existe la base de datos Hotel
                        using (SqlCommand cmd = new SqlCommand("SELECT DB_ID('Hotel')", connection))
                        {
                            var result = cmd.ExecuteScalar();
                            if (result != DBNull.Value && result != null)
                            {
                                Console.WriteLine("✓ Base de datos 'Hotel' encontrada");
                            }
                            else
                            {
                                Console.WriteLine("⚠ Base de datos 'Hotel' no encontrada - se creará automáticamente");
                            }
                        }
                        
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("✗ Error: " + ex.Message);
                }
                
                Console.WriteLine();
            }

            if (connected)
            {
                Console.WriteLine("=== RESUMEN ===");
                Console.WriteLine("Servidor conectado: " + GetServerName(workingConnection));
                Console.WriteLine("La aplicación debería funcionar correctamente.");
            }
            else
            {
                Console.WriteLine("=== ERROR ===");
                Console.WriteLine("No se pudo conectar a ningún servidor SQL Server.");
                Console.WriteLine("Verifica que:");
                Console.WriteLine("1. SQL Server esté instalado y ejecutándose");
                Console.WriteLine("2. El servicio SQL Server (SQLEXPRESS) esté iniciado");
                Console.WriteLine("3. El nombre del servidor sea correcto");
            }

            Console.WriteLine();
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        private static string GetServerName(string connectionStr)
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(connectionStr);
                return builder.DataSource;
            }
            catch
            {
                return "Servidor desconocido";
            }
        }
    }
}
