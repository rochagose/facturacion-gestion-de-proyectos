using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using proyectofacturacion.Logica;
using proyectofacturacion.Modelo;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Runtime.InteropServices;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace proyectofacturacion
{
    public partial class AltaEmisor : Form
    {
        private const string placeholderText = "Contraseña";
        private const string placeholderText2 = "Confirmar Contraseña";

        public AltaEmisor()
        {
            InitializeComponent();
            comboboxrolusuario.SelectedIndex = 0;
            comboboxregimenfiscalusuario.SelectedIndex = 0;
            comboboxestadousuario.SelectedIndex = 0;
            cargarMunicipios(@"Aguascalientes.txt");
            comboboxmunicipiousuario.SelectedIndex = 0;
            bool director = UsuarioLogica.Instancia.RolExiste("Director");
            if (director)
            {
                comboboxrolusuario.Items.Remove("Director");
            }
        }

        private void txtnombreusuario_Enter(object sender, EventArgs e)
        {
            if (txtnombreusuario.Text == "Nombre(s)")
            {
                txtnombreusuario.Text = "";
                txtnombreusuario.ForeColor = Color.Black;
            }
        }

        private void txtapusuario_Enter(object sender, EventArgs e)
        {
            if (txtapusuario.Text == "Apellido Paterno")
            {
                txtapusuario.Text = "";
                txtapusuario.ForeColor = Color.Black;
            }
        }

        private void txtamusuario_Enter(object sender, EventArgs e)
        {
            if (txtamusuario.Text == "Apellido Materno")
            {
                txtamusuario.Text = "";
                txtamusuario.ForeColor = Color.Black;
            }
        }
        private void txtrfcsuario_Enter(object sender, EventArgs e)
        {
            if (txtrfcusuario.Text == "RFC")
            {
                txtrfcusuario.Text = "";
                txtrfcusuario.ForeColor = Color.Black;
            }

        }
        private void txtcuentausuario_Enter(object sender, EventArgs e)
        {
            if (txtcuentausuario.Text == "Nombre de Usuario")
            {
                txtcuentausuario.Text = "";
                txtcuentausuario.ForeColor = Color.Black;
            }
        }

        private void txtconfirmarpasswordusuario_Enter(object sender, EventArgs e)
        {
            if (txtconfirmarpasswordusuario.Text == "Confirmar Contraseña")
            {
                txtconfirmarpasswordusuario.Text = "";
                txtconfirmarpasswordusuario.ForeColor = Color.Black;
            }
        }

        private void txtcorreousuario_Enter(object sender, EventArgs e)
        {
            if (txtcorreousuario.Text == "Correo Electronico")
            {
                txtcorreousuario.Text = "";
                txtcorreousuario.ForeColor = Color.Black;
            }
        }

        private void txtcodigopostalusuario_Enter(object sender, EventArgs e)
        {
            if (txtcodigopostalusuario.Text == "Código Postal")
            {
                txtcodigopostalusuario.Text = "";
                txtcodigopostalusuario.ForeColor = Color.Black;
            }
        }
        private void txtcoloniausuario_Enter(object sender, EventArgs e)
        {
            if (txtcoloniausuario.Text == "Colonia")
            {
                txtcoloniausuario.Text = "";
                txtcoloniausuario.ForeColor = Color.Black;
            }
        }
        private void txtcalleusuario_Enter(object sender, EventArgs e)
        {
            if (txtcalleusuario.Text == "Calle")
            {
                txtcalleusuario.Text = "";
                txtcalleusuario.ForeColor = Color.Black;
            }
        }


        private void checkboxpasswordusuario_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxpasswordusuario.Checked)
            {
                txtconfirmarpasswordusuario.PasswordChar = '\0';
            }
            else
            {
                txtconfirmarpasswordusuario.PasswordChar = '*';
            }
        }
        private void txtnombreusuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnombreusuario.Text))
            {
                txtnombreusuario.Text = "Nombre(s)";
                txtnombreusuario.ForeColor = Color.Gray;
            }
        }

        private void txtapusuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtapusuario.Text))
            {
                txtapusuario.Text = "Apellido Paterno";
                txtapusuario.ForeColor = Color.Gray;
            }
        }

        private void txtamusuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtamusuario.Text))
            {
                txtamusuario.Text = "Apellido Materno";
                txtamusuario.ForeColor = Color.Gray;
            }
        }

        private void txtrfcusuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtrfcusuario.Text))
            {
                txtrfcusuario.Text = "RFC";
                txtrfcusuario.ForeColor = Color.Gray;
            }
        }

        private void txtcuentausuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcuentausuario.Text))
            {
                txtcuentausuario.Text = "Nombre de Usuario";
                txtcuentausuario.ForeColor = Color.Gray;
            }
        }


        private void txtconfirmarpasswordusuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtconfirmarpasswordusuario.Text))
            {
                txtconfirmarpasswordusuario.Text = "Confirmar Contraseña";
                txtconfirmarpasswordusuario.ForeColor = Color.Gray;
            }
        }

        private void txtcorreousuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcorreousuario.Text))
            {
                txtcorreousuario.Text = "Correo Electronico";
                txtcorreousuario.ForeColor = Color.Gray;
            }
        }

        private void txtcodigopostalusuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcodigopostalusuario.Text))
            {
                txtcodigopostalusuario.Text = "Código Postal";
                txtcodigopostalusuario.ForeColor = Color.Gray;
            }
        }

        private void txtcoloniausuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcoloniausuario.Text))
            {
                txtcoloniausuario.Text = "Colonia";
                txtcoloniausuario.ForeColor = Color.Gray;
            }
        }

        private void txtcalleusuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcalleusuario.Text))
            {
                txtcalleusuario.Text = "Calle";
                txtcalleusuario.ForeColor = Color.Gray;
            }
        }


        public bool validarCadenasSoloNumeros()
        {
            MetodosYFunciones MF = new MetodosYFunciones();
            if (MF.soloNumeros(txtnoextusuario.Text) &&
                MF.soloNumeros(txtnointusuario.Text))
            {
                return true;
            }
            return false;
        }

        public bool validarCadenasSoloLetras()
        {
            MetodosYFunciones MF = new MetodosYFunciones();
            if (MF.soloLetras(txtnombreusuario.Text) &&
                MF.soloLetras(txtapusuario.Text) &&
                MF.soloLetras(txtamusuario.Text))
            {
                return true;
            }
            return false;

        }

        public bool ValidarCamposLlenos()
        {
            // Verificar que ningún campo esté vacío o contenga el texto del placeholder.
            if (txtnombreusuario.Text == "Nombre(s)" || string.IsNullOrWhiteSpace(txtnombreusuario.Text)) return false;
            if (txtapusuario.Text == "Apellido Paterno" || string.IsNullOrWhiteSpace(txtapusuario.Text)) return false;
            if (txtamusuario.Text == "Apellido Materno" || string.IsNullOrWhiteSpace(txtamusuario.Text)) return false;
            if (txtrfcusuario.Text == "RFC" || string.IsNullOrWhiteSpace(txtrfcusuario.Text)) return false;
            if (txtcuentausuario.Text == "Nombre de Usuario" || string.IsNullOrWhiteSpace(txtcuentausuario.Text)) return false;
            if (txtconfirmarpasswordusuario.Text == placeholderText2 || string.IsNullOrWhiteSpace(txtconfirmarpasswordusuario.Text)) return false;
            if (txtcorreousuario.Text == "Correo Electronico" || string.IsNullOrWhiteSpace(txtcorreousuario.Text)) return false;
            if (txtcodigopostalusuario.Text == "Código Postal" || string.IsNullOrWhiteSpace(txtcodigopostalusuario.Text)) return false;
            if (txtcoloniausuario.Text == "Colonia" || string.IsNullOrWhiteSpace(txtcoloniausuario.Text)) return false;
            if (txtcalleusuario.Text == "Calle" || string.IsNullOrWhiteSpace(txtcalleusuario.Text)) return false;
            if (txtnoextusuario.Text == "No. Ext." || string.IsNullOrWhiteSpace(txtnoextusuario.Text)) return false;

            return true;
        }

        public static string HashSimple(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
        }

        private void btdaralta_Click(object sender, EventArgs e)
        {
            MetodosYFunciones MF = new MetodosYFunciones();
            DateTime fecha = selectorfecha.Value;
            string fechaF = fecha.ToString("dd/MM/yyyy");
            string rfc = MF.GenerarRFC(txtnombreusuario.Text, txtapusuario.Text, txtamusuario.Text,
                fecha);
            string rfcinput = txtrfcusuario.Text.ToString();
            rfcinput = rfcinput.Substring(0, rfcinput.Length - 3);
            bool existe = UsuarioLogica.Instancia.RFCExiste(rfcinput);


            if (!ValidarCamposLlenos())
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (!validarCadenasSoloLetras())
            {
                MessageBox.Show("Está utilizando numeros o caracteres especiales en campos que solo admiten letras.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (!validarCadenasSoloNumeros())
            {
                MessageBox.Show("Está utilizando letras en campos que solo utilizan numeros", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!MF.ValidarRFC(txtrfcusuario.Text)) 
            {   
                MessageBox.Show("El RFC no es válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (rfc != rfcinput)
            {
                MessageBox.Show("El RFC no concuerda con los datos brindados", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (existe)
            {
                MessageBox.Show("El RFC ya fue dado de alta con anterioridad", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!MF.ValidarCorreoElectronico(txtcorreousuario.Text)) 
            {
                MessageBox.Show("El correo electronico no es válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (!MF.validoCP(txtcodigopostalusuario.Text)) 
            {
                MessageBox.Show("El código postal es incorrecto.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (!MF.rangoCP(int.Parse(txtcodigopostalusuario.Text)))
            {
                MessageBox.Show("El código postal está fuera del rango o no pertenece a México", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else
            {
                DialogResult result = MessageBox.Show("Confirmar alta del emisor",
                                            "Confirmar Cancelar",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string safepassword = HashSimple(txtconfirmarpasswordusuario.Text);
                    Usuario objeto = new Usuario()
                    {
                        RFC = txtrfcusuario.Text,
                        Cuenta = txtcuentausuario.Text,
                        Contrasena = safepassword,
                        Rol = comboboxrolusuario.Text,
                        Nombre = txtnombreusuario.Text,
                        ApellidoPaterno = txtapusuario.Text,
                        ApellidoMaterno = txtamusuario.Text,
                        Correo = txtcorreousuario.Text,
                        CodigoPostal = txtcodigopostalusuario.Text,
                        Colonia = txtcoloniausuario.Text,
                        Calle = txtcalleusuario.Text,
                        NumeroExterior = txtnoextusuario.Text,
                        NumeroInterior = txtnointusuario.Text,
                        Estado = comboboxestadousuario.SelectedItem.ToString(),
                        Municipio = comboboxmunicipiousuario.SelectedItem.ToString(),
                        RegimenFiscal = comboboxregimenfiscalusuario.SelectedItem.ToString()
                    };
                    bool respuestaRFC = UsuarioLogica.Instancia.RFCExiste(txtrfcusuario.Text);
                    bool respuesta = UsuarioLogica.Instancia.Guardar(objeto);

                    if(respuesta && respuestaRFC == false)
                    {
                        txtrfcusuario.Text = "RFC";
                        txtrfcusuario.ForeColor = Color.Gray;
                        txtcuentausuario.Text = "Nombre de Usuario";
                        txtcuentausuario.ForeColor = Color.Gray;
                        txtconfirmarpasswordusuario.Text = "";
                        txtnombreusuario.Text = "Nombre(s)";
                        txtnombreusuario.ForeColor = Color.Gray;
                        txtapusuario.Text = "Apellido Paterno";
                        txtapusuario.ForeColor = Color.Gray;
                        txtamusuario.Text = "Apellido Materno";
                        txtamusuario.ForeColor = Color.Gray;
                        txtcorreousuario.Text = "Correo Electronico";
                        txtcorreousuario.ForeColor = Color.Gray;
                        txtcodigopostalusuario.Text = "Código Postal";
                        txtcodigopostalusuario.ForeColor= Color.Gray;   
                        txtcoloniausuario.Text = "Colonia";
                        txtcoloniausuario.ForeColor = Color.Gray;
                        txtcalleusuario.Text = "Calle";
                        txtcalleusuario.ForeColor = Color.Gray;
                        txtnoextusuario.Text = "No. Ext.";
                        txtnoextusuario.ForeColor = Color.Gray;
                        txtnointusuario.Text = "No. Int.";
                        txtnointusuario.ForeColor = Color.Gray;
                        MessageBox.Show("Los datos se han guardado de manera exitosa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }else if (respuestaRFC)
                    {
                        MessageBox.Show("RFC ya registrado, intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar los datos: Intente de nuevo o consulte el manual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void txtnointusuario_Enter(object sender, EventArgs e)
        {
            if (txtnointusuario.Text == "No. Int.")
            {
                txtnointusuario.Text = "";
                txtnointusuario.ForeColor = Color.Black;
            }
        }
        private void txtnointusuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnointusuario.Text))
            {
                txtnointusuario.Text = "No. Int.";
                txtnointusuario.ForeColor = Color.Gray;
            }
        }

        private void txtnoextusuario_Enter(object sender, EventArgs e)
        {
            if (txtnoextusuario.Text == "No. Ext.")
            {
                txtnoextusuario.Text = "";
                txtnoextusuario.ForeColor = Color.Black;
            }
        }

        private void txtnoextusuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnoextusuario.Text))
            {
                txtnoextusuario.Text = "No. Ext";
                txtnoextusuario.ForeColor = Color.Gray;
            }
        }

        private void fecha_enter(object sender, EventArgs e)
        {
            selectorfecha.Visible = true;
        }

        private void fecha_leave(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel18_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir y cancelar la operación?",
                            "Salir",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                this.Close();
                splash splashv = new splash();
                splashv.Show();
            }
        }

        private void cargarMunicipios(string ruta)
        {
            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaArchivo = Path.Combine(rutaBase, "Municipios", ruta);

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                comboboxmunicipiousuario.Items.Clear();  // Limpiar items anteriores
                comboboxmunicipiousuario.Items.AddRange(lineas);
            }
            else
            {
                MessageBox.Show("El archivo no fue encontrado en la carpeta 'Municipios'.");
            }
        }

        private void comboboxestadousuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboboxestadousuario.SelectedItem.ToString())
            {
                case "AGUASCALIENTES":
                    cargarMunicipios(@"Aguascalientes.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "BAJA CALIFORNIA":
                    cargarMunicipios(@"BajaCalifornia.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "BAJA CALIFORNIA SUR":
                    cargarMunicipios(@"BajaCaliforniaSur.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "CAMPECHE":
                    cargarMunicipios("Campeche.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "CHIAPAS":
                    cargarMunicipios("Chiapas.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "CHIHUAHUA":
                    cargarMunicipios("Chihuahua.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "CDMX":
                    cargarMunicipios("CDMX.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "COAHUILA":
                    cargarMunicipios("Coahuila.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "COLIMA":
                    cargarMunicipios("Colima.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "DURANGO":
                    cargarMunicipios("Durango.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "ESTADO DE MEXICO":
                    cargarMunicipios("EdoMex.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "GUANAJUATO":
                    cargarMunicipios("Guanajuato.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "GUERRERO":
                    cargarMunicipios("Guerrero.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "HIDALGO":
                    cargarMunicipios("Hidalgo.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "JALISCO":
                    cargarMunicipios("Jalisco.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "MICHOACAN":
                    cargarMunicipios("Michoacan.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "MORELOS":
                    cargarMunicipios("Morelos.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "NAYARIT":
                    cargarMunicipios("Nayarit.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "NUEVO LEON":
                    cargarMunicipios("NuevoLeon.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "OAXACA":
                    cargarMunicipios("Oaxaca.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "PUEBLA":
                    cargarMunicipios("Puebla.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "QUERETARO":
                    cargarMunicipios("Queretaro.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "QUINTANA ROO":
                    cargarMunicipios("QuintanaRoo.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "SAN LUIS POTOSI":
                    cargarMunicipios("SanLuisPotosi.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "SINALOA":
                    cargarMunicipios("Sinaloa.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "SONORA":
                    cargarMunicipios("Sonora.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "TABASCO":
                    cargarMunicipios("Tabasco.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "TAMAULIPAS":
                    cargarMunicipios("Tamaulipas.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "TLAXCALA":
                    cargarMunicipios("Tlaxcala.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "VERACRUZ":
                    cargarMunicipios("Veracruz.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "YUCATAN":
                    cargarMunicipios("Yucatan.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                case "ZACATECAS":
                    cargarMunicipios("Zacatecas.txt");
                    comboboxmunicipiousuario.SelectedIndex = 0;
                    break;
                default:
                    MessageBox.Show("Estado no encontrado.");
                    break;
            }
        }
    }
}
