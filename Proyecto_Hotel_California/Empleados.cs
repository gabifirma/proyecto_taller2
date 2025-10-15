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

namespace HotelCalifornia
{
    public partial class Empleados : BaseResponsiveForm
    {
        public Empleados()
        {
            InitializeComponent();
            CargarEmpleados();
            ConfigurarMenuContextual();
            // Agregar evento para manejar tecla Delete
            GrillaEmpleados.KeyDown += GrillaEmpleados_KeyDown;
            // La clase base BaseResponsiveForm se encarga del responsive design automáticamente
        }

        private void CargarEmpleados()
        {
            try
            {
                DataTable dt = DatabaseHelper.GetAllEmpleados();
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    GrillaEmpleados.AutoGenerateColumns = false;
                    GrillaEmpleados.DataSource = dt;

                    // Recorremos las filas y aplicamos color según el estado
                    foreach (DataGridViewRow row in GrillaEmpleados.Rows)
                    {
                        if (row.Cells["estado"].Value == null) continue;

                        int estado = Convert.ToInt32(row.Cells["estado"].Value);

                        switch (estado)
                        {
                            case 1: row.DefaultCellStyle.BackColor = Color.LightGreen; break; // Activado
                            case 0: row.DefaultCellStyle.BackColor = Color.LightCoral; break; // Desactivado
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Abrir el nuevo formulario de agregar empleado con opción de crear usuario
            AgregarEmpleadoConUsuario formAgregar = new AgregarEmpleadoConUsuario();
             if (formAgregar.ShowDialog() == DialogResult.OK)
             {
                 // Recargar la grilla de empleados después de agregar
                 CargarEmpleados();
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

        private void BFiltrar_Click(object sender, EventArgs e)
        {
            string valor = TBuscar.Text.Trim();

            if (string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("Ingrese un dato a buscar", "Información", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    conn.Open();

                    string query = @"SELECT e.legajo, e.apellido, e.nombre, e.telefono, e.email, e.estado,
                                   CASE WHEN u.id_usuario IS NOT NULL THEN 'Sí' ELSE 'No' END as tiene_usuario
                         FROM Empleado e
                         LEFT JOIN Usuario u ON e.legajo = u.legajo
                         WHERE e.apellido LIKE @valor OR e.nombre LIKE @valor OR 
                               CAST(e.legajo AS VARCHAR) LIKE @valor OR 
                               CAST(e.telefono AS VARCHAR) LIKE @valor OR e.email LIKE @valor";

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
                    
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron empleados con ese criterio de búsqueda.", 
                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}", "Error", 
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BRecargar_Click(object sender, EventArgs e)
        {
            TBuscar.Clear();
            CargarEmpleados();
        }

        // Agregar método para eliminar empleado con botón derecho o tecla Delete
        private void GrillaEmpleados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && GrillaEmpleados.SelectedRows.Count > 0)
            {
                EliminarEmpleadoSeleccionado();
            }
        }

        private void EliminarEmpleadoSeleccionado()
        {
            if (GrillaEmpleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado para eliminar.", "Información",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow row = GrillaEmpleados.SelectedRows[0];
            int legajo = Convert.ToInt32(row.Cells["legajo"].Value);
            string nombre = row.Cells["nombre"].Value.ToString();
            string apellido = row.Cells["apellido"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"¿Está seguro que desea desactivar al empleado {nombre} {apellido}?\n\n" +
                "Nota: Si el empleado tiene un usuario asociado, primero debe eliminar el usuario.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool resultado = DatabaseHelper.DeleteEmpleado(legajo);
                    if (resultado)
                    {
                        MessageBox.Show("Empleado desactivado exitosamente.", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarEmpleados();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Agregar menú contextual para opciones adicionales
        private void ConfigurarMenuContextual()
        {
            ContextMenuStrip menuContextual = new ContextMenuStrip();
            
            ToolStripMenuItem itemEditar = new ToolStripMenuItem("Editar Empleado");
            itemEditar.Click += (s, e) => {
                if (GrillaEmpleados.SelectedRows.Count > 0)
                {
                    int legajo = Convert.ToInt32(GrillaEmpleados.SelectedRows[0].Cells["legajo"].Value);
                    EditarEmp frm = new EditarEmp(legajo);
                    frm.ShowDialog();
                    CargarEmpleados();
                }
            };
            
            ToolStripMenuItem itemEliminar = new ToolStripMenuItem("Desactivar Empleado");
            itemEliminar.Click += (s, e) => EliminarEmpleadoSeleccionado();
            
            ToolStripMenuItem itemCrearUsuario = new ToolStripMenuItem("Crear Usuario para este Empleado");
            itemCrearUsuario.Click += (s, e) => {
                if (GrillaEmpleados.SelectedRows.Count > 0)
                {
                    // Verificar si ya tiene usuario
                    DataGridViewRow row = GrillaEmpleados.SelectedRows[0];
                    if (row.Cells["tiene_usuario"] != null && row.Cells["tiene_usuario"].Value.ToString() == "Sí")
                    {
                        MessageBox.Show("Este empleado ya tiene un usuario asignado.", "Información",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    
                    int legajo = Convert.ToInt32(row.Cells["legajo"].Value);
                    // Aquí podrías abrir un formulario para crear usuario para este empleado específico
                    MessageBox.Show($"Funcionalidad para crear usuario para el empleado con legajo {legajo}", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
            
            menuContextual.Items.Add(itemEditar);
            menuContextual.Items.Add(itemEliminar);
            menuContextual.Items.Add(new ToolStripSeparator());
            menuContextual.Items.Add(itemCrearUsuario);
            
            GrillaEmpleados.ContextMenuStrip = menuContextual;
        }
    }
}
