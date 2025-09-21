using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace HotelCalifornia
{
    public class DatabaseHelper
    {
        private static string connectionString;
        private static bool connectionInitialized = false;

        static DatabaseHelper()
        {
            InitializeConnection();
        }

        private static void InitializeConnection()
        {
            if (connectionInitialized) return;

            // Lista de cadenas de conexión a probar
            string[] connectionStrings = {
                ConfigurationManager.ConnectionStrings["HotelConnectionString"]?.ConnectionString,
                ConfigurationManager.ConnectionStrings["HotelConnectionStringAlt"]?.ConnectionString
            };

            foreach (string connStr in connectionStrings)
            {
                if (string.IsNullOrEmpty(connStr)) continue;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connStr))
                    {
                        connection.Open();
                        connectionString = connStr;
                        connectionInitialized = true;
                        // Conexión exitosa - se puede agregar logging aquí si es necesario
                        Console.WriteLine("Conectado exitosamente a: " + GetServerName(connStr));
                        return;
                    }
                }
                catch (Exception)
                {
                    // Continuar con la siguiente cadena de conexión
                    continue;
                }
            }

            // Si llegamos aquí, ninguna conexión funcionó
            connectionString = connectionStrings[0]; // Usar la primera como fallback
            connectionInitialized = true;
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

        public static string GetConnectionString()
        {
            if (!connectionInitialized)
                InitializeConnection();
            return connectionString;
        }

        public static bool TestConnection()
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Si no puede conectar, usar modo sin base de datos
                return false;
            }
        }

        public static void InitializeDatabase()
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Crear tabla de usuarios si no existe
                    string createTableQuery = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Usuarios' AND xtype='U')
                        CREATE TABLE Usuarios (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            NombreUsuario NVARCHAR(50) NOT NULL UNIQUE,
                            Contraseña NVARCHAR(255) NOT NULL,
                            TipoUsuario NVARCHAR(20) NOT NULL,
                            NombreCompleto NVARCHAR(100) NOT NULL,
                            Activo BIT NOT NULL DEFAULT 1,
                            FechaCreacion DATETIME NOT NULL DEFAULT GETDATE()
                        )";

                    using (SqlCommand command = new SqlCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Verificar si existen usuarios, si no, crear los usuarios por defecto
                    string checkUsersQuery = "SELECT COUNT(*) FROM Usuarios";
                    using (SqlCommand command = new SqlCommand(checkUsersQuery, connection))
                    {
                        int userCount = (int)command.ExecuteScalar();
                        if (userCount == 0)
                        {
                            CreateDefaultUsers(connection);
                        }
                    }

                    // Crear tabla de clientes y datos de ejemplo
                    CreateClientesTable(connection);
                    CreateSampleClientes(connection);
                }
            }
            catch (Exception ex)
            {
                // Si hay error, continuar sin base de datos
            }
        }

        private static void CreateDefaultUsers(SqlConnection connection)
        {
            string insertUsersQuery = @"
                INSERT INTO Usuarios (NombreUsuario, Contraseña, TipoUsuario, NombreCompleto, Activo, FechaCreacion)
                VALUES 
                ('admin', 'admin123', 'Administrador', 'Administrador del Sistema', 1, GETDATE()),
                ('supervisor1', 'super123', 'Supervisor', 'Supervisor General', 1, GETDATE()),
                ('recepcion1', 'recepcion123', 'Recepcionista', 'Recepcionista Principal', 1, GETDATE())";

            using (SqlCommand command = new SqlCommand(insertUsersQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public static Usuario AuthenticateUser(string nombreUsuario, string contraseña)
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Id, NombreUsuario, Contraseña, TipoUsuario, NombreCompleto, Activo, FechaCreacion FROM Usuarios WHERE NombreUsuario = @nombreUsuario AND Contraseña = @contraseña AND Activo = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                        command.Parameters.AddWithValue("@contraseña", contraseña);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Usuario
                                {
                                    Id = reader.GetInt32(0),
                                    NombreUsuario = reader.GetString(1),
                                    Contraseña = reader.GetString(2),
                                    TipoUsuario = reader.GetString(3),
                                    NombreCompleto = reader.GetString(4),
                                    Activo = reader.GetBoolean(5),
                                    FechaCreacion = reader.GetDateTime(6)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Si hay error de base de datos, retornar null
            }
            return null;
        }

        private static void CreateClientesTable(SqlConnection connection)
        {
            string createTableQuery = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Cliente' AND xtype='U')
                CREATE TABLE Cliente (
                    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
                    nombre NVARCHAR(50) NOT NULL,
                    apellido NVARCHAR(50) NOT NULL,
                    dni NVARCHAR(20) NOT NULL UNIQUE,
                    telefono NVARCHAR(20),
                    email NVARCHAR(100),
                    direccion NVARCHAR(200),
                    fecha_registro DATETIME NOT NULL DEFAULT GETDATE(),
                    activo BIT NOT NULL DEFAULT 1
                )";

            using (SqlCommand command = new SqlCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private static void CreateSampleClientes(SqlConnection connection)
        {
            // Verificar si ya existen clientes
            string checkClientesQuery = "SELECT COUNT(*) FROM Cliente";
            using (SqlCommand command = new SqlCommand(checkClientesQuery, connection))
            {
                int clienteCount = (int)command.ExecuteScalar();
                if (clienteCount == 0)
                {
                    string insertClientesQuery = @"
                        INSERT INTO Cliente (nombre, apellido, dni, telefono, email, direccion, fecha_registro, activo)
                        VALUES 
                        ('Juan', 'Pérez', '12345678', '011-1234-5678', 'juan.perez@email.com', 'Av. Corrientes 1234, CABA', GETDATE(), 1),
                        ('María', 'González', '23456789', '011-2345-6789', 'maria.gonzalez@email.com', 'Av. Santa Fe 2345, CABA', GETDATE(), 1),
                        ('Carlos', 'Rodríguez', '34567890', '011-3456-7890', 'carlos.rodriguez@email.com', 'Av. Rivadavia 3456, CABA', GETDATE(), 1),
                        ('Ana', 'Martínez', '45678901', '011-4567-8901', 'ana.martinez@email.com', 'Av. Cabildo 4567, CABA', GETDATE(), 1),
                        ('Luis', 'López', '56789012', '011-5678-9012', 'luis.lopez@email.com', 'Av. Las Heras 5678, CABA', GETDATE(), 1),
                        ('Laura', 'Fernández', '67890123', '011-6789-0123', 'laura.fernandez@email.com', 'Av. Pueyrredón 6789, CABA', GETDATE(), 1),
                        ('Roberto', 'García', '78901234', '011-7890-1234', 'roberto.garcia@email.com', 'Av. Callao 7890, CABA', GETDATE(), 1),
                        ('Patricia', 'Sánchez', '89012345', '011-8901-2345', 'patricia.sanchez@email.com', 'Av. Scalabrini Ortiz 8901, CABA', GETDATE(), 1),
                        ('Miguel', 'Torres', '90123456', '011-9012-3456', 'miguel.torres@email.com', 'Av. Juan B. Justo 9012, CABA', GETDATE(), 1),
                        ('Carmen', 'Ruiz', '01234567', '011-0123-4567', 'carmen.ruiz@email.com', 'Av. Belgrano 0123, CABA', GETDATE(), 1)";

                    using (SqlCommand insertCommand = new SqlCommand(insertClientesQuery, connection))
                    {
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void InsertSampleClientesManually()
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    CreateClientesTable(connection);
                    CreateSampleClientes(connection);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar clientes de ejemplo: " + ex.Message);
            }
        }

        /// <summary>
        /// Fuerza la reinicialización de la conexión para probar todas las bases de datos disponibles
        /// </summary>
        public static void ResetConnection()
        {
            connectionInitialized = false;
            connectionString = null;
            InitializeConnection();
        }

        /// <summary>
        /// Obtiene información sobre la conexión actual
        /// </summary>
        public static string GetCurrentConnectionInfo()
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                var builder = new SqlConnectionStringBuilder(connectionString);
                return "Servidor: " + builder.DataSource + ", Base de datos: " + builder.InitialCatalog;
            }
            catch
            {
                return "Información de conexión no disponible";
            }
        }
    }
}
