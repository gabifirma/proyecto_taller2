using System;

namespace HotelCalifornia.Models
{
    public class Reserva
    {
        public string Id { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaCheckIn { get; set; }
        public DateTime FechaCheckOut { get; set; }
        public string Servicio { get; set; }
        public string Estado { get; set; }
        public string MetodoPago { get; set; }
        public int CantidadHuespedes { get; set; }
        public decimal MontoEstimado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Reserva()
        {
            FechaCreacion = DateTime.Now;
        }

        public Reserva(string id, string cliente, DateTime fechaCheckIn, DateTime fechaCheckOut, 
                      string servicio, string estado, string metodoPago, int cantidadHuespedes, decimal montoEstimado)
        {
            Id = id;
            Cliente = cliente;
            FechaCheckIn = fechaCheckIn;
            FechaCheckOut = fechaCheckOut;
            Servicio = servicio;
            Estado = estado;
            MetodoPago = metodoPago;
            CantidadHuespedes = cantidadHuespedes;
            MontoEstimado = montoEstimado;
            FechaCreacion = DateTime.Now;
        }
    }
}
