using System;

namespace HotelCalifornia.Models
{
    public class Pago
    {
        public string Id { get; set; }
        public string ReservaId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        
        // Propiedades para eliminación lógica
        public bool Activo { get; set; }
        public DateTime? FechaDesactivacion { get; set; }
        public string MotivoDesactivacion { get; set; }

        public Pago()
        {
            FechaCreacion = DateTime.Now;
            Activo = true; // Por defecto activo
        }

        public Pago(string id, string reservaId, DateTime fechaPago, decimal monto, string metodoPago, string estado)
        {
            Id = id;
            ReservaId = reservaId;
            FechaPago = fechaPago;
            Monto = monto;
            MetodoPago = metodoPago;
            Estado = estado;
            FechaCreacion = DateTime.Now;
            Activo = true; // Por defecto activo
        }

        // Métodos para eliminación lógica
        public void Desactivar(string motivo)
        {
            Activo = false;
            FechaDesactivacion = DateTime.Now;
            MotivoDesactivacion = motivo;
        }

        public void Reactivar()
        {
            Activo = true;
            FechaDesactivacion = null;
            MotivoDesactivacion = null;
        }
    }
}
