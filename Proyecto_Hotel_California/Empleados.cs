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

namespace Proyecto_Hotel_California
{
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private bool EmpleadoExiste(int idEmpleado)
        {
            bool existe = false;

            string connectionString = "Data Source=DESKTOP-9V9JJ39\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True;";
            string query = "SELECT COUNT(*) FROM Empleado WHERE id_empleado = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", idEmpleado);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                existe = count > 0;
            }

            return existe;
        }


        private void BAgregarEmp_Click(object sender, EventArgs e)
        {
            AgregarEmp ventana = new AgregarEmp();
            ventana.ShowDialog();
        }

        private void BEditarEmp_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(TId.Text, out int idEmpleado))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }
            if(!EmpleadoExiste(idEmpleado))
            {
                MessageBox.Show("Ingrese un ID existente.");
                return;
            }

            EditarEmp formEditar = new EditarEmp(idEmpleado);
            formEditar.ShowDialog(); // abre en modo modal
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            string conexion = "Server=DESKTOP-9V9JJ39\\SQLEXPRESS;Database=Hotel;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                string query = "SELECT id_empleado, apellido, nombre, legajo, telefono, email, estado FROM Empleado";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GrillaEmpleados.AutoGenerateColumns = false;
                GrillaEmpleados.DataSource = dt;
            }
        }
    }
}
