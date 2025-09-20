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
using HotelCalifornia.Styles;

namespace HotelCalifornia
{
    public partial class Empleados : BaseResponsiveForm
    {
        public Empleados()
        {
            InitializeComponent();
            // La clase base BaseResponsiveForm se encarga del responsive design automáticamente
        }
        

        // Método eliminado - los estilos se aplican automáticamente por BaseResponsiveForm

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
            MessageBox.Show("Funcionalidad de agregar empleado no implementada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BEditarEmp_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(TLegajo.Text, out int idEmpleado))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }
            if(!EmpleadoExiste(idEmpleado))
            {
                MessageBox.Show("Ingrese un ID existente.");
                return;
            }

            EditarEmp ventana = new EditarEmp(idEmpleado);
            ventana.ShowDialog();
        }
        
        private void Empleados_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
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

        // Métodos de eventos faltantes
        private void GrillaEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Funcionalidad para doble clic en la grilla
            if (e.RowIndex >= 0)
            {
                MessageBox.Show("Funcionalidad de edición por doble clic no implementada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TNombre_Leave(object sender, EventArgs e)
        {
            // Validación al salir del campo nombre
        }

        private void TApellido_Leave(object sender, EventArgs e)
        {
            // Validación al salir del campo apellido
        }

        private void BFiltrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de filtrado no implementada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BRecargar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad de recarga no implementada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
