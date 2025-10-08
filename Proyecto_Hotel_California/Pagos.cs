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
using System.Xml.Serialization;

namespace HotelCalifornia
{
    public partial class Pagos : BaseResponsiveForm
    {
        public Pagos()
        {
            InitializeComponent();
            CargarPagos();
            // La clase base BaseResponsiveForm se encarga del responsive design automáticamente
            //this.WindowState = FormWindowState.Maximized;
        }

        private void CargarPagos()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                string query = "SELECT * FROM Pago";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GrillaPagos.AutoGenerateColumns = false;
                GrillaPagos.DataSource = dt;
            }
        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            CargarPagos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                // Construimos la consulta base
                string query = @"SELECT 
                    p.id_pago,
                    p.fecha,
                    p.monto,
                    p.referencia,
                    p.id_metodoPago
                 FROM Pago p
                 WHERE 1=1";

                // Creamos el comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // Filtro por fechas
                if (DTDesde.Value <= DTHasta.Value) // rango de fechas
                {
                    query += " AND p.fecha BETWEEN @desde AND @hasta";
                    cmd.Parameters.AddWithValue("@desde", DTDesde.Value.Date);
                    cmd.Parameters.AddWithValue("@hasta", DTHasta.Value.Date.AddDays(1).AddSeconds(-1)); // incluye el día completo
                }
                else
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", "Error de fechas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Filtro por referencia
                if (!string.IsNullOrEmpty(TReferencia.Text))
                {
                    query += " AND p.referencia LIKE @referencia";
                    cmd.Parameters.AddWithValue("@referencia", "%" + TReferencia.Text.Trim() + "%");
                }

                // Filtro por método de pago
                if (RBEfectivo.Checked)
                {
                    query += " AND p.id_metodoPago = 1";
                } 
                else if (RBTrans.Checked)
                {
                    query += " AND p.id_metodoPago = 2";
                }
                else if (RBCredito.Checked)
                {
                    query += " AND p.id_metodoPago = 3";
                }

                // Aplicamos la consulta final
                query += " ORDER BY p.fecha DESC";
                cmd.CommandText = query;

                // Llenamos el DataTable y lo mostramos
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                GrillaPagos.DataSource = dt;
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            TReferencia.Clear();
            DTDesde.Value = DateTime.Now;
            DTHasta.Value = DateTime.Now;
            CargarPagos();
        }

     /* private void GrillaPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Funcionalidad para doble clic en la grilla
            if (e.RowIndex >= 0) // para evitar encabezados
            {
                // Obtener el valor de la columna ID de la fila seleccionada
                int idPago = Convert.ToInt32(GrillaPagos.Rows[e.RowIndex].Cells["id_pago"].Value);

                // Abrir el formulario de edición y pasarle el Id
                DetallesPago frm = new DetallesPago(idPago);
                frm.ShowDialog();

                // refrescar el DataGridView después de editar
                CargarPagos();
            }
        }*/
    }
}
