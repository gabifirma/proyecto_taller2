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
    public partial class CrearReservaForm : Form
    {
        private bool isProcessing = false;

        public CrearReservaForm()
        {
            InitializeComponent();
        }

        private void CrearReservaForm_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Configurar fechas por defecto
            dtpCheckIn.Value = DateTime.Now.AddDays(1);
            dtpCheckOut.Value = DateTime.Now.AddDays(2);
            dtpCheckIn.MinDate = DateTime.Now;
            dtpCheckOut.MinDate = DateTime.Now.AddDays(1);

            // Configurar servicios
            cmbServicio.Items.AddRange(new string[]
            {
                "Habitación Individual",
                "Habitación Doble", 
                "Suite",
                "Suite Presidencial"
            });

            // Configurar métodos de pago
            cmbMetodoPago.Items.AddRange(new string[]
            {
                "Efectivo",
                "Tarjeta",
                "Transferencia",
                "Cheque"
            });

            // Configurar cantidad de huéspedes
            numCantidadHuespedes.Minimum = 1;
            numCantidadHuespedes.Maximum = 10;
            numCantidadHuespedes.Value = 1;

            // Eventos para cálculo automático
            cmbServicio.SelectedIndexChanged += CalcularMonto;
            dtpCheckIn.ValueChanged += CalcularMonto;
            dtpCheckOut.ValueChanged += CalcularMonto;
            numCantidadHuespedes.ValueChanged += CalcularMonto;
        }

        private void CalcularMonto(object sender, EventArgs e)
        {
            try
            {
                if (cmbServicio.SelectedItem == null || dtpCheckOut.Value <= dtpCheckIn.Value)
                {
                    txtMontoEstimado.Text = "0.00";
                    return;
                }

                string servicio = cmbServicio.SelectedItem.ToString();
                int dias = (dtpCheckOut.Value - dtpCheckIn.Value).Days;
                int huespedes = (int)numCantidadHuespedes.Value;

                decimal precioPorNoche = 0;
                switch (servicio)
                {
                    case "Habitación Individual":
                        precioPorNoche = 150.00m;
                        break;
                    case "Habitación Doble":
                        precioPorNoche = 250.00m;
                        break;
                    case "Suite":
                        precioPorNoche = 450.00m;
                        break;
                    case "Suite Presidencial":
                        precioPorNoche = 800.00m;
                        break;
                }

                decimal montoTotal = precioPorNoche * dias;
                
                // Aplicar recargo por huéspedes adicionales
                if (huespedes > 2)
                {
                    montoTotal += (huespedes - 2) * 50.00m * dias;
                }

                txtMontoEstimado.Text = montoTotal.ToString("F2");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculando monto: {ex.Message}");
            }
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            // Asegurar que check-out sea después de check-in
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
            }
            dtpCheckOut.MinDate = dtpCheckIn.Value.AddDays(1);
        }

        public void ConfigurarParaEdicion(Reserva reserva)
        {
            // Cambiar el texto del botón
            btnGuardar.Text = "Actualizar";

            // Llenar los campos con los datos de la reserva
            txtCliente.Text = reserva.Cliente;
            dtpCheckIn.Value = reserva.FechaCheckIn;
            dtpCheckOut.Value = reserva.FechaCheckOut;

            // Seleccionar servicio
            for (int i = 0; i < cmbServicio.Items.Count; i++)
            {
                if (cmbServicio.Items[i].ToString() == reserva.Servicio)
                {
                    cmbServicio.SelectedIndex = i;
                    break;
                }
            }

            // Seleccionar método de pago
            for (int i = 0; i < cmbMetodoPago.Items.Count; i++)
            {
                if (cmbMetodoPago.Items[i].ToString() == reserva.MetodoPago)
                {
                    cmbMetodoPago.SelectedIndex = i;
                    break;
                }
            }

            // Configurar cantidad de huéspedes
            numCantidadHuespedes.Value = reserva.CantidadHuespedes;

            // Calcular y mostrar monto
            CalcularMonto(null, null);
            txtMontoEstimado.Text = reserva.MontoEstimado.ToString("F2");

            // Guardar el ID para actualizar
            this.Tag = reserva.Id;

            // Actualizar título
            this.Text = $"Editar Reserva - {reserva.Id}";
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

                string reservaId = this.Tag as string;

                if (!string.IsNullOrEmpty(reservaId))
                {
                    // Modo edición
                    var reservaExistente = DataService.GetReservaById(reservaId);
                    if (reservaExistente != null)
                    {
                        // Actualizar los campos editables
                        reservaExistente.Cliente = txtCliente.Text.Trim();
                        reservaExistente.FechaCheckIn = dtpCheckIn.Value;
                        reservaExistente.FechaCheckOut = dtpCheckOut.Value;
                        reservaExistente.Servicio = cmbServicio.SelectedItem.ToString();
                        reservaExistente.MetodoPago = cmbMetodoPago.SelectedItem.ToString();
                        reservaExistente.CantidadHuespedes = (int)numCantidadHuespedes.Value;
                        reservaExistente.MontoEstimado = decimal.Parse(txtMontoEstimado.Text);

                        // Actualizar en DataService
                        DataService.UpdateReserva(reservaExistente);

                        MessageBox.Show($"Reserva {reservaId} actualizada exitosamente.", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Modo creación (código existente)
                    var nuevaReserva = new Reserva
                    {
                        Id = DataService.GenerateReservaId(),
                        Cliente = txtCliente.Text.Trim(),
                        FechaCheckIn = dtpCheckIn.Value,
                        FechaCheckOut = dtpCheckOut.Value,
                        Servicio = cmbServicio.SelectedItem.ToString(),
                        Estado = "Pendiente",
                        MetodoPago = cmbMetodoPago.SelectedItem.ToString(),
                        CantidadHuespedes = (int)numCantidadHuespedes.Value,
                        MontoEstimado = decimal.Parse(txtMontoEstimado.Text)
                    };

                    if (!ValidarDisponibilidad(nuevaReserva))
                    {
                        MessageBox.Show("No hay disponibilidad para el servicio seleccionado en las fechas indicadas.",
                                      "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DataService.AddReserva(nuevaReserva);

                    MessageBox.Show($"Reserva {nuevaReserva.Id} creada exitosamente.", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar reserva: {ex.Message}", "Error",
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

            // Validar cliente
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MostrarError(lblCliente, "El cliente es obligatorio");
                esValido = false;
            }

            // Validar fechas
            if (dtpCheckIn.Value >= dtpCheckOut.Value)
            {
                MostrarError(lblCheckIn, "La fecha de check-in debe ser anterior al check-out");
                esValido = false;
            }

            if (dtpCheckIn.Value < DateTime.Now.Date)
            {
                MostrarError(lblCheckIn, "La fecha de check-in no puede ser en el pasado");
                esValido = false;
            }

            // Validar servicio
            if (cmbServicio.SelectedItem == null)
            {
                MostrarError(lblServicio, "Debe seleccionar un servicio");
                esValido = false;
            }

            // Validar método de pago
            if (cmbMetodoPago.SelectedItem == null)
            {
                MostrarError(lblMetodoPago, "Debe seleccionar un método de pago");
                esValido = false;
            }

            // Validar cantidad de huéspedes
            if (numCantidadHuespedes.Value <= 0)
            {
                MostrarError(lblCantidadHuespedes, "La cantidad de huéspedes debe ser mayor a 0");
                esValido = false;
            }

            return esValido;
        }

        private bool ValidarDisponibilidad(Reserva nuevaReserva)
        {
            // Simulación de validación de disponibilidad
            var reservasExistentes = DataService.GetReservas()
                .Where(r => r.Servicio == nuevaReserva.Servicio && 
                           r.Estado != "Anulada" &&
                           ((nuevaReserva.FechaCheckIn >= r.FechaCheckIn && nuevaReserva.FechaCheckIn < r.FechaCheckOut) ||
                            (nuevaReserva.FechaCheckOut > r.FechaCheckIn && nuevaReserva.FechaCheckOut <= r.FechaCheckOut) ||
                            (nuevaReserva.FechaCheckIn <= r.FechaCheckIn && nuevaReserva.FechaCheckOut >= r.FechaCheckOut)))
                .ToList();

            // Capacidad máxima por servicio (simulada)
            int capacidadMaxima = nuevaReserva.Servicio switch
            {
                "Habitación Individual" => 5,
                "Habitación Doble" => 3,
                "Suite" => 2,
                "Suite Presidencial" => 1,
                _ => 1
            };

            return reservasExistentes.Count < capacidadMaxima;
        }

        private void MostrarError(Label label, string mensaje)
        {
            label.ForeColor = Color.Red;
            label.Text = label.Text.Split(':')[0] + ": " + mensaje;
        }

        private void LimpiarErrores()
        {
            lblCliente.ForeColor = SystemColors.ControlText;
            lblCliente.Text = "Cliente:";
            lblCheckIn.ForeColor = SystemColors.ControlText;
            lblCheckIn.Text = "Check-In:";
            lblServicio.ForeColor = SystemColors.ControlText;
            lblServicio.Text = "Servicio:";
            lblMetodoPago.ForeColor = SystemColors.ControlText;
            lblMetodoPago.Text = "Método de Pago:";
            lblCantidadHuespedes.ForeColor = SystemColors.ControlText;
            lblCantidadHuespedes.Text = "Cantidad Huéspedes:";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
