using HotelCalifornia.Models;
using HotelCalifornia.Services;
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

namespace HotelCalifornia
{
    public partial class CrearReservaForm : Form
    {
        int idClienteSeleccionado;
        public CrearReservaForm(int idCliente)
        {
            InitializeComponent();
            cargarHabitaciones();
            idClienteSeleccionado = idCliente;
            if (idCliente != 0) {
                cargarCliente();
            }
        }

        private void cargarCliente()
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
                    FROM Cliente
                    WHERE id_cliente = @ID_cliente";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID_cliente", idClienteSeleccionado);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Mostrar cliente en los campos
                        TNombre.Text = reader["nombre"].ToString();
                        TApellido.Text = reader["apellido"].ToString();
                        TDni.Text = reader["dni"].ToString();
                        TTelefono.Text = reader["telefono"].ToString();
                        TEmail.Text = reader["email"].ToString();
                    }                    
                }
            }
        }

        // Cargar habitaciones disponibles en la grilla
        private void cargarHabitaciones()
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
                    INNER JOIN TipoHabitacion t ON h.id_tipo = t.id_tipo
                    WHERE h.id_estado = 1";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GrillaHabDisp.AutoGenerateColumns = false;
                GrillaHabDisp.DataSource = dt;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(TApellido.Text) || string.IsNullOrEmpty(TNombre.Text))
            {
                MessageBox.Show("Debe ingresar nombre y apellido.");
                return false;
            }

            if (!SoloLetras(TApellido.Text) || !SoloLetras(TNombre.Text))
            {
                MessageBox.Show("Solo se permiten letras para nombre y apellido.");
                return false;
            }

            if (!SoloNumeros(TTelefono.Text))
            {
                MessageBox.Show("Solo se permiten números en el teléfono.");
                return false;
            }

            if (!EsEmailValido(TEmail.Text))
            {
                MessageBox.Show("El correo electrónico no tiene un formato válido.");
                return false;
            }
            return true;
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

        private void CrearReservaForm_Load(object sender, EventArgs e)
        {
            cargarHabitaciones();
        }

        private void GrillaHabDisp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GrillaHabDisp.Columns["Reservar"].Index && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell checkCell =
                    (DataGridViewCheckBoxCell)GrillaHabDisp.Rows[e.RowIndex].Cells["Reservar"];

                bool valorActual = Convert.ToBoolean(checkCell.Value ?? false);
                checkCell.Value = !valorActual;

                CalcularMontoEstimado(); // si querés recalcular el total al marcar varias
            }
        }

        private List<int> ObtenerHabitacionesSeleccionadas()
        {
            List<int> habitaciones = new List<int>();

            foreach (DataGridViewRow row in GrillaHabDisp.Rows)
            {
                bool seleccionada = Convert.ToBoolean(row.Cells["Reservar"].Value ?? false);
                if (seleccionada)
                {
                    int numeroHab = Convert.ToInt32(row.Cells["numero_hab"].Value);
                    habitaciones.Add(numeroHab);
                }
            }

            return habitaciones;
        }

        private decimal ObtenerPrecioServicio(int idServicio)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();
                string query = "SELECT precio_base FROM Servicio WHERE id_servicio = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idServicio);

                object resultado = cmd.ExecuteScalar();
                if (resultado != null && resultado != DBNull.Value)
                {
                    return Convert.ToDecimal(resultado);
                }
                else
                {
                    return 0; // Si el servicio no existe o no tiene precio
                }
            }
        }

        private void CalcularMontoEstimado()
        {
            decimal monto = 0;

            int noches = CBCantNoches.SelectedItem != null
            ? Convert.ToInt32(CBCantNoches.SelectedItem)
            : 0;

            // Sumar todas las habitaciones seleccionadas
            foreach (DataGridViewRow row in GrillaHabDisp.Rows)
            {
                bool seleccionada = Convert.ToBoolean(row.Cells["Reservar"].Value ?? false);
                if (seleccionada)
                {
                    decimal precioBase = Convert.ToDecimal(row.Cells["base_precio"].Value);
                    monto += precioBase * noches;
                }
            }

            // Sumar servicios según su ID
            if (CHJacuzzi.Checked)
                monto += ObtenerPrecioServicio(1); // Jacuzzi
            if (CHMinibar.Checked)
                monto += ObtenerPrecioServicio(2); // Minibar
            if (CHPool.Checked)
                monto += ObtenerPrecioServicio(3); // Pool

            TMonto.Text = monto.ToString("0.00");
        }

        private int ObtenerOInsertarCliente(SqlConnection conn, SqlTransaction tran)
        {
            string buscar = "SELECT id_cliente FROM Cliente WHERE dni = @dni";
            SqlCommand cmdBuscar = new SqlCommand(buscar, conn, tran);
            cmdBuscar.Parameters.AddWithValue("@dni", TDni.Text);
            object result = cmdBuscar.ExecuteScalar();

            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            
            // Si no existe, se crea
            string insertar = @"INSERT INTO Cliente (dni, nombre, apellido, telefono, email, fecha_alta)
                        OUTPUT INSERTED.id_cliente
                        VALUES (@dni, @nombre, @apellido, @telefono, @email, GETDATE())";

            SqlCommand cmdInsert = new SqlCommand(insertar, conn, tran);
            cmdInsert.Parameters.AddWithValue("@dni", TDni.Text);
            cmdInsert.Parameters.AddWithValue("@nombre", TNombre.Text);
            cmdInsert.Parameters.AddWithValue("@apellido", TApellido.Text);
            cmdInsert.Parameters.AddWithValue("@telefono", TTelefono.Text);
            cmdInsert.Parameters.AddWithValue("@email", TEmail.Text);

            return (int)cmdInsert.ExecuteScalar();
        }

        private int InsertarReserva(SqlConnection conn, SqlTransaction tran, int idCliente)
        {
            string insertar = @"INSERT INTO Reserva (fecha_inicio, fecha_fin, fecha_creacion, id_cliente, legajo, id_estado)
                        OUTPUT INSERTED.id_reserva
                        VALUES (@inicio, @fin, GETDATE(), @cliente, 1001, 2)";

            SqlCommand cmd = new SqlCommand(insertar, conn, tran);
            DateTime hoy = DateTime.Today;
            int noches = Convert.ToInt32(CBCantNoches.SelectedItem);

            cmd.Parameters.AddWithValue("@inicio", hoy);
            cmd.Parameters.AddWithValue("@fin", hoy.AddDays(noches));
            cmd.Parameters.AddWithValue("@cliente", idCliente);

            return (int)cmd.ExecuteScalar();
        }

        private void InsertarReservaHabitacion(SqlConnection conn, SqlTransaction tran, int idReserva, int numeroHab, int noches)
        {
            decimal precioBase = ObtenerPrecioBase(conn, tran, numeroHab);
            decimal subtotal = precioBase * noches;

            string insertar = @"INSERT INTO ReservaHabitacion (id_reserva, numero_hab, precio_noche, cantidad_noches, subtotal)
                        VALUES (@idReserva, @numHab, @precio, @noches, @subtotal)";

            SqlCommand cmd = new SqlCommand(insertar, conn, tran);
            cmd.Parameters.AddWithValue("@idReserva", idReserva);
            cmd.Parameters.AddWithValue("@numHab", numeroHab);
            cmd.Parameters.AddWithValue("@precio", precioBase);
            cmd.Parameters.AddWithValue("@noches", noches);
            cmd.Parameters.AddWithValue("@subtotal", subtotal);
            cmd.ExecuteNonQuery();
        }

        private decimal ObtenerPrecioBase(SqlConnection conn, SqlTransaction tran, int numeroHab)
        {
            //Obtener precio base de la habitación
            string q = @"SELECT t.base_precio 
                 FROM Habitacion h
                 JOIN TipoHabitacion t ON h.id_tipo = t.id_tipo
                 WHERE h.numero_hab = @num";

            SqlCommand cmd = new SqlCommand(q, conn, tran);
            cmd.Parameters.AddWithValue("@num", numeroHab);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        private void InsertarServicios(SqlConnection conn, SqlTransaction tran, int idReserva)
        {
            AgregarServicio(conn, tran, idReserva, CHJacuzzi, 1);
            AgregarServicio(conn, tran, idReserva, CHMinibar, 2);
            AgregarServicio(conn, tran, idReserva, CHPool, 3);
        }

        private void AgregarServicio(SqlConnection conn, SqlTransaction tran, int idReserva, CheckBox chk, int idServicio)
        {
            if (!chk.Checked) return;

            string sql = @"INSERT INTO ReservaServicio (id_reserva, id_servicio, cantidad, precio_unitario, subtotal)
                   SELECT @reserva, id_servicio, 1, precio_base, precio_base
                   FROM Servicio WHERE id_servicio = @servicio";

            SqlCommand cmd = new SqlCommand(sql, conn, tran);
            cmd.Parameters.AddWithValue("@reserva", idReserva);
            cmd.Parameters.AddWithValue("@servicio", idServicio);
            cmd.ExecuteNonQuery();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            List<int> habitacionesSeleccionadas = ObtenerHabitacionesSeleccionadas();

            if (habitacionesSeleccionadas.Count == 0)
            {
                MessageBox.Show("Seleccione al menos una habitación antes de guardar.");
                return;
            }

            int noches = Convert.ToInt32(CBCantNoches.SelectedItem);
            if (noches <= 0)
            {
                MessageBox.Show("La cantidad de noches debe ser mayor que 0");
                return;
            }

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // Obtener o crear cliente
                    int idCliente = ObtenerOInsertarCliente(conn, tran);

                    // Insertar reserva
                    int idReserva = InsertarReserva(conn, tran, idCliente);

                    // Insertar habitaciones seleccionadas
                    foreach (int numeroHabitacion in habitacionesSeleccionadas)
                    {
                        InsertarReservaHabitacion(conn, tran, idReserva, numeroHabitacion, noches);

                        // Actualizar estado de la habitación a ocupada
                        string update = @"UPDATE Habitacion SET id_estado = 2 WHERE numero_hab = @num";
                        SqlCommand cmdUpdate = new SqlCommand(update, conn, tran);
                        cmdUpdate.Parameters.AddWithValue("@num", numeroHabitacion);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    // Insertar servicios seleccionados
                    InsertarServicios(conn, tran, idReserva);

                    // actualizar total en la tabla Reserva
                    decimal totalHabitaciones = 0;
                    decimal totalServicios = 0;

                    // Sumar habitaciones
                    string qTotalHab = @"SELECT ISNULL(SUM(subtotal), 0) FROM ReservaHabitacion WHERE id_reserva = @id";
                    SqlCommand cmdHab = new SqlCommand(qTotalHab, conn, tran);
                    cmdHab.Parameters.AddWithValue("@id", idReserva);
                    totalHabitaciones = Convert.ToDecimal(cmdHab.ExecuteScalar());

                    // Sumar servicios
                    string qTotalServ = @"
                        SELECT ISNULL(SUM(subtotal), 0)
                        FROM ReservaServicio
                        WHERE id_reserva = @id";
                    SqlCommand cmdServ = new SqlCommand(qTotalServ, conn, tran);
                    cmdServ.Parameters.AddWithValue("@id", idReserva);
                    totalServicios = Convert.ToDecimal(cmdServ.ExecuteScalar());

                    // Total general
                    decimal totalFinal = totalHabitaciones + totalServicios;

                    // Actualizar en la tabla Reserva
                    string qUpdateTotal = @"UPDATE Reserva SET total = @total WHERE id_reserva = @id";
                    SqlCommand cmdUpdateTotal = new SqlCommand(qUpdateTotal, conn, tran);
                    cmdUpdateTotal.Parameters.AddWithValue("@total", totalFinal);
                    cmdUpdateTotal.Parameters.AddWithValue("@id", idReserva);
                    cmdUpdateTotal.ExecuteNonQuery();

                    tran.Commit();
                    MessageBox.Show("Reserva guardada correctamente. Total: $" + totalFinal.ToString("N2"));
                    cargarHabitaciones();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Error al guardar la reserva: " + ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void CHJacuzzi_CheckedChanged(object sender, EventArgs e)
        {
            CalcularMontoEstimado(); // Llamar a la función para recalcular el monto
        }
        
        private void CHMinibar_CheckedChanged(object sender, EventArgs e)
        {
            CalcularMontoEstimado(); // Llamar a la función para recalcular el monto
        }
        
        private void CHPool_CheckedChanged(object sender, EventArgs e)
        {
            CalcularMontoEstimado(); // Llamar a la función para recalcular el monto
        }

        private void CBCantNoches_SelectedItemChanged(object sender, EventArgs e)
        {
            CalcularMontoEstimado(); // Llamar a la función para recalcular el monto
        }

        private void GrillaHabDisp_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (GrillaHabDisp.IsCurrentCellDirty)
            {
                GrillaHabDisp.CommitEdit(DataGridViewDataErrorContexts.Commit);
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

        private void BListaClientes_Click(object sender, EventArgs e)
        {
            using (ListaClientes frmLista = new ListaClientes())
            {
                if (frmLista.ShowDialog() == DialogResult.OK)
                {
                    idClienteSeleccionado = frmLista.IdClienteSeleccionado;
                    cargarCliente();
                }
            }
        }
    }
}
