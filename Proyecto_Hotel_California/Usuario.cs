using System;

namespace HotelCalifornia
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string TipoUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Usuario()
        {
            Activo = true;
            FechaCreacion = DateTime.Now;
        }

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