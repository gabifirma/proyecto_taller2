using System;

namespace HotelCalifornia.Models
{
    /// <summary>
    /// Representa una reserva de habitación en el Hotel California.
    /// Contiene toda la información necesaria para gestionar las reservas de los clientes.
    /// </summary>
    public class Reserva
    {
        /// <summary>
        /// Identificador único de la reserva (ej: "R1", "R2", etc.)
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Nombre completo del cliente que realizó la reserva
        /// </summary>
        public string Cliente { get; set; }

        /// <summary>
        /// Fecha y hora de entrada (check-in) del huésped
        /// </summary>
        public DateTime FechaCheckIn { get; set; }

        /// <summary>
        /// Fecha y hora de salida (check-out) del huésped
        /// </summary>
        public DateTime FechaCheckOut { get; set; }

        /// <summary>
        /// Tipo de servicio o habitación reservada (Habitación Individual, Doble, Suite, etc.)
        /// </summary>
        public string Servicio { get; set; }

        /// <summary>
        /// Estado actual de la reserva (Confirmada, Pendiente, Anulada, Activa, etc.)
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Método de pago preferido para la reserva (Efectivo, Tarjeta, Transferencia, etc.)
        /// </summary>
        public string MetodoPago { get; set; }

        /// <summary>
        /// Número de huéspedes que se alojarán en la reserva
        /// </summary>
        public int CantidadHuespedes { get; set; }

        /// <summary>
        /// Monto estimado total de la reserva en pesos argentinos
        /// </summary>
        public decimal MontoEstimado { get; set; }

        /// <summary>
        /// Fecha y hora en que se creó la reserva en el sistema
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Constructor por defecto que inicializa la fecha de creación con la fecha actual
        /// </summary>
        public Reserva()
        {
            FechaCreacion = DateTime.Now;
        }

        /// <summary>
        /// Constructor completo para crear una reserva con todos sus datos
        /// </summary>
        /// <param name="id">Identificador único de la reserva</param>
        /// <param name="cliente">Nombre del cliente</param>
        /// <param name="fechaCheckIn">Fecha de entrada</param>
        /// <param name="fechaCheckOut">Fecha de salida</param>
        /// <param name="servicio">Tipo de habitación o servicio</param>
        /// <param name="estado">Estado de la reserva</param>
        /// <param name="metodoPago">Método de pago preferido</param>
        /// <param name="cantidadHuespedes">Número de huéspedes</param>
        /// <param name="montoEstimado">Monto total estimado</param>
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
