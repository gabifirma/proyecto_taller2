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

namespace Proyecto_Hotel_California
{
    public partial class EditarEmp : Form
    {
        private int empleadoId;
        public EditarEmp(int id)
        {
            InitializeComponent();
            empleadoId = id;
            CargarEmpleado();
        }

        private void CargarEmpleado()
        {
            string conexion = "Server=DESKTOP-9V9JJ39\\SQLEXPRESS;Database=Hotel;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                conn.Open();
                string query = "SELECT apellido, nombre, legajo, telefono, email, estado FROM Empleado WHERE id_empleado = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", empleadoId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        LID.Text = empleadoId.ToString();
                        TApellido.Text = reader["Apellido"].ToString();
                        TNombre.Text = reader["Nombre"].ToString();
                        TLegajo.Text = reader["Legajo"].ToString();
                        TTelefono.Text = reader["Telefono"].ToString();
                        TEmail.Text = reader["Email"].ToString();
                        if (reader["estado"].Equals(true))
                        {
                            RBActivado.Checked = true;                          
                        }
                        else
                        {
                            RBDesactivado.Checked = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el empleado con ese ID.");
                        this.Close();
                    }
                }
            }
        }

        private bool SoloLetras(string texto)
        {
            return Regex.IsMatch(texto, @"^[a-zA-Z]+$");
        }

        private bool SoloNumeros(string texto)
        {
            return Regex.IsMatch(texto, @"^[0-9]+$");
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BFin_Click(object sender, EventArgs e)
        {
            if (!SoloLetras(TApellido.Text) || !SoloLetras(TNombre.Text))
            {
                MessageBox.Show("Solo se permiten letras para nombre y apellido");
                return;
            }

            if (!SoloNumeros(TTelefono.Text))
            {
                MessageBox.Show("Solo se permiten números para teléfono");
                return;
            }

            if (!SoloNumeros(TLegajo.Text))
            {
                MessageBox.Show("Solo se permiten números para legajo");
                return;
            }

            //guardarlo todo en la base de datos
            if (SoloLetras(TApellido.Text) && SoloLetras(TNombre.Text) && SoloNumeros(TLegajo.Text) && SoloNumeros(TTelefono.Text))
            {
                string conexion = "Server=DESKTOP-9V9JJ39\\SQLEXPRESS;Database=Hotel;Trusted_Connection=True;";

                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    conn.Open();
                    string query = @"UPDATE Empleado 
                         SET apellido=@Apellido, nombre=@Nombre, legajo=@Legajo, telefono=@Telefono, email=@Email, estado=@Estado
                         WHERE id_empleado=@Id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Apellido", TApellido.Text);
                        cmd.Parameters.AddWithValue("@Nombre", TNombre.Text);
                        cmd.Parameters.AddWithValue("@Legajo", TLegajo.Text);
                        cmd.Parameters.AddWithValue("@Telefono", TTelefono.Text);
                        cmd.Parameters.AddWithValue("@Email", TEmail.Text);
                        cmd.Parameters.AddWithValue("@Id", empleadoId);
                        if (RBActivado.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Estado", true);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Estado", false);
                        }

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("Empleado actualizado correctamente.");
                            this.Close(); // cierra el form de edición
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el empleado.");
                        }
                    }
                }
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

        private void TNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TNombre.Text))
            {
                string texto = TNombre.Text.ToLower(); // todo en minúscula
                TNombre.Text = char.ToUpper(texto[0]) + texto.Substring(1); // primera en mayúscula
            }
        }
    }
}
