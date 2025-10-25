using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCalifornia
{
    internal class ModeloFactura
    {
        public class FacturaData
        {
            public string Numero { get; set; }
            public DateTime FechaEmision { get; set; }
            public string Cliente { get; set; }
            public string DNI { get; set; }
            public string Email { get; set; }
            public string MetodoPago { get; set; }
            public decimal Total { get; set; }
        }

        public class DetalleReserva
        {
            public string Habitacion { get; set; }
            public string TipoHabitacion { get; set; }
            public int Noches { get; set; }
            public decimal PrecioPorNoche { get; set; }
            public decimal Subtotal { get; set; }
        }

        public class DetalleServicio
        {
            public string Servicio { get; set; }
            public decimal Precio { get; set; }
        }

        public class FacturaCompleta
        {
            public FacturaData Factura { get; set; }
            public List<DetalleReserva> Habitaciones { get; set; } = new List<DetalleReserva>();
            public List<DetalleServicio> Servicios { get; set; } = new List<DetalleServicio>();
        }

    }
}
