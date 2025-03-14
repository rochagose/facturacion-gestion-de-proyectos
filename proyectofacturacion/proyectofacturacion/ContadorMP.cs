using proyectofacturacion.Logica;
using proyectofacturacion.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectofacturacion
{
    public partial class ContadorMP : Form
    {
        private string cuentauser;
        private string roluser;
        public ContadorMP(string cuenta, string rol)
        {
            InitializeComponent();
            cuentauser = cuenta;
            roluser = rol;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }



        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int lx, ly;
        int sw, sh;
        private void button7_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
           button7.Visible = false;
            button8.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button7.Visible = true;
            button8.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btgestiondepadresyalumnos_Click(object sender, EventArgs e)
        {
            GestionAlumnos gestor = new GestionAlumnos(cuentauser, roluser);
            gestor.Show();
            this.Hide();
        }

        private void btcerrarsesion_Click(object sender, EventArgs e)
        {
            Bitacora obj = new Bitacora()
            {
                Cuenta = cuentauser,
                Fecha = DateTime.Now.ToString(),
                Evento = "Cerrar Sesión"
            };

            bool res = BitacoraLogica.Instancia.Registrar(obj);

            Login fm1 = new Login();
            fm1.Show();
            this.Hide();
        }

        private void btgestiondepadres_Click(object sender, EventArgs e)
        {
            GestionPadres gestorp = new GestionPadres(cuentauser, roluser);
            gestorp.Show();
            this.Hide();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btfacturar_Click(object sender, EventArgs e)
        {
            Facturacion fact = new Facturacion(cuentauser, roluser);
            this.Hide();
            fact.Show();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

    }
}
