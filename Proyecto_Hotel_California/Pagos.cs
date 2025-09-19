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
using Proyecto_Hotel_California.Styles;

namespace Proyecto_Hotel_California
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
                Width = 80
            });

            GrillaPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReservaId",
                HeaderText = "Reserva",
                DataPropertyName = "ReservaId",
                Width = 100
            });

            GrillaPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaPago",
                HeaderText = "Fecha Pago",
                DataPropertyName = "FechaPago",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 100
            });

            GrillaPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Monto",
                HeaderText = "Monto",
                DataPropertyName = "Monto",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });

            GrillaPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MetodoPago",
                HeaderText = "Método",
                DataPropertyName = "MetodoPago",
                Width = 100
            });

            GrillaPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 100
            });

            // Agregar columna para mostrar cliente
            GrillaPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cliente",
                HeaderText = "Cliente",
                DataPropertyName = "Cliente",
                Width = 150
            });

            // Configurar para redimensionamiento automático
            GrillaPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadPagos()
        {
            try
            {
                // Usar DataService para obtener los pagos
                pagosActuales = DataService.GetPagos();
                var reservas = DataService.GetReservas();
                
                // Crear una lista con información combinada
                var pagosConCliente = pagosActuales.Select(p => new
                {
                    p.Id,
                    p.ReservaId,
                    p.FechaPago,
                    p.Monto,
                    p.MetodoPago,
                    p.Estado,
                    Cliente = reservas.FirstOrDefault(r => r.Id == p.ReservaId)?.Cliente ?? "N/A"
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

                // Usar el método de filtrado del DataService
                var pagosFiltrados = DataService.FilterPagos(cliente, fecha, estado, metodoPago);
                var reservas = DataService.GetReservas();
                
                var pagosConCliente = pagosFiltrados.Select(p => new
                {
                    p.Id,
                    p.ReservaId,
                    p.FechaPago,
                    p.Monto,
                    p.MetodoPago,
                    p.Estado,
                    Cliente = reservas.FirstOrDefault(r => r.Id == p.ReservaId)?.Cliente ?? "N/A"
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
            // Implementar funcionalidad adicional si es necesario
        }
    }
}
