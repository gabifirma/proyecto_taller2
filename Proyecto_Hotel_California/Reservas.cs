using HotelCalifornia.Models;
using HotelCalifornia.Services;
using HotelCalifornia.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelCalifornia
{
    public partial class Reservas : BaseResponsiveForm
    {
        private List<Reserva> reservasActuales;

        public Reservas()
        {
            InitializeComponent();
            // La clase base BaseResponsiveForm se encarga del responsive design automáticamente
            this.WindowState = FormWindowState.Maximized;
        }

        private void CargarReservas()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        R.id_reserva,
                        R.fecha_inicio,
                        R.fecha_fin,
                        C.nombre AS nombre_cliente,
                        C.apellido AS apellido_cliente,
                        H.numero_hab,
                        TH.nombre AS tipo_habitacion,
                        TH.capacidad,
                        RH.precio_noche,
                        RH.cantidad_noches,
                        RH.subtotal
                    FROM Reserva R
                    INNER JOIN Cliente C ON R.id_cliente = C.id_cliente
                    INNER JOIN ReservaHabitacion RH ON R.id_reserva = RH.id_reserva
                    INNER JOIN Habitacion H ON RH.numero_hab = H.numero_hab
                    INNER JOIN TipoHabitacion TH ON H.id_tipo = TH.id_tipo
                    ORDER BY R.id_reserva DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GrillaReservas.AutoGenerateColumns = true; // o configurala manualmente si querés formato
                GrillaReservas.DataSource = dt;
            }
        }

        private void ApplyRowColors()
        {
            foreach (DataGridViewRow row in GrillaReservas.Rows)
            {
                if (row.DataBoundItem is Reserva reserva)
                {
                    switch (reserva.Estado)
                    {
                        case "Confirmada":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "Pendiente":
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "Anulada":
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            break;
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                btnBuscar.Enabled = false;
                btnBuscar.Text = "Buscando...";

                string cliente = string.IsNullOrWhiteSpace(txtBuscarCliente.Text) ? null : txtBuscarCliente.Text.Trim();
                DateTime? fechaInicio = dtpFechaInicio.Checked ? dtpFechaInicio.Value : (DateTime?)null;
                DateTime? fechaFin = dtpFechaFin.Checked ? dtpFechaFin.Value : (DateTime?)null;
                string estado = cmbEstado.SelectedItem?.ToString();
                if (estado == "Todos") estado = null;

                // Usar el método de filtrado del DataService
                var reservasFiltradas = DataService.FilterReservas(cliente, fechaInicio, fechaFin, estado);
                GrillaReservas.DataSource = reservasFiltradas;

                // Aplicar colores nuevamente
                ApplyRowColors();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar reservas: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnBuscar.Enabled = true;
                btnBuscar.Text = "Buscar";
            }
        }

        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            CrearReservaForm frm = new CrearReservaForm();
            frm.ShowDialog();
        }

        private void btnVerPagos_Click(object sender, EventArgs e)
        {
            if (GrillaReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una reserva para ver sus pagos.", "Información", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var reservaSeleccionada = (Reserva)GrillaReservas.SelectedRows[0].DataBoundItem;
                
                // Obtener pagos reales usando DataService
                var pagos = DataService.GetPagosByReservaId(reservaSeleccionada.Id);

                string mensaje = $"Pagos para la reserva {reservaSeleccionada.Id} - {reservaSeleccionada.Cliente}:\n\n";
                
                if (pagos.Count == 0)
                {
                    mensaje += "No hay pagos registrados para esta reserva.";
                }
                else
                {
                    foreach (var pago in pagos)
                    {
                        mensaje += $"• ID: {pago.Id} | Fecha: {pago.FechaPago:dd/MM/yyyy} | " +
                                 $"Monto: {pago.Monto:C2} | Método: {pago.MetodoPago} | Estado: {pago.Estado}\n";
                    }
                }

                MessageBox.Show(mensaje, "Pagos de la Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener pagos: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrillaReservas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnVerPagos_Click(sender, e);
            }
        }

        private void Reservas_Load(object sender, EventArgs e)
        {
            CargarReservas();
        }
    }
}
