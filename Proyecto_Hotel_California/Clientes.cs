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

        private void BBuscar_Click(object sender, EventArgs e)
        {
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            // Agrego datos de ejemplo
            GrillaClientes.Rows.Add("40101101", "Pérez", "Juan", "3794001122", "juan@hotmail.com", "Las Heras 1200, Corrientes", "2025-10-12");
            GrillaClientes.Rows.Add("40101102", "Gomez", "Maria", "3794001133", "maria@hotmail.com", "Ex Via 750, Corrientes", "2025-06-30");
            GrillaClientes.Rows.Add("40101103", "Lopez", "Carlos", "3794001144", "Carlos@gmail.com", "Yrigoyen 2750, Goya", "2025-01-23");
            GrillaClientes.Rows.Add("40101104", "Ibarra", "Rita", "3794001155", "rita@gmail.com", "Maipu 600, Itati", "2025-07-09");

        }
    }
}
