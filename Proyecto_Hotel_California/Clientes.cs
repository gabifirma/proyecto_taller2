using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using HotelCalifornia.Styles;

namespace HotelCalifornia
{
    public partial class Clientes : BaseResponsiveForm
    {
        public Clientes()
        {
            InitializeComponent();
            // La clase base BaseResponsiveForm se encarga del responsive design automáticamente
        }

        private void Buscar(string texto, DateTime desde, DateTime hasta)
        {
            foreach (DataGridViewRow fila in GrillaClientes.Rows)
            {
                if (fila.IsNewRow) continue; // salta la fila vacía del DataGridView

                // Toma la fecha de la última columna
                DateTime fecha = DateTime.Parse(fila.Cells[6].Value.ToString());

                // Verifica si alguna celda contiene el texto
                bool coincideTexto = false;
                foreach (DataGridViewCell celda in fila.Cells)
                {
                    if (celda.Value != null && celda.Value.ToString().ToLower().Contains(texto.ToLower()))
                    {
                        coincideTexto = true;
                        break;
                    }
                }

                // Mostrar u ocultar fila según condiciones
                if (desde > hasta)
                {
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta'.", 
                        "Error de búsqueda", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }

                if (coincideTexto && fecha >= desde && fecha <= hasta)
                {
                    fila.Visible = true;
                }
                else
                {
                    fila.Visible = false;
                }
            }
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            string texto = TBuscar.Text;     // lo que escribe el usuario
            DateTime desde = DTDesde.Value;  // fecha inicial
            DateTime hasta = DTHasta.Value;  // fecha final

            Buscar(texto, desde, hasta);
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            // Agrego datos de ejemplo
            GrillaClientes.Rows.Add("40101101", "Pérez", "Juan", "3794001122", "juan@hotmail.com", "Las Heras 1200, Corrientes", "2025-10-12");
            GrillaClientes.Rows.Add("40101102", "Gomez", "Maria", "3794001133", "maria@hotmail.com", "Ex Via 750, Corrientes", "2025-06-30");
            GrillaClientes.Rows.Add("40101103", "Lopez", "Carlos", "3794001144", "Carlos@gmail.com", "Yrigoyen 2750, Goya", "2025-01-23");
            GrillaClientes.Rows.Add("40101104", "Ibarra", "Rita", "3794001155", "rita@gmail.com", "Maipu 600, Itati", "2025-07-09");
            GrillaClientes.Rows.Add("40101105", "Benitez", "Mia", "3794001166", "mia@gmail.com", "Pujol 1300, Mburucuya", "2024-11-16");
            GrillaClientes.Rows.Add("40101106", "Sanchez", "Jose", "3794001177", "jose@gmail.com", "Maipu 2600, Corrientes", "2025-01-09");

        }
    }
}
