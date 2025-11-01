using System;

namespace HotelCalifornia
{
    /// <summary>
    /// Clase estática que maneja la sesión del usuario actual en el sistema.
    /// Proporciona funcionalidades de autenticación, autorización y gestión de sesión.
    /// </summary>
    public static class UserSession
    {
        /// <summary>
        /// Usuario actualmente autenticado en el sistema
        /// </summary>
        public static Usuario CurrentUser { get; set; }

        /// <summary>
        /// Indica si hay un usuario autenticado en el sistema
        /// </summary>
        public static bool IsLoggedIn { get { return CurrentUser != null; } }

        /// <summary>
        /// Inicia sesión con el usuario especificado
        /// </summary>
        /// <param name="usuario">Usuario que inicia sesión</param>
        public static void Login(Usuario usuario)
        {
            CurrentUser = usuario;
        }

        /// <summary>
        /// Cierra la sesión actual limpiando los datos del usuario
        /// </summary>
        public static void Logout()
        {
            CurrentUser = null;
        }

        /// <summary>
        /// Verifica si el usuario actual tiene permisos para un rol específico.
        /// Implementa un sistema jerárquico donde roles superiores incluyen permisos de roles inferiores.
        /// </summary>
        /// <param name="requiredRole">Rol mínimo requerido (administrador, supervisor, recepcionista)</param>
        /// <returns>True si el usuario tiene los permisos necesarios</returns>
        public static bool HasPermission(string requiredRole)
        {
            if (!IsLoggedIn) return false;

            switch (requiredRole.ToLower())
            {
                case "administrador":
                    // Solo administradores tienen este nivel de acceso
                    return CurrentUser.TipoUsuario == "Administrador";
                case "supervisor":
                    // Administradores y supervisores tienen este acceso
                    return CurrentUser.TipoUsuario == "Administrador" || CurrentUser.TipoUsuario == "Supervisor";
                case "recepcionista":
                    // Todos los roles tienen al menos permisos de recepcionista
                    return CurrentUser.TipoUsuario == "Administrador" || 
                           CurrentUser.TipoUsuario == "Supervisor" || 
                           CurrentUser.TipoUsuario == "Recepcionista";
                default:
                    return false;
            }
        }

        /// <summary>
        /// Obtiene el nombre completo del usuario actual para mostrar en la interfaz
        /// </summary>
        /// <returns>Nombre completo del usuario o mensaje por defecto si no está autenticado</returns>
        public static string GetUserDisplayName()
        {
            return IsLoggedIn ? CurrentUser.NombreCompleto : "Usuario no autenticado";
        }

        /// <summary>
        /// Obtiene el rol del usuario actual
        /// </summary>
        /// <returns>Tipo de usuario o mensaje por defecto si no está autenticado</returns>
        public static string GetUserRole()
        {
            return IsLoggedIn ? CurrentUser.TipoUsuario : "Sin rol";
        }

        /// <summary>
        /// Obtiene el legajo del usuario actual
        /// </summary>
        /// <returns>Legajo de usuario o mensaje por defecto si no está autenticado</returns>
        public static string GetUserLegajo()
        {
            if (!IsLoggedIn || CurrentUser.Legajo == null)
            {
                return "Sin rol";
            }
            else
            {
                return CurrentUser.Legajo.Value.ToString();
            }            
        }
    }
}