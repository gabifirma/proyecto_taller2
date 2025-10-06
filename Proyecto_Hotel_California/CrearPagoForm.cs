using HotelCalifornia.Models;
using HotelCalifornia.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HotelCalifornia
{
    public partial class CrearPagoForm : Form
    {
        private int idReserva;

        public CrearPagoForm(int idRes)
        {
            InitializeComponent();
            idReserva = idRes;
            CargarDatosReserva();
        }

        private void CargarDatosReserva()
        {
            // Mostrar los datos básicos en los labels
            LFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            LReserva.Text = idReserva.ToString();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();
                string query = "SELECT (SELECT SUM(subtotal) FROM ReservaHabitacion WHERE id_reserva = @id) AS Total";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idReserva);

                object total = cmd.ExecuteScalar();
                if (total != DBNull.Value && total != null)
                    LMonto.Text = Convert.ToDecimal(total).ToString("0.00");
                else
                    LMonto.Text = "0.00";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal monto = Convert.ToDecimal(LMonto.Text);
                int idMetodoPago = ObtenerMetodoPagoSeleccionado();

                if (idMetodoPago == 0)
                {
                    MessageBox.Show("Seleccione un método de pago.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();
                    SqlTransaction tran = conn.BeginTransaction();

                    try
                    {
                        // Insertar el pago
                        string insertarPago = @"INSERT INTO Pago (fecha, monto, referencia, id_metodoPago)
                                                OUTPUT INSERTED.id_pago
                                                VALUES (GETDATE(), @monto, 1234, @metodo)";
                        SqlCommand cmdPago = new SqlCommand(insertarPago, conn, tran);
                        cmdPago.Parameters.AddWithValue("@monto", monto);
                        cmdPago.Parameters.AddWithValue("@metodo", idMetodoPago);
                        int idPago = (int)cmdPago.ExecuteScalar();

                        // Insertar la factura
                        string insertarFactura = @"INSERT INTO Factura (numero, fecha_emision, total, estado, id_pago, id_reserva)
                                                   VALUES (@num, GETDATE(), @total, 1, @idPago, @idReserva)";
                        SqlCommand cmdFactura = new SqlCommand(insertarFactura, conn, tran);
                        cmdFactura.Parameters.AddWithValue("@num", Guid.NewGuid().ToString().Substring(0, 8)); // número generado
                        cmdFactura.Parameters.AddWithValue("@total", monto);
                        cmdFactura.Parameters.AddWithValue("@idPago", idPago);
                        cmdFactura.Parameters.AddWithValue("@idReserva", idReserva);
                        cmdFactura.ExecuteNonQuery();

                        // Actualizar estado de la reserva a “Confirmada”
                        string updateReserva = "UPDATE Reserva SET id_estado = 1 WHERE id_reserva = @id";
                        SqlCommand cmdUpdate = new SqlCommand(updateReserva, conn, tran);
                        cmdUpdate.Parameters.AddWithValue("@id", idReserva);
                        cmdUpdate.ExecuteNonQuery();

                        tran.Commit();
                        MessageBox.Show("Pago registrado y reserva confirmada correctamente.");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Error al registrar el pago: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private int ObtenerMetodoPagoSeleccionado()
        {
            // Asigná el ID real según valores en la tabla MetodoPago
            if (RBEfectivo.Checked)
            {
                return 1;
            }
            else if (RBCredito.Checked)
            {
                return 2;
            }
            else if (RBTrans.Checked)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
