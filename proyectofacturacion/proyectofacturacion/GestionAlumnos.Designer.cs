namespace proyectofacturacion
{
    partial class GestionAlumnos
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtcurpalumno = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.btdardebaja = new System.Windows.Forms.Button();
            this.btmodificar = new System.Windows.Forms.Button();
            this.btconsultar = new System.Windows.Forms.Button();
            this.datalumnos = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btgestiondepadresyalumnos = new System.Windows.Forms.Button();
            this.btpdf = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datalumnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(802, 40);
            this.panel2.TabIndex = 0;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Image = global::proyectofacturacion.Properties.Resources.minimizar_signo1;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(728, 9);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(34, 31);
            this.button9.TabIndex = 8;
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = global::proyectofacturacion.Properties.Resources.cerrar2;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(768, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(34, 31);
            this.button6.TabIndex = 5;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.txtcurpalumno);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.pictureBox9);
            this.panel1.Controls.Add(this.btdardebaja);
            this.panel1.Controls.Add(this.btmodificar);
            this.panel1.Controls.Add(this.btconsultar);
            this.panel1.Controls.Add(this.datalumnos);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 542);
            this.panel1.TabIndex = 2;
            // 
            // txtcurpalumno
            // 
            this.txtcurpalumno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtcurpalumno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcurpalumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcurpalumno.ForeColor = System.Drawing.Color.Gray;
            this.txtcurpalumno.Location = new System.Drawing.Point(145, 175);
            this.txtcurpalumno.MaxLength = 18;
            this.txtcurpalumno.Name = "txtcurpalumno";
            this.txtcurpalumno.Size = new System.Drawing.Size(211, 15);
            this.txtcurpalumno.TabIndex = 143;
            this.txtcurpalumno.Text = "CURP";
            this.txtcurpalumno.Enter += new System.EventHandler(this.txtcurpalumno_Enter);
            this.txtcurpalumno.Leave += new System.EventHandler(this.txtcurpalumno_Leave);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Navy;
            this.panel8.Location = new System.Drawing.Point(120, 205);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(236, 1);
            this.panel8.TabIndex = 142;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::proyectofacturacion.Properties.Resources.usuario;
            this.pictureBox9.Location = new System.Drawing.Point(120, 176);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(19, 23);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 141;
            this.pictureBox9.TabStop = false;
            // 
            // btdardebaja
            // 
            this.btdardebaja.BackColor = System.Drawing.Color.Navy;
            this.btdardebaja.FlatAppearance.BorderSize = 0;
            this.btdardebaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btdardebaja.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdardebaja.ForeColor = System.Drawing.Color.White;
            this.btdardebaja.Location = new System.Drawing.Point(669, 175);
            this.btdardebaja.Name = "btdardebaja";
            this.btdardebaja.Size = new System.Drawing.Size(121, 30);
            this.btdardebaja.TabIndex = 134;
            this.btdardebaja.Text = "Baja";
            this.btdardebaja.UseVisualStyleBackColor = false;
            this.btdardebaja.Click += new System.EventHandler(this.btdardebaja_Click);
            // 
            // btmodificar
            // 
            this.btmodificar.BackColor = System.Drawing.Color.Navy;
            this.btmodificar.FlatAppearance.BorderSize = 0;
            this.btmodificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmodificar.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmodificar.ForeColor = System.Drawing.Color.White;
            this.btmodificar.Location = new System.Drawing.Point(542, 175);
            this.btmodificar.Name = "btmodificar";
            this.btmodificar.Size = new System.Drawing.Size(121, 30);
            this.btmodificar.TabIndex = 133;
            this.btmodificar.Text = "Modificar";
            this.btmodificar.UseVisualStyleBackColor = false;
            this.btmodificar.Click += new System.EventHandler(this.btmodificar_Click);
            // 
            // btconsultar
            // 
            this.btconsultar.BackColor = System.Drawing.Color.Navy;
            this.btconsultar.FlatAppearance.BorderSize = 0;
            this.btconsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btconsultar.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btconsultar.ForeColor = System.Drawing.Color.White;
            this.btconsultar.Location = new System.Drawing.Point(415, 175);
            this.btconsultar.Name = "btconsultar";
            this.btconsultar.Size = new System.Drawing.Size(121, 30);
            this.btconsultar.TabIndex = 132;
            this.btconsultar.Text = "Consultar";
            this.btconsultar.UseVisualStyleBackColor = false;
            this.btconsultar.Click += new System.EventHandler(this.btconsultar_Click);
            // 
            // datalumnos
            // 
            this.datalumnos.AllowUserToAddRows = false;
            this.datalumnos.AllowUserToDeleteRows = false;
            this.datalumnos.AllowUserToResizeRows = false;
            this.datalumnos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datalumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datalumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalumnos.Location = new System.Drawing.Point(110, 222);
            this.datalumnos.Name = "datalumnos";
            this.datalumnos.ReadOnly = true;
            this.datalumnos.Size = new System.Drawing.Size(683, 311);
            this.datalumnos.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::proyectofacturacion.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(379, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.panel3.Controls.Add(this.btgestiondepadresyalumnos);
            this.panel3.Controls.Add(this.btpdf);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(104, 502);
            this.panel3.TabIndex = 1;
            // 
            // btgestiondepadresyalumnos
            // 
            this.btgestiondepadresyalumnos.FlatAppearance.BorderSize = 0;
            this.btgestiondepadresyalumnos.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btgestiondepadresyalumnos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btgestiondepadresyalumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btgestiondepadresyalumnos.ForeColor = System.Drawing.Color.White;
            this.btgestiondepadresyalumnos.Image = global::proyectofacturacion.Properties.Resources.alumno;
            this.btgestiondepadresyalumnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btgestiondepadresyalumnos.Location = new System.Drawing.Point(0, 0);
            this.btgestiondepadresyalumnos.Name = "btgestiondepadresyalumnos";
            this.btgestiondepadresyalumnos.Size = new System.Drawing.Size(104, 43);
            this.btgestiondepadresyalumnos.TabIndex = 7;
            this.btgestiondepadresyalumnos.Text = "Dar de Alta ";
            this.btgestiondepadresyalumnos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btgestiondepadresyalumnos.UseVisualStyleBackColor = true;
            this.btgestiondepadresyalumnos.Click += new System.EventHandler(this.btgestiondepadresyalumnos_Click);
            // 
            // btpdf
            // 
            this.btpdf.FlatAppearance.BorderSize = 0;
            this.btpdf.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btpdf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btpdf.ForeColor = System.Drawing.Color.White;
            this.btpdf.Image = global::proyectofacturacion.Properties.Resources.factura;
            this.btpdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btpdf.Location = new System.Drawing.Point(3, 49);
            this.btpdf.Name = "btpdf";
            this.btpdf.Size = new System.Drawing.Size(88, 43);
            this.btpdf.TabIndex = 6;
            this.btpdf.Text = "PDF";
            this.btpdf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btpdf.UseVisualStyleBackColor = true;
            this.btpdf.Click += new System.EventHandler(this.btpdf_Click);
            // 
            // GestionAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 542);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionAlumnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datalumnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btpdf;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView datalumnos;
        private System.Windows.Forms.Button btgestiondepadresyalumnos;
        private System.Windows.Forms.Button btmodificar;
        private System.Windows.Forms.Button btconsultar;
        private System.Windows.Forms.Button btdardebaja;
        private System.Windows.Forms.TextBox txtcurpalumno;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox pictureBox9;
    }
}