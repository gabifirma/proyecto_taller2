using HotelCalifornia.Models;
using HotelCalifornia.Services;
using HotelCalifornia.Styles;
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
    public partial class Reservas : BaseResponsiveForm
    {
        public Reservas()
        {
            InitializeComponent();
            CargarReservas();
            // La clase base BaseResponsiveForm se encarga del responsive design automáticamente
            this.WindowState = FormWindowState.Maximized;
        }

        private void CargarReservas()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        R.id_reserva,
                        R.fecha_inicio,
                        R.fecha_fin,
                        R.id_estado,    
                        C.nombre AS nombre_cliente,
                        C.apellido AS apellido_cliente,
                        H.numero_hab,
                        TH.nombre AS tipo_habitacion,
                        TH.capacidad,
                        RH.cantidad_noches,
                        RH.subtotal
                    FROM Reserva R
                    INNER JOIN Cliente C ON R.id_cliente = C.id_cliente
                    INNER JOIN ReservaHabitacion RH ON R.id_reserva = RH.id_reserva
                    INNER JOIN Habitacion H ON RH.numero_hab = H.numero_hab
                    INNER JOIN TipoHabitacion TH ON H.id_tipo = TH.id_tipo
                    ORDER BY R.id_reserva DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GrillaReservas.AutoGenerateColumns = true; 
                GrillaReservas.DataSource = dt;

                // Recorremos las filas y aplicamos color según el estado
                foreach (DataGridViewRow row in GrillaReservas.Rows)
                {
                    if (row.Cells["id_estado"].Value == null) continue;

                    int estado = Convert.ToInt32(row.Cells["id_estado"].Value);

                    switch (estado)
                    {
                        case 2:
                            row.DefaultCellStyle.BackColor = Color.Yellow; // En espera
                            break;
                        case 1:
                            row.DefaultCellStyle.BackColor = Color.Green; // Confirmada
                            break;
                        case 3:
                            row.DefaultCellStyle.BackColor = Color.Red; // Terminada
                            break;
                    }
                }                
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                // Construimos la consulta base
                string query = @"SELECT
                        R.id_reserva,
                        R.fecha_inicio,
                        R.fecha_fin,
                        R.fecha_creacion,
                        R.id_estado,    
                        C.nombre AS nombre_cliente,
                        C.apellido AS apellido_cliente,
                        H.numero_hab,
                        TH.nombre AS tipo_habitacion,
                        TH.capacidad,
                        RH.cantidad_noches,
                        RH.subtotal
                    FROM Reserva R
                    INNER JOIN Cliente C ON R.id_cliente = C.id_cliente
                    INNER JOIN ReservaHabitacion RH ON R.id_reserva = RH.id_reserva
                    INNER JOIN Habitacion H ON RH.numero_hab = H.numero_hab
                    INNER JOIN TipoHabitacion TH ON H.id_tipo = TH.id_tipo
                    WHERE 1=1";

                // Creamos el comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // Filtro por fechas
                if (dtpFechaInicio.Value <= dtpFechaFin.Value) // rango de fechas
                {
                    query += " AND R.fecha_creacion BETWEEN @desde AND @hasta";
                    cmd.Parameters.AddWithValue("@desde", dtpFechaInicio.Value.Date);
                    cmd.Parameters.AddWithValue("@hasta", dtpFechaFin.Value.Date.AddDays(1).AddSeconds(-1)); // incluye el día completo
                }
                else
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", 
                        "Error de fechas", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }

                // Filtro por nombre
                if (!string.IsNullOrEmpty(TNombre.Text))
                {
                    query += " AND C.nombre LIKE @nombre";
                    cmd.Parameters.AddWithValue("@nombre", "%" + TNombre.Text.Trim() + "%");
                }

                // Filtro por apellido
                if (!string.IsNullOrEmpty(TApellido.Text))
                {
                    query += " AND C.apellido LIKE @apellido";
                    cmd.Parameters.AddWithValue("@apellido", "%" + TApellido.Text.Trim() + "%");
                }
                
                // Filtro por método de pago
                if (RBSingle.Checked)
                {
                    query += " AND H.id_tipo= 1";
                }
                else if (RBDoble.Checked)
                {
                    query += " AND H.id_tipo = 2";
                }
                else if (RBSuite.Checked)
                {
                    query += " AND H.id_tipo = 3";
                }

                // Aplicamos la consulta final
                query += " ORDER BY R.fecha_creacion DESC";
                cmd.CommandText = query;

                // Llenamos el DataTable y lo mostramos
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                GrillaReservas.DataSource = dt;
            }
        }

        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            CrearReservaForm frm = new CrearReservaForm();
            frm.ShowDialog();
        }

        private void GrillaReservas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Funcionalidad para doble clic en la grilla
            if (e.RowIndex >= 0) // para evitar encabezados
            {
                // Obtener el valor de la columna ID de la fila seleccionada
                int numReserva = Convert.ToInt32(GrillaReservas.Rows[e.RowIndex].Cells["id_reserva"].Value);

                // Abrir el formulario de edición y pasarle el Id
                CrearPagoForm frm = new CrearPagoForm(numReserva);
                frm.ShowDialog();

                // refrescar el DataGridView después de editar
                CargarReservas();
            }
        }

        private void Reservas_Load(object sender, EventArgs e)
        {
            CargarReservas();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            TNombre.Clear();
            TApellido.Clear();
            RBSingle.Checked = true;
            RBDoble.Checked = false;
            RBSuite.Checked = false;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            CargarReservas();
        }
    }
}
