using System;
using System.Collections.Generic;
using System.Linq;
using HotelCalifornia.Models;

namespace HotelCalifornia.Services
{
    public static class DataService
    {
        private static List<Reserva> _reservas = new List<Reserva>();
        private static List<Pago> _pagos = new List<Pago>();
        private static bool _initialized = false;

        public static void InitializeData()
        {
            if (_initialized) return;

            // Inicializar reservas de ejemplo
            _reservas.AddRange(new List<Reserva>
            {
                new Reserva("R1", "Juan Pérez", new DateTime(2025, 9, 10), new DateTime(2025, 9, 12), 
                           "Habitación Doble", "Anulada", "Tarjeta", 2, 1200.00m),
                new Reserva("R2", "María Gómez", new DateTime(2025, 10, 5), new DateTime(2025, 10, 8), 
                           "Suite", "Confirmada", "Efectivo", 4, 4500.00m),
                new Reserva("R3", "Carlos Ruiz", new DateTime(2025, 11, 1), new DateTime(2025, 11, 3), 
                           "Habitación Individual", "Pendiente", "Transferencia", 1, 900.00m)
            });

            // Inicializar pagos de ejemplo
            _pagos.AddRange(new List<Pago>
            {
                new Pago("P1", "R1", new DateTime(2025, 9, 9), 1200.00m, "Tarjeta", "Reembolsado"),
                new Pago("P2", "R2", new DateTime(2025, 9, 30), 4500.00m, "Efectivo", "Confirmado"),
                new Pago("P3", "R3", new DateTime(2025, 10, 30), 900.00m, "Transferencia", "Pendiente")
            });

            _initialized = true;
        }

        // Métodos para Reservas
        public static List<Reserva> GetReservas()
        {
            InitializeData();
            return _reservas.ToList();
        }

        public static void AddReserva(Reserva reserva)
        {
            InitializeData();
            _reservas.Add(reserva);
        }

        public static void UpdateReserva(Reserva reserva)
        {
            InitializeData();
            var existing = _reservas.FirstOrDefault(r => r.Id == reserva.Id);
            if (existing != null)
            {
                var index = _reservas.IndexOf(existing);
                _reservas[index] = reserva;
            }
        }

        public static void DeleteReserva(string id)
        {
            InitializeData();
            _reservas.RemoveAll(r => r.Id == id);
        }

        public static Reserva GetReservaById(string id)
        {
            InitializeData();
            return _reservas.FirstOrDefault(r => r.Id == id);
        }

        public static List<Reserva> FilterReservas(string cliente = null, DateTime? fechaInicio = null, 
                                                  DateTime? fechaFin = null, string estado = null)
        {
            InitializeData();
            var query = _reservas.AsQueryable();

            if (!string.IsNullOrEmpty(cliente))
                query = query.Where(r => r.Cliente.ToLower().Contains(cliente.ToLower()));

            if (fechaInicio.HasValue)
                query = query.Where(r => r.FechaCheckIn >= fechaInicio.Value);

            if (fechaFin.HasValue)
                query = query.Where(r => r.FechaCheckOut <= fechaFin.Value);

            if (!string.IsNullOrEmpty(estado))
                query = query.Where(r => r.Estado == estado);

            return query.ToList();
        }

        // Métodos para Pagos
        public static List<Pago> GetPagos()
        {
            InitializeData();
            return _pagos.ToList();
        }

        public static void AddPago(Pago pago)
        {
            InitializeData();
            _pagos.Add(pago);
        }

        public static void UpdatePago(Pago pago)
        {
            InitializeData();
            var existing = _pagos.FirstOrDefault(p => p.Id == pago.Id);
            if (existing != null)
            {
                var index = _pagos.IndexOf(existing);
                _pagos[index] = pago;
            }
        }

        public static void DeletePago(string id)
        {
            InitializeData();
            _pagos.RemoveAll(p => p.Id == id);
        }

        public static List<Pago> GetPagosByReservaId(string reservaId)
        {
            InitializeData();
            return _pagos.Where(p => p.ReservaId == reservaId).ToList();
        }

        public static List<Pago> FilterPagos(string cliente = null, DateTime? fecha = null, 
                                           string estado = null, string metodoPago = null)
        {
            InitializeData();
            var query = _pagos.AsQueryable();

            if (!string.IsNullOrEmpty(cliente))
            {
                var reservasCliente = _reservas.Where(r => r.Cliente.ToLower().Contains(cliente.ToLower()))
                                              .Select(r => r.Id).ToList();
                query = query.Where(p => reservasCliente.Contains(p.ReservaId));
            }

            if (fecha.HasValue)
                query = query.Where(p => p.FechaPago.Date == fecha.Value.Date);

            if (!string.IsNullOrEmpty(estado))
                query = query.Where(p => p.Estado == estado);

            if (!string.IsNullOrEmpty(metodoPago))
                query = query.Where(p => p.MetodoPago == metodoPago);

            return query.ToList();
        }

        public static string GenerateReservaId()
        {
            InitializeData();
            int nextNumber = _reservas.Count + 1;
            while (_reservas.Any(r => r.Id == $"R{nextNumber}"))
            {
                nextNumber++;
            }
            return $"R{nextNumber}";
        }

        public static string GeneratePagoId()
        {
            InitializeData();
            int nextNumber = _pagos.Count + 1;
            while (_pagos.Any(p => p.Id == $"P{nextNumber}"))
            {
                nextNumber++;
            }
            return $"P{nextNumber}";
        }
    }
}
