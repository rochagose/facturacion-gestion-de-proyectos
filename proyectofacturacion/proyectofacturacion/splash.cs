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
using proyectofacturacion.Logica;
using proyectofacturacion.Modelo;

namespace proyectofacturacion
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        public void VerificarExistenciaEmisores()
        {
            bool usuariosregistrados = UsuarioLogica.Instancia.UsuariosRegistrados();
            if (usuariosregistrados)
            {
                Login iniciarsesion = new Login();
                iniciarsesion.Show();
                this.Hide();
            }
            else
            {
                DialogResult result = MessageBox.Show("No hay emisores registrados. ¿Dar de alta un Emisor?",
                                            "Dar de Alta un Emisor",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    AltaEmisor altaEmisor = new AltaEmisor();
                    altaEmisor.Show();
                    this.Hide();
                }

            }
        }

        private void btingresar_Click(object sender, EventArgs e)
        {
            VerificarExistenciaEmisores();
            
        }

        private void btsalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
