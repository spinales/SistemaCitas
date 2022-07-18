using SistemaCitas.Models;
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
    public partial class consultoriosForm : Form
    {
        public consultoriosForm()
        {
            InitializeComponent();
            this.dataGridView1.Columns.Add("ID", "ID");
            this.dataGridView1.Columns.Add("Nombre", "Nombre");
            this.dataGridView1.Columns.Add("Encargado", "Encargado");
            actualizar();
            using (DatabaseEntities db = new DatabaseEntities())
            {
                var pisos = db.Pisos.ToList();
                foreach (var p in pisos)
                {
                    cbpiso.Items.Add(p.nombre);
                }
                cbpiso.SelectedIndex = 0;
            }
        }

        private void actualizar()
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                this.dataGridView1.Rows.Clear();
                var consultorios = db.Consultorios.ToList();
                foreach (var c in consultorios)
                {
                    this.dataGridView1.Rows.Add(c.id, c.nombre_consultorio, c.encargado);
                }
            }
        }

        private void btlimpiar_Click(object sender, EventArgs e)
        {
            tbencargado.Text = "";
            tbnombre.Text = "";
            cbpiso.SelectedIndex = 0;
        }

        private void consultoriosForm_Load(object sender, EventArgs e)
        {

        }

        private void btagregar_Click(object sender, EventArgs e)
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                var consultorio = new Consultorio();
                consultorio.nombre_consultorio = tbnombre.Text.Trim();
                consultorio.encargado = tbencargado.Text.Trim();
                consultorio.created_at = DateTime.Now;
                var piso = db.Pisos.Where(x => x.nombre == cbpiso.SelectedItem.ToString()).FirstOrDefault();
                consultorio.piso_id = piso.id;
                db.Consultorios.Add(consultorio);
                db.SaveChanges();
                tbnombre.Text = "";
                tbencargado.Text = "";
            }
            actualizar();
        }

        private void bteliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            using (DatabaseEntities db = new DatabaseEntities())
            {
                var consultorio = db.Consultorios.Find(id);
                db.Consultorios.Remove(consultorio);
                db.SaveChanges();
            }
            actualizar();
            btactualizar.Enabled = false;
            bteliminar.Enabled = false;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btactualizar.Enabled = true;
            bteliminar.Enabled = true;
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            tbnombre.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            tbencargado.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();

            using (DatabaseEntities db = new DatabaseEntities())
            {
                var consultorio = db.Consultorios.Find(id);
                var piso = db.Pisos.Where(x => x.id == consultorio.piso_id).FirstOrDefault();
                for (int i = 0; i < cbpiso.Items.Count; i++)
                {
                    if (cbpiso.Items[i].ToString() == piso.nombre)
                    {
                        cbpiso.SelectedIndex = i;
                    }
                }
            }
        }

        private void btactualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            using (DatabaseEntities db = new DatabaseEntities())
            {
                var consultorio = db.Consultorios.Find(id);
                consultorio.updated_at = DateTime.Now.Date;
                consultorio.nombre_consultorio = tbnombre.Text;
                consultorio.encargado = tbencargado.Text;
                consultorio.piso_id = db.Pisos.Where(x => x.nombre == cbpiso.SelectedItem.ToString()).FirstOrDefault().id;
                db.Entry(consultorio).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            actualizar();
            btactualizar.Enabled = false;
            bteliminar.Enabled = false;
            tbencargado.Text = "";
            tbnombre.Text = "";
            cbpiso.SelectedIndex = 0;
        }
    }
}
