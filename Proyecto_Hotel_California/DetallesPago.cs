using HotelCalifornia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelCalifornia
{
    public partial class DetallesPago : Form
    {
        private int pagoId;
        public DetallesPago(int id_pago)
        {
            InitializeComponent();
            pagoId = id_pago;
        }

        private void DetallesPago_Load(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                string query = @"SELECT
                        p.id_pago,
                        p.monto,
                        p.fecha,
                        p.referencia + p.id_pago AS Referencia,
                        f.numero,
                        r.id_reserva,
                        r.fecha_inicio,
                        r.fecha_fin,
                        c.nombre + ' ' + c.apellido AS Cliente,
                        c.dni,
                        c.email,
                        mp.descripcion AS metodoPago
                    FROM Pago p
                    INNER JOIN Factura f ON p.id_pago = f.id_pago
                    INNER JOIN Reserva r ON f.id_reserva = r.id_reserva
                    INNER JOIN Cliente c ON r.id_cliente = c.id_cliente
                    INNER JOIN ReservaHabitacion rh ON r.id_reserva = rh.id_reserva
                    INNER JOIN Habitacion h ON rh.numero_hab = h.numero_hab
                    INNER JOIN MetodoPago mp ON p.id_metodoPago = mp.id_metodoPago
                    WHERE p.id_pago = @idPago;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idPago", pagoId);

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Mostrar Numero de la habitacion en el título o label
                        LNroRef.Text = reader["Referencia"].ToString();
                        LFP.Text = Convert.ToDateTime(reader["fecha"]).ToString("dd/MM/yyyy");
                        LClie.Text = reader["Cliente"].ToString();
                        LD.Text = reader["dni"].ToString();
                        LMail.Text = reader["email"].ToString();
                        LNumRes.Text = reader["id_reserva"].ToString();
                        LInicioR.Text = Convert.ToDateTime(reader["fecha_inicio"]).ToString("dd/MM/yyyy");
                        LFinR.Text = Convert.ToDateTime(reader["fecha_fin"]).ToString("dd/MM/yyyy");
                        LMP.Text = reader["metodoPago"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("No se encontró la habitación con ese Número.");
                        this.Close();
                    }
                }
            }
        }
    }
}
