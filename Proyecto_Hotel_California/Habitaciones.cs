using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Hotel_California
{
    public partial class Habitaciones : Form
    {
        public Habitaciones()
        {
            InitializeComponent();
        }

        private void BAgregarHab_Click(object sender, EventArgs e)
        {
            AgregarHab ventana = new AgregarHab();
            ventana.ShowDialog();
        }
    }
}
