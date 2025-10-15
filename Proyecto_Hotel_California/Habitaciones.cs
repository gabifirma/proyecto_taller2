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
    public partial class Habitaciones : BaseResponsiveForm
    {
        public Habitaciones()
        {
            InitializeComponent();
            CargarHabitaciones();
            // La clase base BaseResponsiveForm se encarga del responsive design automáticamente
        }

        private void CargarHabitaciones()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                string query = @"SELECT 
                    h.numero_hab, 
                    h.piso, 
                    h.id_estado, 
                    t.nombre, 
                    t.capacidad, 
                    t.descripcion,
                    t.base_precio
                 FROM Habitacion h
                 INNER JOIN TipoHabitacion t ON h.id_tipo = t.id_tipo";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GrillaHabitaciones.AutoGenerateColumns = false;
                GrillaHabitaciones.DataSource = dt;

                // Recorremos las filas y aplicamos color según el estado
                foreach (DataGridViewRow row in GrillaHabitaciones.Rows)
                {
                    if (row.Cells["id_estado"].Value == null) continue;

                    int estado = Convert.ToInt32(row.Cells["id_estado"].Value);

                    switch (estado)
                    {
                        case 1: row.DefaultCellStyle.BackColor = Color.LightGreen; break; // Libre
                        case 2: row.DefaultCellStyle.BackColor = Color.Khaki; break; // Ocupada
                        case 3: row.DefaultCellStyle.BackColor = Color.LightCoral; break; // Inhabilitada
                    }
                }
            }
        }

        private void BAgregarHab_Click(object sender, EventArgs e)
        {
            Boolean valorNum = int.TryParse(TNumero.Text, out int num);

            if (!valorNum)
            {
                MessageBox.Show("El NÚMERO o esta vacío o no es un número");
                return;
            }

            int piso = num / 100;

            if (valorNum)
            {
                // Cambia la cadena de conexión por la de tu base de datos
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();

                    string query = "INSERT INTO Habitacion (numero_hab, piso, id_tipo, id_estado) " +
                                   "VALUES (@Numero_hab, @Piso, @Id_tipo, @Id_estado)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Numero_hab", TNumero.Text);
                        cmd.Parameters.AddWithValue("@Piso", piso);
                        if (RBSingle.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Id_tipo", 1);
                        }
                        else if (RBDoble.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Id_tipo", 2);
                        }
                        else if (RBSuite.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Id_tipo", 3);
                        }

                        if (RBDisp.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Id_estado", 1);
                        }
                        else if (RBOcup.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Id_estado", 2);
                        }
                        else if (RBInha.Checked)
                        {
                            cmd.Parameters.AddWithValue("@Id_estado", 3);
                        }

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show("Habitación guardada correctamente en la base de datos.");

                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar la habitación.");
                        }
                        this.Close();
                    }
                }
            }
            CargarHabitaciones();
        }

        private int GenerarNumeroHabitacion(int piso, int numeroEnPiso)
        {
            // Si el piso es menor a 10 → formato como 101, 205, etc.
            // Si el piso tiene dos dígitos → 1203, etc.
            return int.Parse($"{piso}{numeroEnPiso:D2}");
        }

        private void Habitaciones_Load(object sender, EventArgs e)
        {
            CargarHabitaciones();
        }

        private void GrillaHabitaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // para evitar encabezados
            {
                // Obtener el valor de la columna numero_hab de la fila seleccionada
                int habitacionNumero = Convert.ToInt32(GrillaHabitaciones.Rows[e.RowIndex].Cells["numero_hab"].Value);

                // Abrir el formulario de edición y pasarle el numero de habitación
                EditarHab frm = new EditarHab(habitacionNumero);
                frm.ShowDialog();
            }
            CargarHabitaciones();
        }
    }
}
