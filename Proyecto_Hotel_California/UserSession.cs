using System;

namespace HotelCalifornia
{
    public static class UserSession
    {
        public static Usuario CurrentUser { get; set; }
        public static bool IsLoggedIn { get { return CurrentUser != null; } }

        public static void Login(Usuario usuario)
        {
            CurrentUser = usuario;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static bool HasPermission(string requiredRole)
        {
            if (!IsLoggedIn) return false;

            switch (requiredRole.ToLower())
            {
                case "administrador":
                    return CurrentUser.TipoUsuario == "Administrador";
                case "supervisor":
                    return CurrentUser.TipoUsuario == "Administrador" || CurrentUser.TipoUsuario == "Supervisor";
                case "recepcionista":
                    return CurrentUser.TipoUsuario == "Administrador" || 
                           CurrentUser.TipoUsuario == "Supervisor" || 
                           CurrentUser.TipoUsuario == "Recepcionista";
                default:
                    return false;
            }
        }

        public static string GetUserDisplayName()
        {
            return IsLoggedIn ? CurrentUser.NombreCompleto : "Usuario no autenticado";
        }

        public static string GetUserRole()
        {
            return IsLoggedIn ? CurrentUser.TipoUsuario : "Sin rol";
        }
    }
}