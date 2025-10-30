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
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelCalifornia
{
    public partial class Reservas : BaseResponsiveForm
    {
        public Reservas()
        {
            InitializeComponent();
            CargarReservas();
        }

        private bool SoloLetras(string texto)
        {
            return Regex.IsMatch(texto, @"^[a-zA-Z]+$");
        }

        private void CargarReservas()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                string query = @"
                        SELECT 
                            R.id_reserva AS ID,
                            R.fecha_inicio AS Inicio,
                            R.fecha_fin AS Fin,
                            R.id_estado AS Estado,
                            R.total AS Total,
                            C.nombre AS Nombre,
                            C.apellido AS Apellido,
                            STRING_AGG(CONVERT(varchar, H.numero_hab), ', ') AS Habitaciones,
                            STRING_AGG(TH.nombre, ', ') AS Tipos,
                            SUM(RH.subtotal) AS Subtotal
                        FROM Reserva R
                        INNER JOIN Cliente C ON R.id_cliente = C.id_cliente
                        INNER JOIN ReservaHabitacion RH ON R.id_reserva = RH.id_reserva
                        INNER JOIN Habitacion H ON RH.numero_hab = H.numero_hab
                        INNER JOIN TipoHabitacion TH ON H.id_tipo = TH.id_tipo
                        GROUP BY 
                            R.id_reserva, R.fecha_inicio, R.fecha_fin, R.id_estado, C.nombre, C.apellido, R.total
                        ORDER BY R.id_reserva DESC;";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GrillaReservas.AutoGenerateColumns = false;
                GrillaReservas.DataSource = dt;

                // Colorear según estado
                foreach (DataGridViewRow row in GrillaReservas.Rows)
                {
                    if (row.Cells["Estado"].Value == null) continue;

                    int estado = Convert.ToInt32(row.Cells["Estado"].Value);

                    switch (estado)
                    {
                        case 1: row.DefaultCellStyle.BackColor = Color.LightGreen; break; // Confirmada
                        case 2: row.DefaultCellStyle.BackColor = Color.Khaki; break; // En espera
                        case 3: row.DefaultCellStyle.BackColor = Color.LightCoral; break; // Terminada/Cancelada
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                // Construimos la consulta base
                string query = @"SELECT
                        R.id_reserva AS ID,
                        R.fecha_inicio AS Inicio,
                        R.fecha_fin AS Fin,
                        R.fecha_creacion AS fecha_creacion,
                        R.id_estado AS Estado,
                        R.total AS Total,
                        C.nombre AS Nombre,
                        C.apellido AS Apellido,
                        H.numero_hab AS Habitaciones,
                        TH.nombre AS Tipos,
                        RH.subtotal AS Subtotal                        
                    FROM Reserva R
                    INNER JOIN Cliente C ON R.id_cliente = C.id_cliente
                    INNER JOIN ReservaHabitacion RH ON R.id_reserva = RH.id_reserva
                    INNER JOIN Habitacion H ON RH.numero_hab = H.numero_hab
                    INNER JOIN TipoHabitacion TH ON H.id_tipo = TH.id_tipo
                    WHERE 1=1";

                // Creamos el comando
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // Filtro por fechas
                if (dtpFechaInicio.Value <= dtpFechaFin.Value) // rango de fechas
                {
                    query += " AND R.fecha_creacion BETWEEN @desde AND @hasta";
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

                // Filtro por nombre
                if (!string.IsNullOrEmpty(TNombre.Text))
                {
                    if (!SoloLetras(TNombre.Text))
                    {
                        MessageBox.Show("El campo 'Nombre' debe ser solo letras.",
                        "Error de validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        query += " AND C.nombre LIKE @nombre";
                        cmd.Parameters.AddWithValue("@nombre", "%" + TNombre.Text.Trim() + "%");
                    }                        
                }
                
                // Filtro por apellido
                if (!string.IsNullOrEmpty(TApellido.Text))
                {
                    if (!SoloLetras(TApellido.Text))
                    {
                        MessageBox.Show("El campo 'Apellido' debe ser solo letras.",
                        "Error de validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        query += " AND C.apellido LIKE @apellido";
                        cmd.Parameters.AddWithValue("@apellido", "%" + TApellido.Text.Trim() + "%");
                    }                        
                }               

                // Filtro por método de pago
                if (RBSingle.Checked)
                {
                    query += " AND H.id_tipo= 1";
                }
                else if (RBDoble.Checked)
                {
                    query += " AND H.id_tipo = 2";
                }
                else if (RBSuite.Checked)
                {
                    query += " AND H.id_tipo = 3";
                }

                // Aplicamos la consulta final
                query += " ORDER BY R.fecha_creacion DESC";
                cmd.CommandText = query;

                // Llenamos el DataTable y lo mostramos
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                GrillaReservas.AutoGenerateColumns = false;
                GrillaReservas.DataSource = dt;

                // Recorremos las filas y aplicamos color según el estado
                foreach (DataGridViewRow row in GrillaReservas.Rows)
                {
                    if (row.Cells["Estado"].Value == null) continue;

                    int estado = Convert.ToInt32(row.Cells["Estado"].Value);

                    switch (estado)
                    {
                        case 1: row.DefaultCellStyle.BackColor = Color.LightGreen; break; // Confirmada
                        case 2: row.DefaultCellStyle.BackColor = Color.Khaki; break; // En espera
                        case 3: row.DefaultCellStyle.BackColor = Color.LightCoral; break; // Terminada
                    }
                }
            }
        }

        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            //se pasa 0 para indicar que no hay cliente preseleccionado
            CrearReservaForm frm = new CrearReservaForm(0);
            frm.ShowDialog();
        }

        private void GrillaReservas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (e.RowIndex >= 0) // evitar encabezado
            {
                // Obtener ID de la reserva seleccionada
                int numReserva = Convert.ToInt32(GrillaReservas.Rows[e.RowIndex].Cells["ID"].Value);

                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();

                    // Consultar el estado actual de la reserva
                    string query = "SELECT id_estado FROM Reserva WHERE id_reserva = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", numReserva);

                    object estadoObj = cmd.ExecuteScalar();
                    if (estadoObj == null)
                    {
                        MessageBox.Show("No se encontró la reserva seleccionada.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int estadoActual = Convert.ToInt32(estadoObj);

                    // Validar estados permitidos (2 = En espera)
                    if (estadoActual == 2)
                    {
                        CrearPagoForm frm = new CrearPagoForm(numReserva);
                        frm.ShowDialog();

                        // refrescar la grilla
                        CargarReservas();
                    }
                    else
                    {
                        string mensaje = estadoActual == 3
                            ? "No se puede registrar un pago porque la reserva ya está terminada."
                            : "No se puede registrar un pago porque la reserva está activa.";
                        MessageBox.Show(mensaje,
                            "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void Reservas_Load(object sender, EventArgs e)
        {
            CargarReservas();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            TNombre.Clear();
            TApellido.Clear();
            RBSingle.Checked = true;
            RBDoble.Checked = false;
            RBSuite.Checked = false;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            CargarReservas();
        }

        private void TerminarReserva(int idReserva)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // Verificamos el estado actual de la reserva
                    string queryEstado = @"SELECT id_estado FROM Reserva WHERE id_reserva = @id";
                    SqlCommand cmdEstado = new SqlCommand(queryEstado, conn, tran);
                    cmdEstado.Parameters.AddWithValue("@id", idReserva);

                    object estadoObj = cmdEstado.ExecuteScalar();
                    if (estadoObj == null)
                    {
                        MessageBox.Show("No se encontró la reserva seleccionada.");
                        tran.Rollback();
                        return;
                    }

                    int estadoActual = Convert.ToInt32(estadoObj);

                    // Validamos si se puede terminar
                    // estados: 1 = Activa, 2 = En espera, 3 = Terminada
                    if (estadoActual == 3)
                    {
                        MessageBox.Show("La reserva ya está terminada.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tran.Rollback();
                        return;
                    }
                    
                    // Actualizamos la reserva a estado 3 (terminada)
                    string queryReserva = @"UPDATE Reserva SET id_estado = 3 WHERE id_reserva = @id";
                    SqlCommand cmdReserva = new SqlCommand(queryReserva, conn, tran);
                    cmdReserva.Parameters.AddWithValue("@id", idReserva);
                    cmdReserva.ExecuteNonQuery();

                    // Obtenemos las habitaciones asociadas
                    string queryHab = @"SELECT numero_hab FROM ReservaHabitacion WHERE id_reserva = @id";
                    SqlCommand cmdHab = new SqlCommand(queryHab, conn, tran);
                    cmdHab.Parameters.AddWithValue("@id", idReserva);

                    List<int> habitaciones = new List<int>();
                    using (SqlDataReader reader = cmdHab.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            habitaciones.Add(Convert.ToInt32(reader["numero_hab"]));
                        }
                    }

                    // Actualizamos las habitaciones a "disponible" (id_estado = 1)
                    foreach (int numHab in habitaciones)
                    {
                        string updateHab = @"UPDATE Habitacion SET id_estado = 1 WHERE numero_hab = @num";
                        SqlCommand cmdUpdateHab = new SqlCommand(updateHab, conn, tran);
                        cmdUpdateHab.Parameters.AddWithValue("@num", numHab);
                        cmdUpdateHab.ExecuteNonQuery();
                    }

                    tran.Commit();

                    MessageBox.Show("Reserva marcada como terminada y habitaciones actualizadas.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarReservas(); // refresca la grilla
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error al terminar la reserva: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BActualizar_Click(object sender, EventArgs e)
        {
            CargarReservas();
        }

        private void BFinalizar_Click(object sender, EventArgs e)
        {
            // Obtener ID de la reserva escrita
            Boolean valorNum = int.TryParse(TReservaN.Text, out int idReserva);

            if (!valorNum)
            {
                MessageBox.Show("Se necesita un dato númerico para continuar");
                return;
            }

            // Verificar existencia para evitar errores
            if (!DatabaseHelper.ReservaExiste(idReserva))
            {
                MessageBox.Show($"La reserva {idReserva} NO existe en la base de datos.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();

                // Consultar el estado actual de la reserva
                string query = "SELECT id_estado FROM Reserva WHERE id_reserva = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idReserva);

                object estadoObj = cmd.ExecuteScalar();
                if (estadoObj == null)
                {
                    MessageBox.Show("No se encontró la reserva seleccionada.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int estadoActual = Convert.ToInt32(estadoObj);

                // Validar estados permitidos (2 = En espera, 1 = Activa)
                if (estadoActual == 2 || estadoActual == 1)
                {
                    DialogResult result = MessageBox.Show(
                        $"¿Desea marcar la reserva N° {idReserva} como terminada/cancelada?",
                        "Confirmar acción",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        TerminarReserva(idReserva);
                    }
                    // refrescar la grilla y limpiar campo
                    TReservaN.Clear();
                    CargarReservas();
                }
                else
                {
                    string mensaje = "La reserva ya está terminada/cancelada.";
                    MessageBox.Show(mensaje,
                        "Operación no permitida", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information
                    );
                }
            }
        }
    }
}
