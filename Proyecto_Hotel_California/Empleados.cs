using HotelCalifornia.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HotelCalifornia
{
    public partial class Empleados : BaseResponsiveForm
    {
        public Empleados()
        {
            InitializeComponent();
            CargarEmpleados();
            // La clase base BaseResponsiveForm se encarga del responsive design automáticamente
        }

        private void CargarEmpleados()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                string query = "SELECT legajo, apellido, nombre, telefono, email, estado FROM Empleado";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GrillaEmpleados.AutoGenerateColumns = false;
                GrillaEmpleados.DataSource = dt;

                // Recorremos las filas y aplicamos color según el estado
                foreach (DataGridViewRow row in GrillaEmpleados.Rows)
                {
                    if (row.Cells["estado"].Value != null && !(bool)row.Cells["estado"].Value)
                    {
                        // Si el empleado está inactivo => rojo
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        private bool EsEmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            string patron = @"^(?!.*\.\.)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            return Regex.IsMatch(email, patron);
        }

        private bool SoloLetras(string texto)
        {
            return Regex.IsMatch(texto, @"^[a-zA-Z]+$");
        }

        private bool SoloNumeros(string texto)
        {
            return Regex.IsMatch(texto, @"^[0-9]+$");
        }

        private void BAgregarEmp_Click(object sender, EventArgs e)
        {
            Boolean valorApellido = !String.IsNullOrEmpty(TApellido.Text);
            Boolean valorNombre = !String.IsNullOrEmpty(TNombre.Text);
            Boolean valorLegajo = int.TryParse(TLegajo.Text, out int legajo);
            Boolean valorTelefono = !String.IsNullOrEmpty(TTelefono.Text);
            Boolean valorEmail = !String.IsNullOrEmpty(TEmail.Text);

            if (!valorApellido)
            {
                MessageBox.Show("El campo APELLIDO no puede estar vacío.");
                return;
            }

            if (!valorNombre)
            {
                MessageBox.Show("El campo NOMBRE no puede estar vacío.");
                return;
            }

            if (!SoloLetras(TApellido.Text) || !SoloLetras(TNombre.Text))
            {
                MessageBox.Show("Solo se permiten letras para nombre y apellido");
                return;
            }

            if (!valorTelefono)
            {
                MessageBox.Show("El campo TELÉFONO no puede estar vacío");
                return;
            }

            if (!SoloNumeros(TTelefono.Text))
            {
                MessageBox.Show("Solo se permiten números para teléfono");
                return;
            }

            if (!valorEmail)
            {
                MessageBox.Show("Campo EMAIL vacío");
                return;
            }

            if (!valorLegajo)
            {
                MessageBox.Show("El LEGAJO o esta vacío o no es un número");
                return;
            }

            if (!EsEmailValido(TEmail.Text))
            {
                MessageBox.Show("El EMAIL no tiene un formato válido");
                return;
            }

            //guardarlo todo en la base de datos
            if (SoloLetras(TApellido.Text) && SoloLetras(TNombre.Text) && valorLegajo && SoloNumeros(TTelefono.Text) && valorEmail)
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();

                    // Primero verificamos si el legajo ya existe
                    string checkQuery = "SELECT COUNT(*) FROM Empleado WHERE legajo = @Legajo";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Legajo", TLegajo.Text);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("El legajo ya existe. Ingrese un valor único.");
                            return;
                        }
                    }
                }

                    // Cambia la cadena de conexión por la de tu base de datos
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();

                    string query = "INSERT INTO Empleado (apellido, nombre, legajo, telefono, email, estado) " +
                                    "VALUES (@Apellido, @Nombre, @Legajo, @Telefono, @Email, @Estado)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Apellido", TApellido.Text);
                        cmd.Parameters.AddWithValue("@Nombre", TNombre.Text);
                        cmd.Parameters.AddWithValue("@Legajo", TLegajo.Text);
                        cmd.Parameters.AddWithValue("@Telefono", TTelefono.Text);
                        cmd.Parameters.AddWithValue("@Email", TEmail.Text);
                        cmd.Parameters.AddWithValue("@Estado", true);

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("Empleado guardado correctamente en la base de datos.");

                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el empleado.");
                        }
                        this.Close();
                    }
                }
            }
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void GrillaEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Funcionalidad para doble clic en la grilla
            if (e.RowIndex >= 0) // para evitar encabezados
            {
                // Obtener el valor de la columna ID (o Legajo) de la fila seleccionada
                int empleadoLegajo = Convert.ToInt32(GrillaEmpleados.Rows[e.RowIndex].Cells["legajo"].Value);

                // Abrir el formulario de edición y pasarle el Id
                EditarEmp frm = new EditarEmp(empleadoLegajo);
                frm.ShowDialog();

                // Opcional: refrescar el DataGridView después de editar
                CargarEmpleados();
            }
        }

        private void TNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TNombre.Text))
            {
                string texto = TNombre.Text.ToLower(); // todo en minúscula
                TNombre.Text = char.ToUpper(texto[0]) + texto.Substring(1); // primera en mayúscula
            }
        }

        private void TApellido_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TApellido.Text))
            {
                string texto = TApellido.Text.ToLower(); // todo en minúscula
                TApellido.Text = char.ToUpper(texto[0]) + texto.Substring(1); // primera en mayúscula
            }
        }

        private void BFiltrar_Click(object sender, EventArgs e)
        {
            string valor = TBuscar.Text.Trim();

            if (string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("Ingrese un dato a buscar");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();

                    string query = @"SELECT legajo, apellido, nombre, telefono, email, estado 
                         FROM Empleado
                         WHERE apellido LIKE @valor OR nombre LIKE @valor OR legajo LIKE @valor OR telefono LIKE @valor OR email LIKE @valor";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@valor", "%" + valor + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GrillaEmpleados.AutoGenerateColumns = false;
                    GrillaEmpleados.DataSource = dt;

                    // Recorremos las filas y aplicamos color según el estado
                    foreach (DataGridViewRow row in GrillaEmpleados.Rows)
                    {
                        if (row.Cells["estado"].Value != null && !(bool)row.Cells["estado"].Value)
                        {
                            // Si el empleado está inactivo => rojo
                            row.DefaultCellStyle.BackColor = Color.Red;
                            row.DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                }
            }
        }

        private void BRecargar_Click(object sender, EventArgs e)
        {
            TBuscar.Clear();
            CargarEmpleados();
        }
    }
}
