using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCitas
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btcitas_Click(object sender, EventArgs e)
        {
            CitasForm citasForm = new CitasForm(); 
            // citasForm.Dock = DockStyle.Fill;
            citasForm.TopMost = true;
            citasForm.TopLevel = false;
            this.container.Controls.Add(citasForm);
            citasForm.Show();
        }

        private void btconsultorios_Click(object sender, EventArgs e)
        {
            consultoriosForm consultoriosForm = new consultoriosForm();
            consultoriosForm.TopMost = true;
            consultoriosForm.TopLevel = false;
            this.container.Controls.Add(consultoriosForm);
            consultoriosForm.Show();
        }

        private void btpisos_Click(object sender, EventArgs e)
        {
            PisosForm pisosForm = new PisosForm();
            pisosForm.TopMost = true;
            pisosForm.TopLevel = false;
            this.container.Controls.Add(pisosForm);
            pisosForm.Show();
        }
    }
}
