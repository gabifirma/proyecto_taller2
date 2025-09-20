using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HotelCalifornia
{
    public class DatabaseHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["HotelConnectionString"].ConnectionString;

        public static string GetConnectionString()
        {
            return connectionString;
        }

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

        public static void CreateSampleData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    CreateSampleReservas(connection);
                    CreateSamplePagos(connection);
                }
            }
            catch (Exception ex)
            {
                // Continuar sin datos de ejemplo si hay error
            }
        }

        private static void CreateSampleReservas(SqlConnection connection)
        {
            // Verificar si ya existen reservas
            string checkQuery = "SELECT COUNT(*) FROM Reserva";
            using (SqlCommand command = new SqlCommand(checkQuery, connection))
            {
                int count = (int)command.ExecuteScalar();
                if (count > 5) return; // Ya hay suficientes datos
            }

            string insertQuery = @"
                INSERT INTO Reserva (Id, Cliente, FechaCheckIn, FechaCheckOut, Servicio, Estado, MetodoPago, CantidadHuespedes, MontoEstimado, Activo, FechaDesactivacion, MotivoDesactivacion)
                VALUES 
                (@Id, @Cliente, @FechaCheckIn, @FechaCheckOut, @Servicio, @Estado, @MetodoPago, @CantidadHuespedes, @MontoEstimado, @Activo, @FechaDesactivacion, @MotivoDesactivacion)";

            var reservas = new[]
            {
                new { Id = "RES-001", Cliente = "Juan Pérez", FechaCheckIn = DateTime.Now.AddDays(-10), FechaCheckOut = DateTime.Now.AddDays(-7), Servicio = "Habitación Doble", Estado = "Confirmada", MetodoPago = "Tarjeta", CantidadHuespedes = 2, MontoEstimado = 450.00m, Activo = true },
                new { Id = "RES-002", Cliente = "María García", FechaCheckIn = DateTime.Now.AddDays(-5), FechaCheckOut = DateTime.Now.AddDays(-2), Servicio = "Suite Presidencial", Estado = "Confirmada", MetodoPago = "Efectivo", CantidadHuespedes = 4, MontoEstimado = 1200.00m, Activo = true },
                new { Id = "RES-003", Cliente = "Carlos López", FechaCheckIn = DateTime.Now.AddDays(2), FechaCheckOut = DateTime.Now.AddDays(5), Servicio = "Habitación Simple", Estado = "Pendiente", MetodoPago = "Transferencia", CantidadHuespedes = 1, MontoEstimado = 300.00m, Activo = true },
                new { Id = "RES-004", Cliente = "Ana Martínez", FechaCheckIn = DateTime.Now.AddDays(-15), FechaCheckOut = DateTime.Now.AddDays(-12), Servicio = "Habitación Doble", Estado = "Anulada", MetodoPago = "Tarjeta", CantidadHuespedes = 2, MontoEstimado = 450.00m, Activo = false },
                new { Id = "RES-005", Cliente = "Roberto Silva", FechaCheckIn = DateTime.Now.AddDays(7), FechaCheckOut = DateTime.Now.AddDays(10), Servicio = "Suite Junior", Estado = "Confirmada", MetodoPago = "Tarjeta", CantidadHuespedes = 3, MontoEstimado = 800.00m, Activo = true },
                new { Id = "RES-006", Cliente = "Laura Fernández", FechaCheckIn = DateTime.Now.AddDays(-3), FechaCheckOut = DateTime.Now, Servicio = "Habitación Doble", Estado = "Confirmada", MetodoPago = "Efectivo", CantidadHuespedes = 2, MontoEstimado = 450.00m, Activo = true },
                new { Id = "RES-007", Cliente = "Diego Morales", FechaCheckIn = DateTime.Now.AddDays(15), FechaCheckOut = DateTime.Now.AddDays(18), Servicio = "Habitación Simple", Estado = "Pendiente", MetodoPago = "Transferencia", CantidadHuespedes = 1, MontoEstimado = 300.00m, Activo = true },
                new { Id = "RES-008", Cliente = "Carmen Ruiz", FechaCheckIn = DateTime.Now.AddDays(-20), FechaCheckOut = DateTime.Now.AddDays(-17), Servicio = "Suite Presidencial", Estado = "Anulada", MetodoPago = "Tarjeta", CantidadHuespedes = 4, MontoEstimado = 1200.00m, Activo = false },
                new { Id = "RES-009", Cliente = "Fernando Castro", FechaCheckIn = DateTime.Now.AddDays(1), FechaCheckOut = DateTime.Now.AddDays(4), Servicio = "Habitación Doble", Estado = "Confirmada", MetodoPago = "Tarjeta", CantidadHuespedes = 2, MontoEstimado = 450.00m, Activo = true },
                new { Id = "RES-010", Cliente = "Patricia Herrera", FechaCheckIn = DateTime.Now.AddDays(-8), FechaCheckOut = DateTime.Now.AddDays(-5), Servicio = "Suite Junior", Estado = "Confirmada", MetodoPago = "Efectivo", CantidadHuespedes = 3, MontoEstimado = 800.00m, Activo = true }
            };

            foreach (var reserva in reservas)
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", reserva.Id);
                    command.Parameters.AddWithValue("@Cliente", reserva.Cliente);
                    command.Parameters.AddWithValue("@FechaCheckIn", reserva.FechaCheckIn);
                    command.Parameters.AddWithValue("@FechaCheckOut", reserva.FechaCheckOut);
                    command.Parameters.AddWithValue("@Servicio", reserva.Servicio);
                    command.Parameters.AddWithValue("@Estado", reserva.Estado);
                    command.Parameters.AddWithValue("@MetodoPago", reserva.MetodoPago);
                    command.Parameters.AddWithValue("@CantidadHuespedes", reserva.CantidadHuespedes);
                    command.Parameters.AddWithValue("@MontoEstimado", reserva.MontoEstimado);
                    command.Parameters.AddWithValue("@Activo", reserva.Activo);
                    command.Parameters.AddWithValue("@FechaDesactivacion", reserva.Activo ? (object)DBNull.Value : DateTime.Now.AddDays(-1));
                    command.Parameters.AddWithValue("@MotivoDesactivacion", reserva.Activo ? (object)DBNull.Value : "Cancelada por cliente");
                    
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        // Ignorar si ya existe
                    }
                }
            }
        }

        private static void CreateSamplePagos(SqlConnection connection)
        {
            // Verificar si ya existen pagos
            string checkQuery = "SELECT COUNT(*) FROM Pago";
            using (SqlCommand command = new SqlCommand(checkQuery, connection))
            {
                int count = (int)command.ExecuteScalar();
                if (count > 5) return; // Ya hay suficientes datos
            }

            string insertQuery = @"
                INSERT INTO Pago (Id, ReservaId, FechaPago, Monto, MetodoPago, Estado, Activo, FechaDesactivacion, MotivoDesactivacion)
                VALUES 
                (@Id, @ReservaId, @FechaPago, @Monto, @MetodoPago, @Estado, @Activo, @FechaDesactivacion, @MotivoDesactivacion)";

            var pagos = new[]
            {
                new { Id = "PAG-001", ReservaId = "RES-001", FechaPago = DateTime.Now.AddDays(-9), Monto = 450.00m, MetodoPago = "Tarjeta", Estado = "Confirmado", Activo = true },
                new { Id = "PAG-002", ReservaId = "RES-002", FechaPago = DateTime.Now.AddDays(-4), Monto = 1200.00m, MetodoPago = "Efectivo", Estado = "Confirmado", Activo = true },
                new { Id = "PAG-003", ReservaId = "RES-003", FechaPago = DateTime.Now.AddDays(1), Monto = 150.00m, MetodoPago = "Transferencia", Estado = "Pendiente", Activo = true },
                new { Id = "PAG-004", ReservaId = "RES-004", FechaPago = DateTime.Now.AddDays(-14), Monto = 450.00m, MetodoPago = "Tarjeta", Estado = "Reembolsado", Activo = false },
                new { Id = "PAG-005", ReservaId = "RES-005", FechaPago = DateTime.Now.AddDays(6), Monto = 400.00m, MetodoPago = "Tarjeta", Estado = "Pendiente", Activo = true },
                new { Id = "PAG-006", ReservaId = "RES-006", FechaPago = DateTime.Now.AddDays(-2), Monto = 450.00m, MetodoPago = "Efectivo", Estado = "Confirmado", Activo = true },
                new { Id = "PAG-007", ReservaId = "RES-007", FechaPago = DateTime.Now.AddDays(14), Monto = 100.00m, MetodoPago = "Transferencia", Estado = "Pendiente", Activo = true },
                new { Id = "PAG-008", ReservaId = "RES-008", FechaPago = DateTime.Now.AddDays(-19), Monto = 1200.00m, MetodoPago = "Tarjeta", Estado = "Reembolsado", Activo = false },
                new { Id = "PAG-009", ReservaId = "RES-009", FechaPago = DateTime.Now, Monto = 225.00m, MetodoPago = "Tarjeta", Estado = "Confirmado", Activo = true },
                new { Id = "PAG-010", ReservaId = "RES-010", FechaPago = DateTime.Now.AddDays(-7), Monto = 800.00m, MetodoPago = "Efectivo", Estado = "Confirmado", Activo = true }
            };

            foreach (var pago in pagos)
            {
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", pago.Id);
                    command.Parameters.AddWithValue("@ReservaId", pago.ReservaId);
                    command.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                    command.Parameters.AddWithValue("@Monto", pago.Monto);
                    command.Parameters.AddWithValue("@MetodoPago", pago.MetodoPago);
                    command.Parameters.AddWithValue("@Estado", pago.Estado);
                    command.Parameters.AddWithValue("@Activo", pago.Activo);
                    command.Parameters.AddWithValue("@FechaDesactivacion", pago.Activo ? (object)DBNull.Value : DateTime.Now.AddDays(-1));
                    command.Parameters.AddWithValue("@MotivoDesactivacion", pago.Activo ? (object)DBNull.Value : "Reembolso procesado");
                    
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        // Ignorar si ya existe
                    }
                }
            }
        }
    }
}
