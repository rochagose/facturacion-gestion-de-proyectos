using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectofacturacion.Logica;
using proyectofacturacion.Modelo;


namespace proyectofacturacion
{
    public partial class Login : Form
    {
        private const string placeholderText = "Contraseña";
        public Login()
        {
            InitializeComponent();
            txtpassword.Text = placeholderText;
            comboboxusuario.SelectedIndex = 0;

        }

        private void txtusuario_Enter(object sender, EventArgs e)
        {
            if(txtusuario.Text == "Usuario")
            {
                txtusuario.Text = "";
                txtusuario.ForeColor = Color.Black;
            }
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == placeholderText) {
                txtpassword.Text = "";
                txtpassword.ForeColor = Color.Black;
            }
        }

        private void checkboxpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxpassword.Checked) { 
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void btlogin_Click(object sender, EventArgs e)
        {

            string cuenta = txtusuario.Text;
            string rol = comboboxusuario.Text.ToString();
            Usuario objeto = new Usuario()
            {
                Cuenta = cuenta,
                Rol = rol,
                Contrasena = HashSimple(txtpassword.Text)
            };

            Bitacora obj = new Bitacora()
            {
                Cuenta = cuenta,
                Fecha = DateTime.Now.ToString(),
                Evento = "Inicio de Sesión"
            };

            bool respuesta = UsuarioLogica.Instancia.LogearUsuario(objeto, rol);
            if (respuesta) {
                if(comboboxusuario.Text.ToString() == "Contador")
                {
                    bool res = BitacoraLogica.Instancia.Registrar(obj);
                    ContadorMP contadorMP = new ContadorMP(cuenta, rol);
                    contadorMP.Show();
                    this.Close();
                }
                else
                {
                    bool res = BitacoraLogica.Instancia.Registrar(obj);
                    DirectorMP directorMP = new DirectorMP(cuenta, rol);   
                    directorMP.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Usuario, contraseña o rol incorrectos. Por favor, intente de nuevo.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btregistraremisor_Click(object sender, EventArgs e)
        {
            bool director = UsuarioLogica.Instancia.RolExiste("Director");
            bool contador = UsuarioLogica.Instancia.RolExiste("Contador");

            if (director && contador)
            {
                MessageBox.Show("Ya se ha dado de alta al Director y al Contador", "Emisores ya dados de alta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                AltaEmisor altaEmisor = new AltaEmisor();
                altaEmisor.Show();
                this.Close();
            }
                



        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            splash welcome = new splash();
            welcome.Show();
            this.Close();
        }

        public static string HashSimple(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void txtusuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtusuario.Text))
            {
                txtusuario.Text = "Usuario";
                txtusuario.ForeColor = Color.Gray;
            }
        }
    }
}
