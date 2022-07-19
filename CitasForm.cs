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
    public partial class CitasForm : Form
    {
        public CitasForm()
        {
            InitializeComponent();
            this.dataGridView1.Columns.Add("ID", "ID");
            this.dataGridView1.Columns.Add("Paciente", "Paciente");
            this.dataGridView1.Columns.Add("Fecha", "Fecha");
            this.dataGridView1.Columns.Add("Consultorio", "Consultorio");
            actualizar();
            using (DatabaseEntities db = new DatabaseEntities())
            {
                var consultorios = db.Consultorios.ToList();
                foreach (var c in consultorios)
                {
                    cbconsultorio.Items.Add(c.nombre_consultorio);
                }
                if(cbconsultorio.Items.Count > 0)
                {
                    cbconsultorio.SelectedIndex = 0;
                }
                
            }
        }

        private void actualizar()
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                this.dataGridView1.Rows.Clear();
                var citas = db.Citas.ToList();
                foreach (var c in citas)
                {
                    var consultorio = db.Consultorios.Find(c.consultorio_id);
                    this.dataGridView1.Rows.Add(c.id, c.paciente, c.fecha,consultorio.nombre_consultorio);
                }
            }
        }

        private void btlimpiar_Click(object sender, EventArgs e)
        {
            tbnombre.Text = "";
            cbconsultorio.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btagregar_Click(object sender, EventArgs e)
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                var cita = new Cita();
                cita.paciente = tbnombre.Text;
                cita.fecha = dateTimePicker1.Value;
                cita.created_at = DateTime.Now;
                var consultorio = db.Consultorios.Where(x => x.nombre_consultorio == cbconsultorio.SelectedItem.ToString()).FirstOrDefault();
                cita.consultorio_id = consultorio.id;
                db.Citas.Add(cita);
                db.SaveChanges();
                tbnombre.Text = "";
                cbconsultorio.SelectedIndex = 0;
                dateTimePicker1.Value = DateTime.Now;
            }
            actualizar();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btactualizar.Enabled = true;
            bteliminar.Enabled = true;
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            tbnombre.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString());

            using (DatabaseEntities db = new DatabaseEntities())
            {
                var cita = db.Citas.Find(id);
                var consultorio = db.Consultorios.Where(x => x.id == cita.consultorio_id).FirstOrDefault();
                for (int i = 0; i < cbconsultorio.Items.Count; i++)
                {
                    if (cbconsultorio.Items[i].ToString() == consultorio.nombre_consultorio)
                    {
                        cbconsultorio.SelectedIndex = i;
                    }
                }
            }
        }

        private void bteliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            using (DatabaseEntities db = new DatabaseEntities())
            {
                var cita = db.Citas.Find(id);
                db.Citas.Remove(cita);
                db.SaveChanges();
            }
            actualizar();
            btactualizar.Enabled = false;
            bteliminar.Enabled = false;
            tbnombre.Text = "";
            cbconsultorio.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btactualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            using (DatabaseEntities db = new DatabaseEntities())
            {
                var cita = db.Citas.Find(id);
                cita.updated_at = DateTime.Now.Date;
                cita.paciente = tbnombre.Text;
                cita.fecha = dateTimePicker1.Value;
                cita.consultorio_id = db.Consultorios.Where(x => x.nombre_consultorio == cbconsultorio.SelectedItem.ToString()).FirstOrDefault().id;
                db.Entry(cita).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            actualizar();
            btactualizar.Enabled = false;
            bteliminar.Enabled = false;
            tbnombre.Text = "";
            cbconsultorio.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
