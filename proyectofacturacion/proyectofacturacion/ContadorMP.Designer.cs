namespace proyectofacturacion
{
    partial class ContadorMP
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btgestiondepadres = new System.Windows.Forms.Button();
            this.btcerrarsesion = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btfacturar = new System.Windows.Forms.Button();
            this.btgestiondepadresyalumnos = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 540);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::proyectofacturacion.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(267, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(521, 483);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.panel3.Controls.Add(this.btgestiondepadres);
            this.panel3.Controls.Add(this.btcerrarsesion);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.btfacturar);
            this.panel3.Controls.Add(this.btgestiondepadresyalumnos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(261, 500);
            this.panel3.TabIndex = 1;
            // 
            // btgestiondepadres
            // 
            this.btgestiondepadres.FlatAppearance.BorderSize = 0;
            this.btgestiondepadres.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btgestiondepadres.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btgestiondepadres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btgestiondepadres.ForeColor = System.Drawing.Color.White;
            this.btgestiondepadres.Image = global::proyectofacturacion.Properties.Resources.user_32;
            this.btgestiondepadres.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btgestiondepadres.Location = new System.Drawing.Point(3, 117);
            this.btgestiondepadres.Name = "btgestiondepadres";
            this.btgestiondepadres.Size = new System.Drawing.Size(250, 43);
            this.btgestiondepadres.TabIndex = 8;
            this.btgestiondepadres.Text = "Gestión de Padres";
            this.btgestiondepadres.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btgestiondepadres.UseVisualStyleBackColor = true;
            this.btgestiondepadres.Click += new System.EventHandler(this.btgestiondepadres_Click);
            // 
            // btcerrarsesion
            // 
            this.btcerrarsesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btcerrarsesion.FlatAppearance.BorderSize = 0;
            this.btcerrarsesion.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btcerrarsesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btcerrarsesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btcerrarsesion.ForeColor = System.Drawing.Color.White;
            this.btcerrarsesion.Image = global::proyectofacturacion.Properties.Resources.cerrar_sesion1;
            this.btcerrarsesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btcerrarsesion.Location = new System.Drawing.Point(0, 457);
            this.btcerrarsesion.Name = "btcerrarsesion";
            this.btcerrarsesion.Size = new System.Drawing.Size(261, 43);
            this.btcerrarsesion.TabIndex = 4;
            this.btcerrarsesion.Text = "Cerrar sesion";
            this.btcerrarsesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btcerrarsesion.UseVisualStyleBackColor = true;
            this.btcerrarsesion.Click += new System.EventHandler(this.btcerrarsesion_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::proyectofacturacion.Properties.Resources.tendencia;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(3, 215);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(250, 43);
            this.button3.TabIndex = 2;
            this.button3.Text = "Estadisticas";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btfacturar
            // 
            this.btfacturar.FlatAppearance.BorderSize = 0;
            this.btfacturar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btfacturar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btfacturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btfacturar.ForeColor = System.Drawing.Color.White;
            this.btfacturar.Image = global::proyectofacturacion.Properties.Resources.factura;
            this.btfacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btfacturar.Location = new System.Drawing.Point(3, 166);
            this.btfacturar.Name = "btfacturar";
            this.btfacturar.Size = new System.Drawing.Size(250, 43);
            this.btfacturar.TabIndex = 1;
            this.btfacturar.Text = "Facturacion";
            this.btfacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btfacturar.UseVisualStyleBackColor = true;
            this.btfacturar.Click += new System.EventHandler(this.btfacturar_Click);
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
            this.btgestiondepadresyalumnos.Location = new System.Drawing.Point(3, 68);
            this.btgestiondepadresyalumnos.Name = "btgestiondepadresyalumnos";
            this.btgestiondepadresyalumnos.Size = new System.Drawing.Size(250, 43);
            this.btgestiondepadresyalumnos.TabIndex = 0;
            this.btgestiondepadresyalumnos.Text = "Gestión de Alumnos";
            this.btgestiondepadresyalumnos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btgestiondepadresyalumnos.UseVisualStyleBackColor = true;
            this.btgestiondepadresyalumnos.Click += new System.EventHandler(this.btgestiondepadresyalumnos_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 40);
            this.panel2.TabIndex = 0;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
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
            this.button9.Location = new System.Drawing.Point(686, 12);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(34, 31);
            this.button9.TabIndex = 8;
            this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Image = global::proyectofacturacion.Properties.Resources.cuadricula1;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(726, 6);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(34, 31);
            this.button8.TabIndex = 7;
            this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Image = global::proyectofacturacion.Properties.Resources.maximizar1;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(726, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(34, 31);
            this.button7.TabIndex = 6;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
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
            this.button6.Location = new System.Drawing.Point(766, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(34, 31);
            this.button6.TabIndex = 5;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // ContadorMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 540);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContadorMP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btfacturar;
        private System.Windows.Forms.Button btgestiondepadresyalumnos;
        private System.Windows.Forms.Button btcerrarsesion;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btgestiondepadres;
        private System.Windows.Forms.Button button8;
    }
}