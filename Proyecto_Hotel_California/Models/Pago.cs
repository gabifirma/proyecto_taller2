using System;

namespace HotelCalifornia.Models
{
    /// <summary>
    /// Representa un pago realizado por un cliente en el sistema del hotel.
    /// Esta clase contiene toda la información relacionada con los pagos de reservas.
    /// </summary>
    public class Pago
    {
        /// <summary>
        /// Identificador único del pago (ej: "P1", "P2", etc.)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador de la reserva asociada a este pago
        /// </summary>
        public string ReservaId { get; set; }

        /// <summary>
        /// Fecha en la que se realizó el pago
        /// </summary>
        public DateTime FechaPago { get; set; }

        /// <summary>
        /// Monto del pago en pesos argentinos
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Método de pago utilizado (Efectivo, Tarjeta, Transferencia, etc.)
        /// </summary>
        public string MetodoPago { get; set; }

        /// <summary>
        /// Estado actual del pago (Confirmado, Pendiente, Reembolsado, etc.)
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Fecha y hora en que se creó el registro del pago en el sistema
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Constructor por defecto que inicializa la fecha de creación con la fecha actual
        /// </summary>
        public Pago()
        {
            FechaCreacion = DateTime.Now;
        }

        /// <summary>
        /// Constructor completo para crear un pago con todos sus datos
        /// </summary>
        /// <param name="id">Identificador único del pago</param>
        /// <param name="reservaId">ID de la reserva asociada</param>
        /// <param name="fechaPago">Fecha del pago</param>
        /// <param name="monto">Monto pagado</param>
        /// <param name="metodoPago">Método de pago utilizado</param>
        /// <param name="estado">Estado del pago</param>
        public Pago(string id, string reservaId, DateTime fechaPago, decimal monto, string metodoPago, string estado)
        {
            Id = id;
            ReservaId = reservaId;
            FechaPago = fechaPago;
            Monto = monto;
            MetodoPago = metodoPago;
            Estado = estado;
            FechaCreacion = DateTime.Now;
        }
    }
}
