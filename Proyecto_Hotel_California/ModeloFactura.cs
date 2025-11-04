using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCalifornia
{
    /// <summary>
    /// Contiene las clases modelo utilizadas para estructurar la información
    /// necesaria para generar una factura en PDF.
    /// </summary>
    internal class ModeloFactura
    {
        /// <summary>
        /// Almacena los datos principales de la cabecera de la factura.
        /// </summary>
        public class FacturaData
        {
            /// <summary>
            /// Número de factura (ej. R100001).
            /// </summary>
            public string Numero { get; set; }
            /// <summary>
            /// Fecha en que se emite el pago/factura.
            /// </summary>
            public DateTime FechaEmision { get; set; }
            /// <summary>
            /// Nombre completo del cliente.
            /// </summary>
            public string Cliente { get; set; }
            /// <summary>
            /// DNI del cliente.
            /// </summary>
            public string DNI { get; set; }
            /// <summary>
            /// Email de contacto del cliente.
            /// </summary>
            public string Email { get; set; }
            /// <summary>
            /// Método de pago utilizado (Ej. "Efectivo", "Tarjeta de Crédito").
            /// </summary>
            public string MetodoPago { get; set; }
            /// <summary>
            /// Monto total final de la factura.
            /// </summary>
            public decimal Total { get; set; }
        }

        /// <summary>
        /// Representa una línea de detalle para una habitación en la factura.
        /// </summary>
        public class DetalleReserva
        {
            /// <summary>
            /// Número de la habitación (ej. "101").
            /// </summary>
            public string Habitacion { get; set; }
            /// <summary>
            /// Tipo de habitación (ej. "Single", "Doble").
            /// </summary>
            public string TipoHabitacion { get; set; }
            /// <summary>
            /// Cantidad de noches de la estadía.
            /// </summary>
            public int Noches { get; set; }
            /// <summary>
            /// Costo por una noche.
            /// </summary>
            public decimal PrecioPorNoche { get; set; }
            /// <summary>
            /// Cálculo (Noches * PrecioPorNoche).
            /// </summary>
            public decimal Subtotal { get; set; }
        }

        /// <summary>
        /// Representa una línea de detalle para un servicio adicional (ej. Minibar).
        /// </summary>
        public class DetalleServicio
        {
            /// <summary>
            /// Nombre del servicio.
            /// </summary>
            public string Servicio { get; set; }
            /// <summary>
            /// Costo total del servicio.
            /// </summary>
            public decimal Precio { get; set; }
        }

        /// <summary>
        /// Clase principal que agrupa toda la información de la factura.
        /// </summary>
        public class FacturaCompleta
        {
            /// <summary>
            /// Contiene los datos de la cabecera.
            /// </summary>
            public FacturaData Factura { get; set; }
            /// <summary>
            /// Lista de todas las habitaciones incluidas en la factura.
            /// </summary>
            public List<DetalleReserva> Habitaciones { get; set; } = new List<DetalleReserva>();
            /// <summary>
            /// Lista de todos los servicios adicionales en la factura.
            /// </summary>
            public List<DetalleServicio> Servicios { get; set; } = new List<DetalleServicio>();
        }

    }
}
