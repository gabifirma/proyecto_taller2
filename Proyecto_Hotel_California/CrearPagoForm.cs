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

namespace Proyecto_Hotel_California
{
    public partial class CrearPagoForm : Form
    {
        private bool isProcessing = false;

        public CrearPagoForm()
        {
            InitializeComponent();
        }

        private void CrearPagoForm_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Configurar fecha por defecto
            dtpFechaPago.Value = DateTime.Now;
            dtpFechaPago.MaxDate = DateTime.Now; // No permitir fechas futuras

            // Cargar reservas disponibles
            LoadReservas();

            // Configurar métodos de pago
            cmbMetodoPago.Items.AddRange(new string[]
            {
                "Efectivo",
                "Tarjeta", 
                "Transferencia",
                "Cheque"
            });

            // Configurar estados
            cmbEstado.Items.AddRange(new string[]
            {
                "Pendiente",
                "Confirmado"
            });
            cmbEstado.SelectedIndex = 0; // Pendiente por defecto

            // Eventos
            cmbReserva.SelectedIndexChanged += CmbReserva_SelectedIndexChanged;
        }

        private void LoadReservas()
        {
            try
            {
                var reservas = DataService.GetReservas()
                    .Where(r => r.Estado != "Anulada")
                    .OrderBy(r => r.Id)
                    .ToList();

                cmbReserva.DisplayMember = "Display";
                cmbReserva.ValueMember = "Id";
                cmbReserva.DataSource = reservas.Select(r => new
                {
                    r.Id,
                    Display = $"{r.Id} - {r.Cliente} ({r.MontoEstimado:C2})"
                }).ToList();

                cmbReserva.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar reservas: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbReserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReserva.SelectedValue != null)
            {
                string reservaId = cmbReserva.SelectedValue.ToString();
                var reserva = DataService.GetReservaById(reservaId);
                
                if (reserva != null)
                {
                    // Sugerir el monto de la reserva
                    txtMonto.Text = reserva.MontoEstimado.ToString("F2");
                    
                    // Sugerir el método de pago de la reserva
                    for (int i = 0; i < cmbMetodoPago.Items.Count; i++)
                    {
                        if (cmbMetodoPago.Items[i].ToString() == reserva.MetodoPago)
                        {
                            cmbMetodoPago.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        public void ConfigurarParaEdicion(Pago pago)
        {
            // Cambiar el texto del botón
            btnGuardar.Text = "Actualizar";

            // Llenar los campos con los datos del pago
            var reserva = DataService.GetReservaById(pago.ReservaId);
            if (reserva != null)
            {
                // Seleccionar reserva
                for (int i = 0; i < cmbReserva.Items.Count; i++)
                {
                    var item = (dynamic)cmbReserva.Items[i];
                    if (item.Id == pago.ReservaId)
                    {
                        cmbReserva.SelectedIndex = i;
                        break;
                    }
                }
            }

            // Configurar fecha
            dtpFechaPago.Value = pago.FechaPago;

            // Configurar monto
            txtMonto.Text = pago.Monto.ToString("F2");

            // Seleccionar método de pago
            for (int i = 0; i < cmbMetodoPago.Items.Count; i++)
            {
                if (cmbMetodoPago.Items[i].ToString() == pago.MetodoPago)
                {
                    cmbMetodoPago.SelectedIndex = i;
                    break;
                }
            }

            // Seleccionar estado
            for (int i = 0; i < cmbEstado.Items.Count; i++)
            {
                if (cmbEstado.Items[i].ToString() == pago.Estado)
                {
                    cmbEstado.SelectedIndex = i;
                    break;
                }
            }

            // Guardar el ID para actualizar
            this.Tag = pago.Id;

            // Actualizar título
            this.Text = $"Editar Pago - {pago.Id}";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (isProcessing) return;

            try
            {
                // Validar campos
                if (!ValidarCampos()) return;

                isProcessing = true;
                btnGuardar.Enabled = false;
                btnGuardar.Text = "Guardando...";

                string pagoId = this.Tag as string;

                if (!string.IsNullOrEmpty(pagoId))
                {
                    // Modo edición
                    var pagoExistente = DataService.GetPagoById(pagoId);
                    if (pagoExistente != null)
                    {
                        // Actualizar los campos editables
                        pagoExistente.ReservaId = cmbReserva.SelectedValue.ToString();
                        pagoExistente.FechaPago = dtpFechaPago.Value;
                        pagoExistente.Monto = decimal.Parse(txtMonto.Text);
                        pagoExistente.MetodoPago = cmbMetodoPago.SelectedItem.ToString();
                        pagoExistente.Estado = cmbEstado.SelectedItem.ToString();

                        // Actualizar en DataService
                        DataService.UpdatePago(pagoExistente);

                        MessageBox.Show($"Pago {pagoId} actualizado exitosamente.", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Modo creación (código existente)
                    var nuevoPago = new Pago
                    {
                        Id = DataService.GeneratePagoId(),
                        ReservaId = cmbReserva.SelectedValue.ToString(),
                        FechaPago = dtpFechaPago.Value,
                        Monto = decimal.Parse(txtMonto.Text),
                        MetodoPago = cmbMetodoPago.SelectedItem.ToString(),
                        Estado = cmbEstado.SelectedItem.ToString()
                    };

                    if (!ValidarPago(nuevoPago))
                    {
                        return;
                    }

                    DataService.AddPago(nuevoPago);

                    MessageBox.Show($"Pago {nuevoPago.Id} registrado exitosamente.", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar pago: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isProcessing = false;
                btnGuardar.Enabled = true;
                btnGuardar.Text = this.Tag != null ? "Actualizar" : "Guardar";
            }
        }

        private bool ValidarCampos()
        {
            // Limpiar errores previos
            LimpiarErrores();

            bool esValido = true;

            // Validar reserva
            if (cmbReserva.SelectedValue == null)
            {
                MostrarError(lblReserva, "Debe seleccionar una reserva");
                esValido = false;
            }

            // Validar monto
            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MostrarError(lblMonto, "El monto es obligatorio");
                esValido = false;
            }
            else if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MostrarError(lblMonto, "El monto debe ser un número mayor a 0");
                esValido = false;
            }

            // Validar fecha
            if (dtpFechaPago.Value > DateTime.Now)
            {
                MostrarError(lblFechaPago, "La fecha de pago no puede ser futura");
                esValido = false;
            }

            // Validar método de pago
            if (cmbMetodoPago.SelectedItem == null)
            {
                MostrarError(lblMetodoPago, "Debe seleccionar un método de pago");
                esValido = false;
            }

            // Validar estado
            if (cmbEstado.SelectedItem == null)
            {
                MostrarError(lblEstado, "Debe seleccionar un estado");
                esValido = false;
            }

            return esValido;
        }

        private bool ValidarPago(Pago nuevoPago)
        {
            try
            {
                var reserva = DataService.GetReservaById(nuevoPago.ReservaId);
                if (reserva == null)
                {
                    MessageBox.Show("La reserva seleccionada no existe.", "Validación", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Validar compatibilidad de método de pago
                if (nuevoPago.MetodoPago != reserva.MetodoPago)
                {
                    DialogResult result = MessageBox.Show(
                        $"El método de pago ({nuevoPago.MetodoPago}) es diferente al de la reserva ({reserva.MetodoPago}).\\n¿Desea continuar?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.No)
                        return false;
                }

                // Validar que el monto no exceda significativamente el monto de la reserva
                if (nuevoPago.Monto > reserva.MontoEstimado * 1.5m)
                {
                    DialogResult result = MessageBox.Show(
                        $"El monto del pago ({nuevoPago.Monto:C2}) es significativamente mayor al monto estimado de la reserva ({reserva.MontoEstimado:C2}).\\n¿Desea continuar?",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (result == DialogResult.No)
                        return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en validación: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void MostrarError(Label label, string mensaje)
        {
            label.ForeColor = Color.Red;
            label.Text = label.Text.Split(':')[0] + ": " + mensaje;
        }

        private void LimpiarErrores()
        {
            lblReserva.ForeColor = SystemColors.ControlText;
            lblReserva.Text = "Reserva:";
            lblMonto.ForeColor = SystemColors.ControlText;
            lblMonto.Text = "Monto:";
            lblFechaPago.ForeColor = SystemColors.ControlText;
            lblFechaPago.Text = "Fecha de Pago:";
            lblMetodoPago.ForeColor = SystemColors.ControlText;
            lblMetodoPago.Text = "Método de Pago:";
            lblEstado.ForeColor = SystemColors.ControlText;
            lblEstado.Text = "Estado:";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
