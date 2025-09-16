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
    public partial class Pagos : Form
    {
        private List<Pago> pagosActuales;

        public Pagos()
        {
            InitializeComponent();
        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            InitializeForm();
            LoadPagos();
        }

        private void InitializeForm()
        {
            // Configurar fecha por defecto
            dtpFechaPago.Value = DateTime.Now;
            cmbEstado.SelectedIndex = 0; // "Todos"
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
                Width = 60
            });

            GrillaPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReservaId",
                HeaderText = "Reserva",
                DataPropertyName = "ReservaId",
                Width = 80
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
            var clienteColumn = new DataGridViewTextBoxColumn
            {
                Name = "Cliente",
                HeaderText = "Cliente",
                Width = 150
            };
            GrillaPagos.Columns.Add(clienteColumn);
        }

        private void LoadPagos()
        {
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pagos: {ex.Message}", "Error", 
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
                DateTime? fecha = dtpFechaPago.Checked ? dtpFechaPago.Value : (DateTime?)null;
                string estado = cmbEstado.SelectedItem?.ToString();
                if (estado == "Todos") estado = null;
                string metodoPago = cmbMetodoPago.SelectedItem?.ToString();
                if (metodoPago == "Todos") metodoPago = null;

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
                foreach (DataGridViewRow row in GrillaPagos.Rows)
                {
                    if (row.Cells["Estado"].Value != null)
                    {
                        string estadoRow = row.Cells["Estado"].Value.ToString();
                        switch (estadoRow)
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
            cmbEstado.SelectedIndex = 0;
            cmbMetodoPago.SelectedIndex = 0;
            LoadPagos();
        }

        private void btnNuevoPago_Click(object sender, EventArgs e)
        {
            try
            {
                CrearPagoForm crearForm = new CrearPagoForm();
                if (crearForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPagos(); // Recargar la lista después de crear
                    MessageBox.Show("Pago registrado exitosamente.", "Éxito", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
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
