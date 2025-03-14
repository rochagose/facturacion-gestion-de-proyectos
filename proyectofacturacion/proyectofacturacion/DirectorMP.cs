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
    public partial class DirectorMP : Form
    {
        private string cuentauser;
        private string roluser;
        int lx, ly;
        int sw, sh;
        public DirectorMP(string cuenta, string rol)
        {
            InitializeComponent();
            cuentauser = cuenta;
            roluser = rol;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button7.Visible = true;
            button8.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cerrar el programa y la sesión?",
                                        "Cerrar Sesión",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Bitacora obj = new Bitacora()
                {
                    Cuenta = cuentauser,
                    Fecha = DateTime.Now.ToString(),
                    Evento = "Cierre de Sesión"
                };
                bool res = BitacoraLogica.Instancia.Registrar(obj);
                Application.Exit();
            }
            
        }


        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cerrar sesión?",
                                        "Cerrar Sesión",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Bitacora obj = new Bitacora()
                {
                    Cuenta = cuentauser,
                    Fecha = DateTime.Now.ToString(),
                    Evento = "Cierre de Sesión"
                };
                bool res = BitacoraLogica.Instancia.Registrar(obj);
                Login login = new Login();
                login.Show();
                this.Close();
            }

        }

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

        private void btbitacora_Click(object sender, EventArgs e)
        {
            Log log = new Log(cuentauser, roluser);
            log.Show();
            this.Hide();
        }

        private void btgestiondepadresyalumnos_Click(object sender, EventArgs e)
        {
            GestionAlumnos gestor = new GestionAlumnos(cuentauser, roluser);
            gestor.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void btusuarios_Click(object sender, EventArgs e)
        {
            GestionUsuarios gestionUsuarios = new GestionUsuarios(cuentauser, roluser);
            gestionUsuarios.Show();
            this.Hide();
        }

        private void btfacturacion_Click(object sender, EventArgs e)
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
