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
    public partial class PisosForm : Form
    {
        public PisosForm()
        {
            InitializeComponent();
            this.dataGridView1.Columns.Add("ID", "ID");
            this.dataGridView1.Columns.Add("Nombre", "Nombre");
            actualizar();
        }

        private void actualizar()
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                this.dataGridView1.Rows.Clear();
                var pisos = db.Pisos.ToList();
                foreach (var p in pisos)
                {
                    this.dataGridView1.Rows.Add(p.id, p.nombre);
                }
            }
        }

        private void PisosForm_Load(object sender, EventArgs e)
        {

        }

        private void btlimpiar_Click(object sender, EventArgs e)
        {
            tbnombre.Text = "";
        }

        private void btagregar_Click(object sender, EventArgs e)
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                var piso = new Piso();
                piso.nombre = tbnombre.Text.Trim();
                piso.created_at = DateTime.Now;
                db.Pisos.Add(piso);
                db.SaveChanges();
                tbnombre.Text = "";
            }
            actualizar();
        }

        private void bteliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

            using (DatabaseEntities db = new DatabaseEntities())
            {
                Piso piso = db.Pisos.Find(id);
                db.Pisos.Remove(piso);
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
            int? id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            tbnombre.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
        }

        private void btactualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            using (DatabaseEntities db = new DatabaseEntities())
            {
                Piso piso = db.Pisos.Find(id);
                piso.updated_at = DateTime.Now.Date;
                piso.nombre = tbnombre.Text;
                db.Entry(piso).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            actualizar();
            btactualizar.Enabled = false;
            bteliminar.Enabled = false;
        }
    }
}
