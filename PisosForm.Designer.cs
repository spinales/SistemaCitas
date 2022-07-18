namespace SistemaCitas
{
    partial class PisosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btagregar = new System.Windows.Forms.Button();
            this.btlimpiar = new System.Windows.Forms.Button();
            this.btactualizar = new System.Windows.Forms.Button();
            this.bteliminar = new System.Windows.Forms.Button();
            this.lbuser = new System.Windows.Forms.Label();
            this.tbnombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 168);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 210);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // btagregar
            // 
            this.btagregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btagregar.Location = new System.Drawing.Point(498, 409);
            this.btagregar.Name = "btagregar";
            this.btagregar.Size = new System.Drawing.Size(96, 29);
            this.btagregar.TabIndex = 1;
            this.btagregar.Text = "Agregar";
            this.btagregar.UseVisualStyleBackColor = true;
            this.btagregar.Click += new System.EventHandler(this.btagregar_Click);
            // 
            // btlimpiar
            // 
            this.btlimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btlimpiar.Location = new System.Drawing.Point(396, 409);
            this.btlimpiar.Name = "btlimpiar";
            this.btlimpiar.Size = new System.Drawing.Size(96, 29);
            this.btlimpiar.TabIndex = 1;
            this.btlimpiar.Text = "Limpiar";
            this.btlimpiar.UseVisualStyleBackColor = true;
            this.btlimpiar.Click += new System.EventHandler(this.btlimpiar_Click);
            // 
            // btactualizar
            // 
            this.btactualizar.Enabled = false;
            this.btactualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btactualizar.Location = new System.Drawing.Point(294, 410);
            this.btactualizar.Name = "btactualizar";
            this.btactualizar.Size = new System.Drawing.Size(96, 29);
            this.btactualizar.TabIndex = 1;
            this.btactualizar.Text = "Actualizar";
            this.btactualizar.UseVisualStyleBackColor = true;
            this.btactualizar.Click += new System.EventHandler(this.btactualizar_Click);
            // 
            // bteliminar
            // 
            this.bteliminar.Enabled = false;
            this.bteliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bteliminar.Location = new System.Drawing.Point(192, 409);
            this.bteliminar.Name = "bteliminar";
            this.bteliminar.Size = new System.Drawing.Size(96, 29);
            this.bteliminar.TabIndex = 1;
            this.bteliminar.Text = "Eliminar";
            this.bteliminar.UseVisualStyleBackColor = true;
            this.bteliminar.Click += new System.EventHandler(this.bteliminar_Click);
            // 
            // lbuser
            // 
            this.lbuser.AutoSize = true;
            this.lbuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbuser.Location = new System.Drawing.Point(117, 49);
            this.lbuser.Name = "lbuser";
            this.lbuser.Size = new System.Drawing.Size(65, 20);
            this.lbuser.TabIndex = 5;
            this.lbuser.Text = "Nombre";
            // 
            // tbnombre
            // 
            this.tbnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbnombre.Location = new System.Drawing.Point(48, 72);
            this.tbnombre.Name = "tbnombre";
            this.tbnombre.Size = new System.Drawing.Size(205, 29);
            this.tbnombre.TabIndex = 4;
            // 
            // PisosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbuser);
            this.Controls.Add(this.tbnombre);
            this.Controls.Add(this.bteliminar);
            this.Controls.Add(this.btactualizar);
            this.Controls.Add(this.btlimpiar);
            this.Controls.Add(this.btagregar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PisosForm";
            this.Text = "PisosForm";
            this.Load += new System.EventHandler(this.PisosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btagregar;
        private System.Windows.Forms.Button btlimpiar;
        private System.Windows.Forms.Button btactualizar;
        private System.Windows.Forms.Button bteliminar;
        private System.Windows.Forms.Label lbuser;
        private System.Windows.Forms.TextBox tbnombre;
    }
}