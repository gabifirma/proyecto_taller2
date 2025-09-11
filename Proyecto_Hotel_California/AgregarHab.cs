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
    public partial class AgregarHab : Form
    {
        public AgregarHab()
        {
            InitializeComponent();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BFin_Click(object sender, EventArgs e)
        {
            Boolean valorPiso = int.TryParse(TPiso.Text, out int piso);
            Boolean valorNum = int.TryParse(TNumero.Text, out int num);

            if (!valorNum)
            {
                MessageBox.Show("El NÚMERO o esta vacío o no es un número");
                return;
            }

            if (!valorPiso)
            {
                MessageBox.Show("El PISO o esta vacío o no es un número");
                return;
            }

            if (valorPiso && valorNum)
            {
                MessageBox.Show("La habitación se agregó correctamente.");
                this.Close();
            }
        }
    }
}
