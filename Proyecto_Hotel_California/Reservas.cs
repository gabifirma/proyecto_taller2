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
                        RH.precio_noche,
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

                GrillaReservas.AutoGenerateColumns = true; // o configurala manualmente si querés formato
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
    }
}
