using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using proyectofacturacion.Logica;
using proyectofacturacion.Modelo;

namespace proyectofacturacion
{

    public partial class GestionUsuarios : Form
    {
        private string roluser;
        private string cuentauser;
        public GestionUsuarios(string cuenta, string rol)
        {
            InitializeComponent();
            roluser = rol;
            cuentauser = cuenta;
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            List<Usuario> usuarios = UsuarioLogica.Instancia.ObtenerUsuarios();
            datausuarios.DataSource = usuarios;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (roluser == "Director")
            {
                DirectorMP directorMP = new DirectorMP(cuentauser, roluser);
                directorMP.Show();
                this.Close();
            }
            if (roluser == "Contador")
            {
                ContadorMP contadorMP = new ContadorMP(cuentauser, roluser);
                contadorMP.Show();
                this.Close();
            }
        }

        private void btsalir_Click(object sender, EventArgs e)
        {
            if (roluser == "Director")
            {
                DirectorMP directorMP = new DirectorMP(cuentauser, roluser);
                directorMP.Show();
                this.Close();
            }
            if (roluser == "Contador")
            {
                ContadorMP contadorMP = new ContadorMP(cuentauser, roluser);
                contadorMP.Show();
                this.Close();
            }
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

    }
}
