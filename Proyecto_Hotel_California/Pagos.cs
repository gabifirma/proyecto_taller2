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
            this.WindowState = FormWindowState.Maximized;
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

        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscarCliente.Clear();
            dtpFechaPago.Value = DateTime.Now;
            dtpFechaPago.Checked = false;
            cmbEstado.SelectedIndex = 0;
            cmbMetodoPago.SelectedIndex = 0;
        }

        private void GrillaPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Implementar funcionalidad adicional si es necesario
        }
    }
}
