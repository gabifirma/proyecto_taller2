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
    public partial class ListaClientes : Form
    {
        public ListaClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        id_cliente,
                        nombre,
                        apellido,
                        dni,
                        telefono,
                        email
                    FROM Cliente";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GrillaListaC.AutoGenerateColumns = false;
                GrillaListaC.DataSource = dt;                
            }
        }

        private void ListaClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        public int IdClienteSeleccionado { get; private set; }

        private void GrillaListaC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdClienteSeleccionado = Convert.ToInt32(GrillaListaC.Rows[e.RowIndex].Cells["id_cliente"].Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
