using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelCalifornia.Models;
using HotelCalifornia.Services;
using HotelCalifornia;

namespace Proyecto_Hotel_California
{
    public partial class Reservas : Form
    {
        private List<Reserva> reservasActuales;

        public Reservas()
        {
            InitializeComponent();
        }

        private void Reservas_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LoadReservas();
        }

        private void InitializeForm()
        {
            // Configurar fechas por defecto
            dtpFechaInicio.Value = DateTime.Now.AddDays(-30);
            dtpFechaFin.Value = DateTime.Now.AddDays(30);
            cmbEstado.SelectedIndex = 0; // "Todos"
            
            // Configurar DataGridView
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            GrillaReservas.AutoGenerateColumns = false;
            GrillaReservas.Columns.Clear();

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 60
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cliente",
                HeaderText = "Cliente",
                DataPropertyName = "Cliente",
                Width = 150
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaCheckIn",
                HeaderText = "Check-In",
                DataPropertyName = "FechaCheckIn",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 100
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaCheckOut",
                HeaderText = "Check-Out",
                DataPropertyName = "FechaCheckOut",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 100
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Servicio",
                HeaderText = "Servicio",
                DataPropertyName = "Servicio",
                Width = 120
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 80
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MontoEstimado",
                HeaderText = "Monto",
                DataPropertyName = "MontoEstimado",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });
        }

        private void LoadReservas()
        {
            try
            {
                reservasActuales = DataService.GetReservas();
                GrillaReservas.DataSource = reservasActuales;
                
                // Colorear filas según estado
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reservas: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var reservasFiltradas = DataService.FilterReservas(cliente, fechaInicio, fechaFin, estado);
                reservasActuales = reservasFiltradas;
                GrillaReservas.DataSource = reservasFiltradas;

                // Aplicar colores nuevamente
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

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Clear();
            dtpFechaInicio.Value = DateTime.Now.AddDays(-30);
            dtpFechaFin.Value = DateTime.Now.AddDays(30);
            cmbEstado.SelectedIndex = 0;
            LoadReservas();
        }

        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            try
            {
                CrearReservaForm crearForm = new CrearReservaForm();
                if (crearForm.ShowDialog() == DialogResult.OK)
                {
                    LoadReservas(); // Recargar la lista después de crear
                    MessageBox.Show("Reserva creada exitosamente.", "Éxito", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario de nueva reserva: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
