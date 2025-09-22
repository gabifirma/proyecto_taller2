using System;
using System.Collections.Generic;
using System.Linq;
using HotelCalifornia.Models;

namespace HotelCalifornia.Services
{
    /// <summary>
    /// Servicio de datos que maneja las operaciones CRUD para reservas y pagos.
    /// Utiliza listas en memoria para almacenar los datos de forma temporal.
    /// En una implementación de producción, esto debería conectarse a una base de datos.
    /// </summary>
    public static class DataService
    {
        // Listas privadas que actúan como almacenamiento en memoria
        private static List<Reserva> _reservas = new List<Reserva>();
        private static List<Pago> _pagos = new List<Pago>();
        private static bool _initialized = false;

        /// <summary>
        /// Inicializa el servicio de datos con información de ejemplo.
        /// Solo se ejecuta una vez para evitar duplicar los datos.
        /// </summary>
        public static void InitializeData()
        {
            if (_initialized) return;

            // Inicializar reservas de ejemplo para demostración
            _reservas.AddRange(new List<Reserva>
            {
                new Reserva("R1", "Juan Pérez", new DateTime(2025, 9, 10), new DateTime(2025, 9, 12), 
                           "Habitación Doble", "Anulada", "Tarjeta", 2, 1200.00m),
                new Reserva("R2", "María Gómez", new DateTime(2025, 10, 5), new DateTime(2025, 10, 8), 
                           "Suite", "Confirmada", "Efectivo", 4, 4500.00m),
                new Reserva("R3", "Carlos Ruiz", new DateTime(2025, 11, 1), new DateTime(2025, 11, 3), 
                           "Habitación Individual", "Pendiente", "Transferencia", 1, 900.00m)
            });

            // Inicializar pagos de ejemplo correspondientes a las reservas
            _pagos.AddRange(new List<Pago>
            {
                new Pago("P1", "R1", new DateTime(2025, 9, 9), 1200.00m, "Tarjeta", "Reembolsado"),
                new Pago("P2", "R2", new DateTime(2025, 9, 30), 4500.00m, "Efectivo", "Confirmado"),
                new Pago("P3", "R3", new DateTime(2025, 10, 30), 900.00m, "Transferencia", "Pendiente")
            });

            _initialized = true;
        }

        #region Métodos para Reservas

        /// <summary>
        /// Obtiene todas las reservas almacenadas en el sistema
        /// </summary>
        /// <returns>Lista completa de reservas</returns>
        public static List<Reserva> GetReservas()
        {
            InitializeData();
            return _reservas.ToList();
        }

        /// <summary>
        /// Agrega una nueva reserva al sistema
        /// </summary>
        /// <param name="reserva">Reserva a agregar</param>
        public static void AddReserva(Reserva reserva)
        {
            InitializeData();
            _reservas.Add(reserva);
        }

        /// <summary>
        /// Actualiza una reserva existente en el sistema
        /// </summary>
        /// <param name="reserva">Reserva con los datos actualizados</param>
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

        /// <summary>
        /// Elimina una reserva del sistema por su ID
        /// </summary>
        /// <param name="id">ID de la reserva a eliminar</param>
        public static void DeleteReserva(string id)
        {
            InitializeData();
            _reservas.RemoveAll(r => r.Id == id);
        }

        /// <summary>
        /// Busca una reserva específica por su ID
        /// </summary>
        /// <param name="id">ID de la reserva a buscar</param>
        /// <returns>La reserva encontrada o null si no existe</returns>
        public static Reserva GetReservaById(string id)
        {
            InitializeData();
            return _reservas.FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Filtra las reservas según los criterios especificados
        /// </summary>
        /// <param name="cliente">Nombre del cliente a buscar (búsqueda parcial)</param>
        /// <param name="fechaInicio">Fecha mínima de check-in</param>
        /// <param name="fechaFin">Fecha máxima de check-out</param>
        /// <param name="estado">Estado específico de la reserva</param>
        /// <returns>Lista de reservas que cumplen con los criterios</returns>
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

        #endregion

        #region Métodos para Pagos

        /// <summary>
        /// Obtiene todos los pagos almacenados en el sistema
        /// </summary>
        /// <returns>Lista completa de pagos</returns>
        public static List<Pago> GetPagos()
        {
            InitializeData();
            return _pagos.ToList();
        }

        /// <summary>
        /// Agrega un nuevo pago al sistema
        /// </summary>
        /// <param name="pago">Pago a agregar</param>
        public static void AddPago(Pago pago)
        {
            InitializeData();
            _pagos.Add(pago);
        }

        /// <summary>
        /// Actualiza un pago existente en el sistema
        /// </summary>
        /// <param name="pago">Pago con los datos actualizados</param>
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

        /// <summary>
        /// Elimina un pago del sistema por su ID
        /// </summary>
        /// <param name="id">ID del pago a eliminar</param>
        public static void DeletePago(string id)
        {
            InitializeData();
            _pagos.RemoveAll(p => p.Id == id);
        }

        /// <summary>
        /// Obtiene todos los pagos asociados a una reserva específica
        /// </summary>
        /// <param name="reservaId">ID de la reserva</param>
        /// <returns>Lista de pagos de la reserva</returns>
        public static List<Pago> GetPagosByReservaId(string reservaId)
        {
            InitializeData();
            return _pagos.Where(p => p.ReservaId == reservaId).ToList();
        }

        /// <summary>
        /// Filtra los pagos según los criterios especificados
        /// </summary>
        /// <param name="cliente">Nombre del cliente a buscar (búsqueda parcial)</param>
        /// <param name="fecha">Fecha específica del pago</param>
        /// <param name="estado">Estado específico del pago</param>
        /// <param name="metodoPago">Método de pago específico</param>
        /// <returns>Lista de pagos que cumplen con los criterios</returns>
        public static List<Pago> FilterPagos(string cliente = null, DateTime? fecha = null, 
                                           string estado = null, string metodoPago = null)
        {
            InitializeData();
            var query = _pagos.AsQueryable();

            if (!string.IsNullOrEmpty(cliente))
            {
                // Buscar reservas del cliente y filtrar pagos por esas reservas
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

        #endregion

        #region Métodos de Utilidad

        /// <summary>
        /// Genera un nuevo ID único para una reserva
        /// </summary>
        /// <returns>ID de reserva en formato "R{número}"</returns>
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

        /// <summary>
        /// Genera un nuevo ID único para un pago
        /// </summary>
        /// <returns>ID de pago en formato "P{número}"</returns>
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

        #endregion
    }
}
