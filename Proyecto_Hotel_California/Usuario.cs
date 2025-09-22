using System;

namespace HotelCalifornia
{
    /// <summary>
    /// Representa un usuario del sistema de gestión del Hotel California.
    /// Contiene la información de autenticación y autorización de los empleados.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador único del usuario en la base de datos
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de usuario utilizado para el login (debe ser único)
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Contraseña del usuario (almacenada en texto plano - considerar encriptación en producción)
        /// </summary>
        public string Contraseña { get; set; }

        /// <summary>
        /// Tipo de usuario que determina los permisos (Administrador, Supervisor, Recepcionista)
        /// </summary>
        public string TipoUsuario { get; set; }

        /// <summary>
        /// Nombre completo del usuario para mostrar en la interfaz
        /// </summary>
        public string NombreCompleto { get; set; }

        /// <summary>
        /// Indica si el usuario está activo y puede acceder al sistema
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Fecha y hora en que se creó la cuenta del usuario
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Constructor por defecto que inicializa el usuario como activo con la fecha actual
        /// </summary>
        public Usuario()
        {
            Activo = true;
            FechaCreacion = DateTime.Now;
        }

        /// <summary>
        /// Constructor para crear un usuario con los datos básicos
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario para login</param>
        /// <param name="contraseña">Contraseña del usuario</param>
        /// <param name="tipoUsuario">Tipo de usuario (rol)</param>
        /// <param name="nombreCompleto">Nombre completo del usuario</param>
        public Usuario(string nombreUsuario, string contraseña, string tipoUsuario, string nombreCompleto)
        {
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            TipoUsuario = tipoUsuario;
            NombreCompleto = nombreCompleto;
            Activo = true;
            FechaCreacion = DateTime.Now;
        }
    }
}