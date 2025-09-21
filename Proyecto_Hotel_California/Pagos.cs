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
    public partial class Pagos : BaseResponsiveForm
    {
        private List<Pago> pagosActuales;

        public Pagos()
        {
            InitializeComponent();
            // La clase base BaseResponsiveForm se encarga del responsive design automáticamente
            this.WindowState = FormWindowState.Maximized;
        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LoadPagos();
        }

        private void Pagos_Resize(object sender, EventArgs e)
        {
            AdjustControlsForResize();
        }

        private void AdjustControlsForResize()
        {
            if (this.WindowState == FormWindowState.Minimized) return;

            // Ajustar el título
            LTituloPagos.Left = (this.ClientSize.Width - LTituloPagos.Width) / 2;

            // Ajustar el grupo de filtros
            var groupBoxFiltros = this.Controls.OfType<GroupBox>().FirstOrDefault();
            if (groupBoxFiltros != null)
            {
                groupBoxFiltros.Width = this.ClientSize.Width - 40;
            }

            // Ajustar la grilla
            GrillaPagos.Width = this.ClientSize.Width - 24;
            GrillaPagos.Height = this.ClientSize.Height - GrillaPagos.Top - 80;

            // Ajustar botones
            int buttonY = this.ClientSize.Height - 60;
            var btnNuevoPago = this.Controls.OfType<Button>().FirstOrDefault(b => b.Name == "btnNuevoPago");
            if (btnNuevoPago != null)
            {
                btnNuevoPago.Top = buttonY;
            }
        }

        private void InitializeForm()
        {
            // Configurar fecha por defecto
            dtpFechaPago.Value = DateTime.Now;
            dtpFechaPago.Checked = false;
            
            // Configurar combos
            cmbEstado.Items.Clear();
            cmbEstado.Items.AddRange(new string[] { "Todos", "Confirmado", "Pendiente", "Reembolsado" });
            cmbEstado.SelectedIndex = 0; // "Todos"
            
            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.AddRange(new string[] { "Todos", "Tarjeta", "Efectivo", "Transferencia" });
            cmbMetodoPago.SelectedIndex = 0; // "Todos"
            
            // Configurar ComboBox de Estado de Activación
            cmbEstadoActivacion.Items.Clear();
            cmbEstadoActivacion.Items.AddRange(new string[] { "Todos", "Activos", "Inactivos" });
            cmbEstadoActivacion.SelectedIndex = 0; // "Todos"
            
            // Configurar DataGridView
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            GrillaPagos.AutoGenerateColumns = false;
            GrillaPagos.Columns.Clear();

            GrillaPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 80,
                ReadOnly = true
            });

            GrillaPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cliente",
                HeaderText = "Cliente",
                DataPropertyName = "Cliente",
                Width = 150,
                ReadOnly = true
            });

            GrillaPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReservaId",
                HeaderText = "Reserva ID",
                DataPropertyName = "ReservaId",
                Width = 100,
                ReadOnly = true
            });

            GrillaPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 100,
                ReadOnly = true
            });

            GrillaPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MetodoPago",
                HeaderText = "Método Pago",
                DataPropertyName = "MetodoPago",
                Width = 100,
                ReadOnly = true
            });

            GrillaPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Monto",
                HeaderText = "Monto",
                DataPropertyName = "Monto",
                Width = 100,
                ReadOnly = true
            });

            // Checkbox para estado activo/inactivo
            GrillaPagos.Columns.Add(new DataGridViewCheckBoxColumn
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
            GrillaPagos.Columns.Add(btnEditar);

            // Botón de eliminar (toggle activo/inactivo)
            var btnEliminar = new DataGridViewButtonColumn
            {
                Name = "btnEliminar",
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            GrillaPagos.Columns.Add(btnEliminar);

            // Botón de generar factura
            var btnFactura = new DataGridViewButtonColumn
            {
                Name = "btnFactura",
                HeaderText = "Factura",
                Text = "Factura",
                UseColumnTextForButtonValue = true,
                Width = 70,
                DefaultCellStyle = { BackColor = Color.MediumPurple, ForeColor = Color.White }
            };
            GrillaPagos.Columns.Add(btnFactura);

            GrillaPagos.CellContentClick += GrillaPagos_CellContentClick;

            // Configurar para redimensionamiento automático
            GrillaPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadPagos()
        {
            try
            {
                // Usar DataService para obtener TODOS los pagos (activos e inactivos)
                pagosActuales = DataService.GetPagos(false);
                var reservas = DataService.GetReservas(false); // Obtener todas las reservas para buscar clientes
                
                // Crear una lista con información combinada
                var pagosConCliente = pagosActuales.Select(p => new
                {
                    p.Id,
                    p.ReservaId,
                    p.FechaPago,
                    p.Monto,
                    p.MetodoPago,
                    p.Estado,
                    Cliente = reservas.FirstOrDefault(r => r.Id == p.ReservaId)?.Cliente ?? "N/A",
                    p.Activo
                }).ToList();

                GrillaPagos.DataSource = pagosConCliente;
                
                // Colorear filas según estado
                ApplyRowColors();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pagos: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRowColors()
        {
            foreach (DataGridViewRow row in GrillaPagos.Rows)
            {
                if (row.Cells["Estado"].Value != null)
                {
                    string estado = row.Cells["Estado"].Value.ToString();
                    bool activo = row.Cells["Activo"].Value != null && (bool)row.Cells["Activo"].Value;
                    
                    // Aplicar color base según estado
                    switch (estado)
                    {
                        case "Confirmado":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "Pendiente":
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "Reembolsado":
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
                DateTime? fecha = dtpFechaPago.Checked ? dtpFechaPago.Value : (DateTime?)null;
                string estado = cmbEstado.SelectedItem?.ToString();
                if (estado == "Todos") estado = null;
                string metodoPago = cmbMetodoPago.SelectedItem?.ToString();
                if (metodoPago == "Todos") metodoPago = null;

                // Leer el filtro de estado de activación
                string estadoActivacion = cmbEstadoActivacion.SelectedItem?.ToString();
                bool soloActivos = true;

                if (estadoActivacion == "Todos")
                    soloActivos = false;
                else if (estadoActivacion == "Inactivos")
                    soloActivos = false; // Para luego filtrar solo los inactivos

                // Usar el método de filtrado del DataService
                var pagosFiltrados = DataService.FilterPagos(cliente, fecha, estado, metodoPago, soloActivos);
                var reservas = DataService.GetReservas(false); // Obtener todas las reservas para buscar clientes

                // Si se seleccionó "Inactivos", filtrar manualmente solo los inactivos
                if (estadoActivacion == "Inactivos")
                {
                    pagosFiltrados = pagosFiltrados.Where(p => !p.Activo).ToList();
                }

                var pagosConCliente = pagosFiltrados.Select(p => new
                {
                    p.Id,
                    p.ReservaId,
                    p.FechaPago,
                    p.Monto,
                    p.MetodoPago,
                    p.Estado,
                    Cliente = reservas.FirstOrDefault(r => r.Id == p.ReservaId)?.Cliente ?? "N/A",
                    p.Activo
                }).ToList();

                GrillaPagos.DataSource = pagosConCliente;

                // Aplicar colores nuevamente
                ApplyRowColors();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar pagos: {ex.Message}", "Error",
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
            dtpFechaPago.Value = DateTime.Now;
            dtpFechaPago.Checked = false;
            cmbEstado.SelectedIndex = 0;
            cmbMetodoPago.SelectedIndex = 0;
            cmbEstadoActivacion.SelectedIndex = 0; // Resetear filtro de activación
            LoadPagos();
        }

        private void btnNuevoPago_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir el formulario de crear pago
                using (var crearPagoForm = new CrearPagoForm())
                {
                    if (crearPagoForm.ShowDialog() == DialogResult.OK)
                    {
                        // Recargar los pagos después de crear uno nuevo
                        LoadPagos();
                        MessageBox.Show("Pago registrado exitosamente.", "Éxito", 
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir formulario de nuevo pago: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrillaPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = GrillaPagos.Columns[e.ColumnIndex].Name;

                if (columnName == "btnEditar")
                {
                    btnEditarPago_Click(e.RowIndex);
                }
                else if (columnName == "btnEliminar")
                {
                    btnEliminarPago_Click(e.RowIndex);
                }
                else if (columnName == "btnFactura")
                {
                    btnGenerarFactura_Click(e.RowIndex);
                }
                else if (columnName == "Activo")
                {
                    // Toggle del checkbox activo/inactivo
                    TogglePagoActivo(e.RowIndex);
                }
            }
        }

        private void btnEditarPago_Click(int rowIndex)
        {
            try
            {
                var pago = pagosActuales[rowIndex];
                EditarPago(pago);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar pago: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarPago_Click(int rowIndex)
        {
            try
            {
                var pago = pagosActuales[rowIndex];
                string accion = pago.Activo ? "desactivar" : "reactivar";

                DialogResult result = MessageBox.Show(
                    $"¿Está seguro de que desea {accion} el pago {pago.Id}?\n\n" +
                    $"Reserva ID: {pago.ReservaId}\n" +
                    $"Monto: {pago.Monto:C2}\n" +
                    $"Estado actual: {(pago.Activo ? "Activo" : "Inactivo")}",
                    $"Confirmar {accion}",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (pago.Activo)
                    {
                        // Desactivar pago
                        DataService.DesactivarPago(pago.Id, "Desactivado por usuario");

                        MessageBox.Show("Pago desactivado exitosamente.",
                                      "Pago Desactivado",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Reactivar pago
                        DataService.ReactivarPago(pago.Id);

                        MessageBox.Show("Pago reactivado exitosamente.",
                                      "Pago Reactivado",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }

                    // Recargar datos
                    LoadPagos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado de pago: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TogglePagoActivo(int rowIndex)
        {
            try
            {
                var pago = pagosActuales[rowIndex];

                if (pago.Activo)
                {
                    DataService.DesactivarPago(pago.Id, "Desactivado desde interfaz");
                }
                else
                {
                    DataService.ReactivarPago(pago.Id);
                }

                // Recargar datos para reflejar cambios
                LoadPagos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar estado de pago: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Recargar datos para restaurar estado original
                LoadPagos();
            }
        }

        private void EditarPago(Pago pago)
        {
            try
            {
                // Abrir el formulario de crear/editar pago
                using (var editarPagoForm = new CrearPagoForm())
                {
                    // Configurar el formulario para modo edición
                    editarPagoForm.Text = "Editar Pago";
                    editarPagoForm.ConfigurarParaEdicion(pago);

                    if (editarPagoForm.ShowDialog() == DialogResult.OK)
                    {
                        // Recargar los pagos después de editar
                        LoadPagos();
                        MessageBox.Show("Pago actualizado exitosamente.", "Éxito",
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

        private void btnGenerarFactura_Click(int rowIndex)
        {
            try
            {
                var pago = pagosActuales[rowIndex];
                var reserva = DataService.GetReservaById(pago.ReservaId);

                if (reserva == null)
                {
                    MessageBox.Show("No se encontró la reserva asociada al pago.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                GenerarFactura(pago, reserva);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar factura: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarFactura(Pago pago, Reserva reserva)
        {
            try
            {
                // Generar número de factura único
                string numeroFactura = $"FACT-{DateTime.Now:yyyyMMdd}-{pago.Id}";

                // Crear contenido de la factura
                var facturaContent = new StringBuilder();
                
                // Encabezado de la factura
                facturaContent.AppendLine("═══════════════════════════════════════════════════════════");
                facturaContent.AppendLine("                    HOTEL CALIFORNIA");
                facturaContent.AppendLine("                 Sistema de Gestión Hotelera");
                facturaContent.AppendLine("═══════════════════════════════════════════════════════════");
                facturaContent.AppendLine();
                facturaContent.AppendLine($"FACTURA N°: {numeroFactura}");
                facturaContent.AppendLine($"FECHA DE EMISIÓN: {DateTime.Now:dd/MM/yyyy HH:mm}");
                facturaContent.AppendLine();
                
                // Información del cliente
                facturaContent.AppendLine("DATOS DEL CLIENTE:");
                facturaContent.AppendLine("─────────────────────────────────────────────────────────");
                facturaContent.AppendLine($"Cliente: {reserva.Cliente}");
                facturaContent.AppendLine($"Reserva ID: {reserva.Id}");
                facturaContent.AppendLine();
                
                // Información de la reserva
                facturaContent.AppendLine("DETALLES DE LA RESERVA:");
                facturaContent.AppendLine("─────────────────────────────────────────────────────────");
                facturaContent.AppendLine($"Servicio: {reserva.Servicio}");
                facturaContent.AppendLine($"Check-in: {reserva.FechaCheckIn:dd/MM/yyyy}");
                facturaContent.AppendLine($"Check-out: {reserva.FechaCheckOut:dd/MM/yyyy}");
                facturaContent.AppendLine($"Huéspedes: {reserva.CantidadHuespedes}");
                facturaContent.AppendLine($"Estado Reserva: {reserva.Estado}");
                facturaContent.AppendLine($"Monto Estimado: {reserva.MontoEstimado:C2}");
                facturaContent.AppendLine();
                
                // Información del pago
                facturaContent.AppendLine("DETALLES DEL PAGO:");
                facturaContent.AppendLine("─────────────────────────────────────────────────────────");
                facturaContent.AppendLine($"Pago ID: {pago.Id}");
                facturaContent.AppendLine($"Fecha de Pago: {pago.FechaPago:dd/MM/yyyy}");
                facturaContent.AppendLine($"Método de Pago: {pago.MetodoPago}");
                facturaContent.AppendLine($"Estado del Pago: {pago.Estado}");
                facturaContent.AppendLine($"Monto Pagado: {pago.Monto:C2}");
                facturaContent.AppendLine();
                
                // Cálculo de diferencias
                decimal diferencia = pago.Monto - reserva.MontoEstimado;
                facturaContent.AppendLine("RESUMEN FINANCIERO:");
                facturaContent.AppendLine("─────────────────────────────────────────────────────────");
                facturaContent.AppendLine($"Monto Reserva: {reserva.MontoEstimado:C2}");
                facturaContent.AppendLine($"Monto Pagado:  {pago.Monto:C2}");
                
                if (diferencia > 0)
                {
                    facturaContent.AppendLine($"Monto Adicional: {diferencia:C2}");
                }
                else if (diferencia < 0)
                {
                    facturaContent.AppendLine($"Saldo Pendiente: {Math.Abs(diferencia):C2}");
                }
                else
                {
                    facturaContent.AppendLine("Estado: PAGADO COMPLETO");
                }
                
                facturaContent.AppendLine();
                facturaContent.AppendLine("═══════════════════════════════════════════════════════════");
                facturaContent.AppendLine("              ¡Gracias por elegir Hotel California!");
                facturaContent.AppendLine("═══════════════════════════════════════════════════════════");

                // Mostrar la factura en un MessageBox
                MessageBox.Show(facturaContent.ToString(), $"Factura - {numeroFactura}", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Preguntar si desea guardar la factura
                DialogResult guardar = MessageBox.Show(
                    "¿Desea guardar la factura como archivo de texto?",
                    "Guardar Factura",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (guardar == DialogResult.Yes)
                {
                    GuardarFacturaComoArchivo(facturaContent.ToString(), numeroFactura);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar factura: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarFacturaComoArchivo(string contenido, string numeroFactura)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                    saveDialog.Title = "Guardar Factura";
                    saveDialog.FileName = $"{numeroFactura}.txt";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(saveDialog.FileName, contenido);
                        MessageBox.Show($"Factura guardada exitosamente en:\n{saveDialog.FileName}",
                                      "Factura Guardada",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar factura: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
