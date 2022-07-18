using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaCitas.Models;

namespace SistemaCitas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            tbpassword.Text = "admin";
            tbuser.Text = "admin";
        }

        private void btenter_Click(object sender, EventArgs e)
        {
            if (tbpassword.Text == "" && tbuser.Text == "")
            {
                MessageBox.Show("Por favor completar los campos");
            } else
            {
                using (DatabaseEntities db = new DatabaseEntities())
                {
                    var user = db.Usuarios.Where(x => x.username == tbuser.Text).FirstOrDefault();
                    if (user.password == tbpassword.Text)
                    {
                        this.Hide();
                        Menu menu = new Menu();
                        menu.Closed += (s, args) => this.Close();
                        menu.Show();
                    } else if (user.password != tbpassword.Text)
                    {
                        MessageBox.Show("El usuario o la contraseña estan incorrectos");
                    } else
                    {
                        MessageBox.Show("este usuario no existe.");
                    }
                }
            }            
        }

        private void tbuser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
