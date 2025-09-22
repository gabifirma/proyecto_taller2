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
using HotelCalifornia.Styles;

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

        private void Reservas_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LoadReservas();
        }

        private void Reservas_Resize(object sender, EventArgs e)
        {
            AdjustControlsForResize();
        }

        private void AdjustControlsForResize()
        {
            if (this.WindowState == FormWindowState.Minimized) return;

            // Ajustar el título
            LTituloReservas.Left = (this.ClientSize.Width - LTituloReservas.Width) / 2;

            // Ajustar el grupo de filtros
            groupBoxFiltros.Width = this.ClientSize.Width - 40;

            // Ajustar la grilla
            GrillaReservas.Width = this.ClientSize.Width - 24;
            GrillaReservas.Height = this.ClientSize.Height - GrillaReservas.Top - 80;

            // Ajustar botones
            int buttonY = this.ClientSize.Height - 60;
            btnNuevaReserva.Top = buttonY;
            btnVerPagos.Top = buttonY;
            btnVerPagos.Left = this.ClientSize.Width - btnVerPagos.Width - 20;
        }

        private void InitializeForm()
        {
            // Configurar fechas por defecto
            dtpFechaInicio.Value = DateTime.Now.AddDays(-30);
            dtpFechaFin.Value = DateTime.Now.AddDays(30);
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[] { "Todos", "Confirmada", "Pendiente", "Anulada" });
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
                Width = 80
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
                Name = "Num_hab_tipo",
                HeaderText = "Nro. Habitación (Tipo)",
                DataPropertyName = "Servicio",
                Width = 120
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 100
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MetodoPago",
                HeaderText = "Método Pago",
                DataPropertyName = "MetodoPago",
                Width = 100
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CantidadHuespedes",
                HeaderText = "Huéspedes",
                DataPropertyName = "CantidadHuespedes",
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

            // Configurar para redimensionamiento automático
            GrillaReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadReservas()
        {
            try
            {
                // Usar DataService para obtener las reservas
                reservasActuales = DataService.GetReservas();
                GrillaReservas.DataSource = reservasActuales;
                
                // Colorear filas según estado
                ApplyRowColors();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reservas: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Clear();
            dtpFechaInicio.Value = DateTime.Now.AddDays(-30);
            dtpFechaFin.Value = DateTime.Now.AddDays(30);
            dtpFechaInicio.Checked = false;
            dtpFechaFin.Checked = false;
            cmbEstado.SelectedIndex = 0;
            LoadReservas();
        }

        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir el formulario de crear reserva
                using (var crearReservaForm = new CrearReservaForm())
                {
                    if (crearReservaForm.ShowDialog() == DialogResult.OK)
                    {
                        // Recargar las reservas después de crear una nueva
                        LoadReservas();
                        MessageBox.Show("Reserva creada exitosamente.", "Éxito", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
    }
}
