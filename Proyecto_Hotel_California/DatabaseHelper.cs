using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace HotelCalifornia
{
    /// <summary>
    /// Clase helper para manejar todas las operaciones de base de datos del Hotel California.
    /// Gestiona la conexión, inicialización de tablas y operaciones CRUD básicas.
    /// </summary>
    public class DatabaseHelper
    {
        // Variables estáticas para manejar la conexión de forma singleton
        private static string connectionString;
        private static bool connectionInitialized = false;

        /// <summary>
        /// Constructor estático que inicializa la conexión automáticamente
        /// </summary>
        static DatabaseHelper()
        {
            InitializeConnection();
        }

        /// <summary>
        /// Inicializa la conexión a la base de datos probando múltiples cadenas de conexión
        /// </summary>
        private static void InitializeConnection()
        {
            if (connectionInitialized) return;

            // Lista de cadenas de conexión a probar desde el archivo de configuración
            string[] connectionStrings = {
                ConfigurationManager.ConnectionStrings["HotelConnectionString"]?.ConnectionString,
                ConfigurationManager.ConnectionStrings["HotelConnectionStringAlt"]?.ConnectionString
            };

            // Probar cada cadena de conexión hasta encontrar una que funcione
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
                    // Continuar con la siguiente cadena de conexión si esta falla
                    continue;
                }
            }

            // Si llegamos aquí, ninguna conexión funcionó - usar la primera como fallback
            connectionString = connectionStrings[0];
            connectionInitialized = true;
        }

        /// <summary>
        /// Extrae el nombre del servidor de una cadena de conexión
        /// </summary>
        /// <param name="connectionStr">Cadena de conexión</param>
        /// <returns>Nombre del servidor o mensaje por defecto si hay error</returns>
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

        /// <summary>
        /// Obtiene la cadena de conexión actualmente configurada
        /// </summary>
        /// <returns>Cadena de conexión a la base de datos</returns>
        public static string GetConnectionString()
        {
            if (!connectionInitialized)
                InitializeConnection();
            return connectionString;
        }

        /// <summary>
        /// Prueba la conexión a la base de datos
        /// </summary>
        /// <returns>True si la conexión es exitosa, False en caso contrario</returns>
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
                // Si no puede conectar, retornar false para usar modo sin base de datos
                return false;
            }
        }

        /// <summary>
        /// Inicializa la base de datos creando las tablas necesarias y datos por defecto
        /// </summary>
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
                // Si hay error, continuar sin base de datos (modo offline)
            }
        }

        /// <summary>
        /// Crea los usuarios por defecto del sistema
        /// </summary>
        /// <param name="connection">Conexión activa a la base de datos</param>
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

        /// <summary>
        /// Autentica un usuario verificando sus credenciales en la base de datos Hotel1
        /// Consulta la tabla Usuario y obtiene información del Rol asociado
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario (username)</param>
        /// <param name="contraseña">Contraseña del usuario</param>
        /// <returns>Objeto Usuario si las credenciales son válidas, null en caso contrario</returns>
        public static Usuario AuthenticateUser(string nombreUsuario, string contraseña)
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    // TODO: Implementar hashing de contraseñas (ej. SHA256) para futuras mejoras
                    // Consulta que une Usuario con Rol y Empleado para obtener información completa
                    string query = @"
                        SELECT u.id_usuario, u.username, u.contrasena, u.id_rol, u.legajo,
                               r.nombre as rol_nombre, e.nombre as emp_nombre, e.apellido as emp_apellido, u.activo
                        FROM Usuario u
                        INNER JOIN Rol r ON u.id_rol = r.id_rol
                        LEFT JOIN Empleado e ON u.legajo = e.legajo
                        WHERE u.username = @username AND u.contrasena = @password AND u.activo = 1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", nombreUsuario);
                        command.Parameters.AddWithValue("@password", contraseña);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nombre = reader.IsDBNull(6) ? "" : reader.GetString(6);
                                string apellido = reader.IsDBNull(7) ? "" : reader.GetString(7);
                                bool activo = reader.IsDBNull(8) ? true : reader.GetBoolean(8);
                                string nombreCompleto = !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellido)
                                    ? $"{nombre} {apellido}"
                                    : nombreUsuario;

                                return new Usuario
                                {
                                    Id = reader.GetInt32(0),
                                    NombreUsuario = reader.GetString(1),
                                    Contraseña = reader.GetString(2),
                                    IdRol = reader.GetInt32(3),
                                    Legajo = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                                    Activo = activo,
                                    TipoUsuario = reader.GetString(5),
                                    NombreCompleto = nombreCompleto,
                                    FechaCreacion = DateTime.Now
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Si hay error de base de datos, retornar null para usar modo fallback
                System.Diagnostics.Debug.WriteLine($"Error en AuthenticateUser: {ex.Message}");
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

        /// <summary>
        /// Obtiene todos los roles disponibles en el sistema, excluyendo el rol de Administrador
        /// </summary>
        /// <returns>DataTable con los roles disponibles</returns>
        public static DataTable GetRolesExceptAdmin()
        {
            if (!connectionInitialized)
                InitializeConnection();

            DataTable dtRoles = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_rol, nombre FROM Rol WHERE nombre != 'Administrador' ORDER BY nombre";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dtRoles);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GetRolesExceptAdmin: {ex.Message}");
            }
            return dtRoles;
        }

        /// <summary>
        /// Obtiene todos los roles del sistema
        /// </summary>
        public static DataTable GetAllRoles()
        {
            if (!connectionInitialized)
                InitializeConnection();

            DataTable dtRoles = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_rol, nombre FROM Rol ORDER BY nombre";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dtRoles);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GetAllRoles: {ex.Message}");
            }
            return dtRoles;
        }

        /// <summary>
        /// Obtiene los empleados que no tienen usuario asignado
        /// </summary>
        public static DataTable GetEmpleadosSinUsuario()
        {
            if (!connectionInitialized)
                InitializeConnection();

            DataTable dtEmpleados = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT e.legajo, e.nombre + ' ' + e.apellido as nombre_completo, e.telefono, e.email
                        FROM Empleado e
                        WHERE e.estado = 1
                          AND e.legajo NOT IN (SELECT legajo FROM Usuario WHERE legajo IS NOT NULL)
                        ORDER BY e.apellido, e.nombre";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dtEmpleados);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GetEmpleadosSinUsuario: {ex.Message}");
            }
            return dtEmpleados;
        }

        /// <summary>
        /// Obtiene un usuario por su ID
        /// </summary>
        public static DataTable GetUsuarioById(int idUsuario)
        {
            if (!connectionInitialized)
                InitializeConnection();

            DataTable dtUsuario = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT u.id_usuario, u.username, u.contrasena, u.id_rol, u.legajo, u.activo,
                               r.nombre as nombre_rol
                        FROM Usuario u
                        INNER JOIN Rol r ON u.id_rol = r.id_rol
                        WHERE u.id_usuario = @idUsuario";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dtUsuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GetUsuarioById: {ex.Message}");
            }
            return dtUsuario;
        }

        private static int? ObtenerLegajoDeUsuario(int idUsuario, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "SELECT legajo FROM Usuario WHERE id_usuario = @idUsuario";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@idUsuario", idUsuario);
                object result = command.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return null;
                return Convert.ToInt32(result);
            }
        }

        private static bool EsEmpleadoActivo(int legajo, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "SELECT estado FROM Empleado WHERE legajo = @legajo";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@legajo", legajo);
                object result = command.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    throw new Exception("No se encontró el empleado asociado.");

                int estado = Convert.ToInt32(result);
                return estado == 1;
            }
        }

        public static bool EsEmpleadoActivo(int legajo)
        {
            if (!connectionInitialized)
                InitializeConnection();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return EsEmpleadoActivo(legajo, connection, null);
            }
        }

        /// <summary>
        /// Crea un nuevo usuario asociado a un empleado existente
        /// </summary>
        public static bool CreateUsuario(int legajo, string username, string password, int idRol)
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (!EsEmpleadoActivo(legajo, connection, null))
                        throw new Exception("No se puede crear un usuario para un empleado inactivo.");

                    // Obtener el próximo id_usuario disponible
                    string getNextIdQuery = "SELECT ISNULL(MAX(id_usuario), 0) + 1 FROM Usuario";
                    int nextUserId;
                    using (SqlCommand cmdGetId = new SqlCommand(getNextIdQuery, connection))
                    {
                        nextUserId = (int)cmdGetId.ExecuteScalar();
                    }

                    // Insertar el usuario
                    string insertQuery = @"
                        INSERT INTO Usuario (id_usuario, username, contrasena, activo, ultimo_acceso, id_rol, legajo)
                        VALUES (@id_usuario, @username, @contrasena, 1, GETDATE(), @idRol, @legajo)";
                    
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id_usuario", nextUserId);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@contrasena", password);
                        command.Parameters.AddWithValue("@idRol", idRol);
                        command.Parameters.AddWithValue("@legajo", legajo);
                        
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en CreateUsuario: {ex.Message}");
                throw new Exception($"Error al crear usuario: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza un usuario existente
        /// </summary>
        public static bool UpdateUsuario(int idUsuario, string username, string password, int idRol, bool activo)
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    int? legajo = ObtenerLegajoDeUsuario(idUsuario, connection, null);
                    if (legajo.HasValue && activo && !EsEmpleadoActivo(legajo.Value, connection, null))
                    {
                        throw new Exception("No se puede activar el usuario porque el empleado asociado está inactivo.");
                    }

                    string query = @"
                        UPDATE Usuario 
                        SET username = @username, 
                            contrasena = @contrasena, 
                            id_rol = @idRol, 
                            activo = @activo,
                            ultimo_acceso = GETDATE()
                        WHERE id_usuario = @idUsuario";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@contrasena", password);
                        command.Parameters.AddWithValue("@idRol", idRol);
                        command.Parameters.AddWithValue("@activo", activo ? 1 : 0);
                        
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en UpdateUsuario: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Desactiva un usuario (soft delete)
        /// </summary>
        public static bool DeleteUser(int idUsuario)
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Usuario SET activo = 0 WHERE id_usuario = @idUsuario";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idUsuario", idUsuario);
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en DeleteUser: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios del sistema con su información completa
        /// </summary>
        /// <returns>DataTable con la lista de usuarios</returns>
        public static DataTable GetAllUsers()
        {
            if (!connectionInitialized)
                InitializeConnection();

            DataTable dtUsuarios = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT u.id_usuario, u.username, u.contrasena, u.id_rol, u.legajo,
                               u.activo,
                               r.nombre as nombre_rol, 
                               ISNULL(e.nombre + ' ' + e.apellido, 'Sin empleado') as nombre_completo,
                               CASE WHEN u.activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS estado_usuario
                        FROM Usuario u
                        INNER JOIN Rol r ON u.id_rol = r.id_rol
                        LEFT JOIN Empleado e ON u.legajo = e.legajo
                        ORDER BY u.id_usuario";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dtUsuarios);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GetAllUsers: {ex.Message}");
            }
            return dtUsuarios;
        }

        /// <summary>
        /// Crea un nuevo empleado y su usuario asociado usando una transacción
        /// </summary>
        /// <param name="nombre">Nombre del empleado</param>
        /// <param name="apellido">Apellido del empleado</param>
        /// <param name="telefono">Teléfono del empleado</param>
        /// <param name="email">Email del empleado</param>
        /// <param name="username">Nombre de usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <param name="idRol">ID del rol asignado</param>
        /// <returns>True si se creó exitosamente, False en caso contrario</returns>
        public static bool CreateEmpleadoAndUsuario(string nombre, string apellido, string telefono, 
                                                     string email, string username, string password, int idRol)
        {
            if (!connectionInitialized)
                InitializeConnection();

            SqlConnection connection = null;
            SqlTransaction transaction = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                transaction = connection.BeginTransaction();

                // Paso 1: Insertar el empleado (legajo es IDENTITY, se genera automáticamente)
                string insertEmpleadoQuery = @"
                    INSERT INTO Empleado (nombre, apellido, telefono, email, estado)
                    VALUES (@nombre, @apellido, @telefono, @email, 1);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int legajo;
                using (SqlCommand cmdEmpleado = new SqlCommand(insertEmpleadoQuery, connection, transaction))
                {
                    cmdEmpleado.Parameters.AddWithValue("@nombre", nombre);
                    cmdEmpleado.Parameters.AddWithValue("@apellido", apellido);
                    
                    // Convertir teléfono a INT (la columna en BD es INT)
                    if (!string.IsNullOrEmpty(telefono) && int.TryParse(telefono, out int telefonoInt))
                        cmdEmpleado.Parameters.AddWithValue("@telefono", telefonoInt);
                    else
                        cmdEmpleado.Parameters.AddWithValue("@telefono", DBNull.Value);
                    
                    cmdEmpleado.Parameters.AddWithValue("@email", email ?? (object)DBNull.Value);
                    
                    legajo = (int)cmdEmpleado.ExecuteScalar();
                }

                // Paso 2: Obtener el próximo id_usuario disponible
                string getNextIdQuery = "SELECT ISNULL(MAX(id_usuario), 0) + 1 FROM Usuario";
                int nextUserId;
                using (SqlCommand cmdGetId = new SqlCommand(getNextIdQuery, connection, transaction))
                {
                    nextUserId = (int)cmdGetId.ExecuteScalar();
                }

                // Paso 3: Insertar el usuario asociado
                // TODO: Implementar hashing de contraseñas (ej. SHA256) para futuras mejoras
                string insertUsuarioQuery = @"
                    INSERT INTO Usuario (id_usuario, username, contrasena, activo, ultimo_acceso, id_rol, legajo)
                    VALUES (@id_usuario, @username, @contrasena, 1, GETDATE(), @idRol, @legajo);";

                using (SqlCommand cmdUsuario = new SqlCommand(insertUsuarioQuery, connection, transaction))
                {
                    cmdUsuario.Parameters.AddWithValue("@id_usuario", nextUserId);
                    cmdUsuario.Parameters.AddWithValue("@username", username);
                    cmdUsuario.Parameters.AddWithValue("@contrasena", password);
                    cmdUsuario.Parameters.AddWithValue("@idRol", idRol);
                    cmdUsuario.Parameters.AddWithValue("@legajo", legajo);
                    
                    cmdUsuario.ExecuteNonQuery();
                }

                // Confirmar la transacción
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                // Revertir la transacción en caso de error
                transaction?.Rollback();
                System.Diagnostics.Debug.WriteLine($"Error en CreateEmpleadoAndUsuario: {ex.Message}");
                throw new Exception($"Error al crear empleado y usuario: {ex.Message}");
            }
            finally
            {
                connection?.Close();
            }
        }
        /// <summary>
        /// Obtiene todos los empleados del sistema
        /// </summary>
        public static DataTable GetAllEmpleados()
        {
            if (!connectionInitialized)
                InitializeConnection();

            DataTable dtEmpleados = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT e.legajo, e.nombre, e.apellido, e.telefono, e.email, e.estado AS estado,
                               CASE WHEN u.id_usuario IS NOT NULL THEN 'Sí' ELSE 'No' END as tiene_usuario
                        FROM Empleado e
                        LEFT JOIN Usuario u ON e.legajo = u.legajo
                        ORDER BY e.apellido, e.nombre";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dtEmpleados);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GetAllEmpleados: {ex.Message}");
            }
            return dtEmpleados;
        }

        /// <summary>
        /// Crea un nuevo empleado sin usuario asociado
        /// </summary>
        public static int CreateEmpleado(string nombre, string apellido, string telefono, string email)
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO Empleado (nombre, apellido, telefono, email, estado)
                        VALUES (@nombre, @apellido, @telefono, @email, 1);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@apellido", apellido);
                        command.Parameters.AddWithValue("@telefono", telefono);
                        command.Parameters.AddWithValue("@email", email);
                        
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en CreateEmpleado: {ex.Message}");
                throw new Exception($"Error al crear empleado: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza un empleado existente
        /// </summary>
        public static bool UpdateEmpleado(int legajo, string nombre, string apellido, string telefono, string email, bool estado)
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string query = @"
                        UPDATE Empleado 
                        SET nombre = @nombre, 
                            apellido = @apellido, 
                            telefono = @telefono, 
                            email = @email,
                            estado = @estado
                        WHERE legajo = @legajo";

                            using (SqlCommand command = new SqlCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@legajo", legajo);
                                command.Parameters.AddWithValue("@nombre", nombre);
                                command.Parameters.AddWithValue("@apellido", apellido);
                                command.Parameters.AddWithValue("@telefono", telefono);
                                command.Parameters.AddWithValue("@email", email);
                                command.Parameters.AddWithValue("@estado", estado ? 1 : 0);

                                if (command.ExecuteNonQuery() == 0)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }

                            string actualizarUsuarioQuery = "UPDATE Usuario SET activo = @estado WHERE legajo = @legajo";
                            using (SqlCommand usuarioCommand = new SqlCommand(actualizarUsuarioQuery, connection, transaction))
                            {
                                usuarioCommand.Parameters.AddWithValue("@estado", estado ? 1 : 0);
                                usuarioCommand.Parameters.AddWithValue("@legajo", legajo);
                                usuarioCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en UpdateEmpleado: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina (desactiva) un empleado
        /// </summary>
        public static bool DeleteEmpleado(int legajo)
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                    // Primero verificar si tiene usuario asociado
                    string checkQuery = "SELECT COUNT(*) FROM Usuario WHERE legajo = @legajo";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@legajo", legajo);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            throw new Exception("No se puede eliminar el empleado porque tiene un usuario asociado. Elimine primero el usuario.");
                        }
                    }
                    
                    // Si no tiene usuario, desactivar el empleado
                    string query = "UPDATE Empleado SET estado = 0 WHERE legajo = @legajo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@legajo", legajo);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en DeleteEmpleado: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un empleado por su legajo
        /// </summary>
        public static DataTable GetEmpleadoByLegajo(int legajo)
        {
            if (!connectionInitialized)
                InitializeConnection();

            DataTable dtEmpleado = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT legajo, nombre, apellido, nombre + ' ' + apellido AS nombre_completo, telefono, email, estado
                        FROM Empleado
                        WHERE legajo = @legajo";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@legajo", legajo);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dtEmpleado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en GetEmpleadoByLegajo: {ex.Message}");
            }
            return dtEmpleado;
        }

        public static bool UpdateHabitacion(int num_hab, int piso, int tipo, int estado)
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        UPDATE Habitacion 
                        SET id_tipo = @tipo, 
                            id_estado = @estado
                        WHERE numero_hab = @num_hab AND piso = @piso";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@num_hab", num_hab);
                        command.Parameters.AddWithValue("@piso", piso);
                        command.Parameters.AddWithValue("@tipo", tipo);
                        command.Parameters.AddWithValue("@estado", estado);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en UpdateHabitacion: {ex.Message}");
                return false;
            }
        }

        public static bool HabitacionExiste(int numero_hab)
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Habitacion WHERE numero_hab = @numero_hab";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@numero_hab", numero_hab);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar habitación: " + ex.Message);
                return true; // por seguridad, asumimos que existe si hay error
            }
        }

        public static bool ReservaExiste(int idReserva)
        {
            if (!connectionInitialized)
                InitializeConnection();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Reserva WHERE id_reserva = @idReserva";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idReserva", idReserva);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar reserva: " + ex.Message);
                return true; // por seguridad, asumimos que existe si hay error
            }
        }
    }
}
