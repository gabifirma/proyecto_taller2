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
            dtpFechaInicio.Checked = false;
            dtpFechaFin.Checked = false;
            
            // Configurar ComboBox de Estado
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[] { "Todos", "Confirmada", "Pendiente", "Anulada" });
            cmbEstado.SelectedIndex = 0; // "Todos"
            
            // Configurar ComboBox de Estado de Activación
            cmbEstadoActivacion.Items.Clear();
            cmbEstadoActivacion.Items.AddRange(new string[] { "Todos", "Activos", "Inactivos" });
            cmbEstadoActivacion.SelectedIndex = 0; // "Todos"
            
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
                Width = 80,
                ReadOnly = true
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cliente",
                HeaderText = "Cliente",
                DataPropertyName = "Cliente",
                Width = 150,
                ReadOnly = true
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Servicio",
                HeaderText = "Servicio",
                DataPropertyName = "Servicio",
                Width = 120,
                ReadOnly = true
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 100,
                ReadOnly = true
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MetodoPago",
                HeaderText = "Método Pago",
                DataPropertyName = "MetodoPago",
                Width = 100,
                ReadOnly = true
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CantidadHuespedes",
                HeaderText = "Huéspedes",
                DataPropertyName = "CantidadHuespedes",
                Width = 80,
                ReadOnly = true
            });

            GrillaReservas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MontoEstimado",
                HeaderText = "Monto",
                DataPropertyName = "MontoEstimado",
                Width = 100,
                ReadOnly = true
            });

            // Checkbox para estado activo/inactivo
            GrillaReservas.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Activo",
                HeaderText = "Activo",
                DataPropertyName = "Activo",
                Width = 60,
                ReadOnly = false // Permitir edición directa
            });

            // Botón de editar
            var btnEditar = new DataGridViewButtonColumn
            {
                Name = "btnEditar",
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            GrillaReservas.Columns.Add(btnEditar);

            // Botón de eliminar (toggle activo/inactivo)
            var btnEliminar = new DataGridViewButtonColumn
            {
                Name = "btnEliminar",
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            GrillaReservas.Columns.Add(btnEliminar);

            GrillaReservas.CellContentClick += GrillaReservas_CellContentClick;
        }

        private void LoadReservas()
        {
            try
            {
                // Usar DataService para obtener TODAS las reservas (activas e inactivas)
                reservasActuales = DataService.GetReservas(false);
                
                // Crear lista con información de estado de activación
                var reservasConEstado = reservasActuales.Select(r => new
                {
                    r.Id,
                    r.Cliente,
                    r.FechaCheckIn,
                    r.FechaCheckOut,
                    r.Servicio,
                    r.Estado,
                    r.MetodoPago,
                    r.CantidadHuespedes,
                    r.MontoEstimado,
                    r.Activo
                }).ToList();
                
                GrillaReservas.DataSource = reservasConEstado;
                
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
                if (row.Cells["Estado"].Value != null)
                {
                    string estado = row.Cells["Estado"].Value.ToString();
                    bool activo = row.Cells["Activo"].Value != null && (bool)row.Cells["Activo"].Value;
                    
                    // Aplicar color base según estado
                    switch (estado)
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
                    
                    // Si está inactivo, aplicar un tono más gris
                    if (!activo)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Gray;
                        row.DefaultCellStyle.BackColor = Color.LightGray;
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

                // Leer el filtro de estado de activación
                string estadoActivacion = cmbEstadoActivacion.SelectedItem?.ToString();
                bool soloActivos = true;

                if (estadoActivacion == "Todos")
                    soloActivos = false;
                else if (estadoActivacion == "Inactivos")
                    soloActivos = false; // Para luego filtrar solo los inactivos

                // Usar el método de filtrado del DataService
                var reservasFiltradas = DataService.FilterReservas(cliente, fechaInicio, fechaFin, estado, soloActivos);

                // Si se seleccionó "Inactivos", filtrar manualmente solo los inactivos
                if (estadoActivacion == "Inactivos")
                {
                    reservasFiltradas = reservasFiltradas.Where(r => !r.Activo).ToList();
                }

                // Crear lista con información de estado de activación
                var reservasConEstado = reservasFiltradas.Select(r => new
                {
                    r.Id,
                    r.Cliente,
                    r.FechaCheckIn,
                    r.FechaCheckOut,
                    r.Servicio,
                    r.Estado,
                    r.MetodoPago,
                    r.CantidadHuespedes,
                    r.MontoEstimado,
                    r.Activo
                }).ToList();

                GrillaReservas.DataSource = reservasConEstado;

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
            cmbEstadoActivacion.SelectedIndex = 0; // Resetear filtro de activación
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

        private void GrillaReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = GrillaReservas.Columns[e.ColumnIndex].Name;

                if (columnName == "btnEditar")
                {
                    btnEditarReserva_Click(e.RowIndex);
                }
                else if (columnName == "btnEliminar")
                {
                    btnEliminarReserva_Click(e.RowIndex);
                }
                else if (columnName == "Activo")
                {
                    // Toggle del checkbox activo/inactivo
                    ToggleReservaActiva(e.RowIndex);
                }
            }
        }

        private void btnEditarReserva_Click(int rowIndex)
        {
            try
            {
                var reserva = reservasActuales[rowIndex];
                EditarReserva(reserva);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar reserva: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarReserva_Click(int rowIndex)
        {
            try
            {
                var reserva = reservasActuales[rowIndex];
                string accion = reserva.Activo ? "desactivar" : "reactivar";

                DialogResult result = MessageBox.Show(
                    $"¿Está seguro de que desea {accion} la reserva {reserva.Id}?\n\n" +
                    $"Cliente: {reserva.Cliente}\n" +
                    $"Servicio: {reserva.Servicio}\n" +
                    $"Estado actual: {(reserva.Activo ? "Activo" : "Inactivo")}",
                    $"Confirmar {accion}",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (reserva.Activo)
                    {
                        // Desactivar reserva
                        DataService.DesactivarReserva(reserva.Id, "Desactivado por usuario");

                        // Desactivar pagos asociados
                        var pagos = DataService.GetPagosByReservaId(reserva.Id);
                        foreach (var pago in pagos)
                        {
                            DataService.DesactivarPago(pago.Id, "Desactivado por desactivación de reserva");
                        }

                        MessageBox.Show("Reserva desactivada exitosamente.\n" +
                                      "Se han desactivado también los pagos asociados.",
                                      "Reserva Desactivada",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Reactivar reserva
                        DataService.ReactivarReserva(reserva.Id);

                        MessageBox.Show("Reserva reactivada exitosamente.",
                                      "Reserva Reactivada",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }

                    // Recargar datos
                    LoadReservas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado de reserva: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToggleReservaActiva(int rowIndex)
        {
            try
            {
                var reserva = reservasActuales[rowIndex];

                if (reserva.Activo)
                {
                    DataService.DesactivarReserva(reserva.Id, "Desactivado desde interfaz");
                }
                else
                {
                    DataService.ReactivarReserva(reserva.Id);
                }

                // Recargar datos para reflejar cambios
                LoadReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado de reserva: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Recargar datos para restaurar estado original
                LoadReservas();
            }
        }

        private void EditarReserva(Reserva reserva)
        {
            try
            {
                // Abrir el formulario de crear/editar reserva
                using (var editarReservaForm = new CrearReservaForm())
                {
                    // Configurar el formulario para modo edición
                    editarReservaForm.Text = "Editar Reserva";
                    editarReservaForm.ConfigurarParaEdicion(reserva);

                    if (editarReservaForm.ShowDialog() == DialogResult.OK)
                    {
                        // Recargar las reservas después de editar
                        LoadReservas();
                        MessageBox.Show("Reserva actualizada exitosamente.", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario de edición: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
