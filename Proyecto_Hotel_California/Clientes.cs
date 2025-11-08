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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HotelCalifornia
{
    /// <summary>
    /// Formulario para la gestión de clientes del hotel.
    /// Permite visualizar, buscar y filtrar la información de los clientes registrados.
    /// Hereda de BaseResponsiveForm para tener diseño responsivo automático.
    /// </summary>
    public partial class Clientes : BaseResponsiveForm
    {
        /// <summary>
        /// Constructor del formulario de clientes.
        /// Inicializa los componentes y configura el diseño responsivo.
        /// </summary>
        public Clientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            c.id_cliente,
                            c.dni,
                            c.telefono,
                            c.email,
                            c.nombre,
                            c.apellido,
                            c.fecha_alta AS fechaAlta
                        FROM Cliente c
                        WHERE 1=1";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GrillaClientes.AutoGenerateColumns = false;
                    GrillaClientes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            string texto = TBuscar.Text.Trim(); // texto que escribe el usuario

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                // Construir la consulta base con filtros dinámicos
                string query = @"
                    SELECT 
                        c.id_cliente,
                        c.dni,
                        c.telefono,
                        c.email,
                        c.nombre,
                        c.apellido,
                        c.fecha_alta AS fechaAlta
                    FROM Cliente c
                    WHERE 1=1";

                // Creamos el comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // Filtro por fechas
                if (dtpFechaInicio.Value <= dtpFechaFin.Value) // rango de fechas
                {
                    query += " AND c.fecha_alta BETWEEN @desde AND @hasta";
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

                // Filtro de texto general
                if (!string.IsNullOrEmpty(texto))
                {
                    query += @" AND (
                            c.nombre LIKE @texto OR
                            c.apellido LIKE @texto OR
                            c.email LIKE @texto OR
                            c.dni LIKE @texto OR
                            c.telefono LIKE @texto
                        )";
                    cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
                }

                // Orden final
                query += " ORDER BY c.fecha_alta DESC";
                cmd.CommandText = query;

                // Llenar la grilla
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                GrillaClientes.AutoGenerateColumns = false;
                GrillaClientes.DataSource = dt;
            }
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void BActualizar_Click(object sender, EventArgs e)
        {
            TBuscar.Clear();
            dtpFechaFin.Value = DateTime.Today;
            dtpFechaInicio.Value = DateTime.Today;
            CargarClientes();
        }
    }
}
