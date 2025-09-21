using System;
using System.Collections.Generic;
using System.Linq;
using HotelCalifornia.Models;
using System.Globalization;
using System.Text;

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

            // Inicializar reservas de ejemplo con más datos
            _reservas.AddRange(new List<Reserva>
            {
                // Reservas originales
                new Reserva("RES-001", "Juan Pérez", DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-7), 
                           "Habitación Doble", "Confirmada", "Tarjeta", 2, 450.00m),
                new Reserva("RES-002", "María García", DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-2), 
                           "Suite Presidencial", "Confirmada", "Efectivo", 4, 1200.00m),
                new Reserva("RES-003", "Carlos López", DateTime.Now.AddDays(2), DateTime.Now.AddDays(5), 
                           "Habitación Simple", "Pendiente", "Transferencia", 1, 300.00m),

                // Reservas adicionales para testing
                new Reserva("RES-004", "Ana Martínez", DateTime.Now.AddDays(-15), DateTime.Now.AddDays(-12), 
                           "Habitación Doble", "Anulada", "Tarjeta", 2, 450.00m),
                new Reserva("RES-005", "Roberto Silva", DateTime.Now.AddDays(7), DateTime.Now.AddDays(10), 
                           "Suite Junior", "Confirmada", "Tarjeta", 3, 800.00m),
                new Reserva("RES-006", "Laura Fernández", DateTime.Now.AddDays(-3), DateTime.Now, 
                           "Habitación Doble", "Confirmada", "Efectivo", 2, 450.00m),
                new Reserva("RES-007", "Diego Morales", DateTime.Now.AddDays(15), DateTime.Now.AddDays(18), 
                           "Habitación Simple", "Pendiente", "Transferencia", 1, 300.00m),
                new Reserva("RES-008", "Carmen Ruiz", DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-17), 
                           "Suite Presidencial", "Anulada", "Tarjeta", 4, 1200.00m),
                new Reserva("RES-009", "Fernando Castro", DateTime.Now.AddDays(1), DateTime.Now.AddDays(4), 
                           "Habitación Doble", "Confirmada", "Tarjeta", 2, 450.00m),
                new Reserva("RES-010", "Patricia Herrera", DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-5), 
                           "Suite Junior", "Confirmada", "Efectivo", 3, 800.00m)
            });

            // Desactivar algunas reservas para testing
            _reservas[3].Desactivar("Cancelada por cliente"); // RES-004
            _reservas[7].Desactivar("Cancelada por cliente"); // RES-008

            // Inicializar pagos de ejemplo con más datos
            _pagos.AddRange(new List<Pago>
            {
                new Pago("PAG-001", "RES-001", DateTime.Now.AddDays(-9), 450.00m, "Tarjeta", "Confirmado"),
                new Pago("PAG-002", "RES-002", DateTime.Now.AddDays(-4), 1200.00m, "Efectivo", "Confirmado"),
                new Pago("PAG-003", "RES-003", DateTime.Now.AddDays(1), 150.00m, "Transferencia", "Pendiente"),
                new Pago("PAG-004", "RES-004", DateTime.Now.AddDays(-14), 450.00m, "Tarjeta", "Reembolsado"),
                new Pago("PAG-005", "RES-005", DateTime.Now.AddDays(6), 400.00m, "Tarjeta", "Pendiente"),
                new Pago("PAG-006", "RES-006", DateTime.Now.AddDays(-2), 450.00m, "Efectivo", "Confirmado"),
                new Pago("PAG-007", "RES-007", DateTime.Now.AddDays(14), 100.00m, "Transferencia", "Pendiente"),
                new Pago("PAG-008", "RES-008", DateTime.Now.AddDays(-19), 1200.00m, "Tarjeta", "Reembolsado"),
                new Pago("PAG-009", "RES-009", DateTime.Now, 225.00m, "Tarjeta", "Confirmado"),
                new Pago("PAG-010", "RES-010", DateTime.Now.AddDays(-7), 800.00m, "Efectivo", "Confirmado")
            });

            // Desactivar algunos pagos para testing
            _pagos[3].Desactivar("Reembolso procesado"); // PAG-004
            _pagos[7].Desactivar("Reembolso procesado"); // PAG-008

            _initialized = true;
        }

        // Método auxiliar para normalizar strings (quitar acentos y convertir a minúsculas)
        private static string NormalizarString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Normalizar para separar los caracteres base de los diacríticos
            string normalized = input.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalized)
            {
                // Solo incluir caracteres que no son diacríticos (categoria diferente a NonSpacingMark)
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().ToLowerInvariant();
        }

        // Métodos para Reservas
        public static List<Reserva> GetReservas()
        {
            InitializeData();
            return _reservas.Where(r => r.Activo).ToList(); // Solo activos por defecto
        }

        public static List<Reserva> GetReservas(bool soloActivos)
        {
            InitializeData();
            if (soloActivos)
                return _reservas.Where(r => r.Activo).ToList();
            else
                return _reservas.ToList(); // Todos los registros
        }

        public static List<Reserva> GetReservasActivas()
        {
            InitializeData();
            return _reservas.Where(r => r.Activo).ToList();
        }

        public static List<Reserva> GetReservasInactivas()
        {
            InitializeData();
            return _reservas.Where(r => !r.Activo).ToList();
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

        // Métodos de eliminación lógica para Reservas
        public static void DesactivarReserva(string id, string motivo)
        {
            InitializeData();
            var reserva = _reservas.FirstOrDefault(r => r.Id == id);
            if (reserva != null)
            {
                reserva.Desactivar(motivo);
            }
        }

        public static void ReactivarReserva(string id)
        {
            InitializeData();
            var reserva = _reservas.FirstOrDefault(r => r.Id == id);
            if (reserva != null)
            {
                reserva.Reactivar();
            }
        }

        public static Reserva GetReservaById(string id)
        {
            InitializeData();
            return _reservas.FirstOrDefault(r => r.Id == id);
        }

        public static List<Reserva> FilterReservas(string cliente = null, DateTime? fechaInicio = null, 
                                                  DateTime? fechaFin = null, string estado = null)
        {
            return FilterReservas(cliente, fechaInicio, fechaFin, estado, true); // Solo activos por defecto
        }

        public static List<Reserva> FilterReservas(string cliente = null, DateTime? fechaInicio = null, 
                                                  DateTime? fechaFin = null, string estado = null, bool soloActivos = true)
        {
            InitializeData();
            var query = _reservas.AsQueryable();

            // Filtrar por estado de activación
            if (soloActivos)
                query = query.Where(r => r.Activo);

            if (!string.IsNullOrEmpty(cliente))
            {
                string clienteNormalizado = NormalizarString(cliente);
                query = query.Where(r => NormalizarString(r.Cliente).Contains(clienteNormalizado));
            }

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
            return _pagos.Where(p => p.Activo).ToList(); // Solo activos por defecto
        }

        public static List<Pago> GetPagos(bool soloActivos)
        {
            InitializeData();
            if (soloActivos)
                return _pagos.Where(p => p.Activo).ToList();
            else
                return _pagos.ToList(); // Todos los registros
        }

        public static List<Pago> GetPagosActivos()
        {
            InitializeData();
            return _pagos.Where(p => p.Activo).ToList();
        }

        public static List<Pago> GetPagosInactivos()
        {
            InitializeData();
            return _pagos.Where(p => !p.Activo).ToList();
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

        public static Pago GetPagoById(string id)
        {
            InitializeData();
            return _pagos.FirstOrDefault(p => p.Id == id);
        }

        // Métodos de eliminación lógica para Pagos
        public static void DesactivarPago(string id, string motivo)
        {
            InitializeData();
            var pago = _pagos.FirstOrDefault(p => p.Id == id);
            if (pago != null)
            {
                pago.Desactivar(motivo);
            }
        }

        public static void ReactivarPago(string id)
        {
            InitializeData();
            var pago = _pagos.FirstOrDefault(p => p.Id == id);
            if (pago != null)
            {
                pago.Reactivar();
            }
        }

        public static List<Pago> GetPagosByReservaId(string reservaId)
        {
            InitializeData();
            return _pagos.Where(p => p.ReservaId == reservaId && p.Activo).ToList(); // Solo activos por defecto
        }

        public static List<Pago> GetPagosByReservaId(string reservaId, bool soloActivos)
        {
            InitializeData();
            if (soloActivos)
                return _pagos.Where(p => p.ReservaId == reservaId && p.Activo).ToList();
            else
                return _pagos.Where(p => p.ReservaId == reservaId).ToList(); // Todos los registros
        }

        public static List<Pago> FilterPagos(string cliente = null, DateTime? fecha = null, 
                                           string estado = null, string metodoPago = null)
        {
            return FilterPagos(cliente, fecha, estado, metodoPago, true); // Solo activos por defecto
        }

        public static List<Pago> FilterPagos(string cliente = null, DateTime? fecha = null, 
                                           string estado = null, string metodoPago = null, bool soloActivos = true)
        {
            InitializeData();
            var query = _pagos.AsQueryable();

            // Filtrar por estado de activación
            if (soloActivos)
                query = query.Where(p => p.Activo);

            if (!string.IsNullOrEmpty(cliente))
            {
                string clienteNormalizado = NormalizarString(cliente);
                var reservasCliente = _reservas.Where(r => NormalizarString(r.Cliente).Contains(clienteNormalizado))
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
