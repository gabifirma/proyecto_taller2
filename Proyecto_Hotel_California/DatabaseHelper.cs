using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HotelCalifornia
{
    public class DatabaseHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["HotelConnectionString"].ConnectionString;

        public static bool TestConnection()
        {
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
    }
}
