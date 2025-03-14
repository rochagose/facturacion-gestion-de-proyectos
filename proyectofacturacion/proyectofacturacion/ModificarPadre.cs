﻿using proyectofacturacion.Logica;
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
using System.IO;


namespace proyectofacturacion
{
    public partial class ModificarPadre : Form
    {
        private string cuentauser;
        private string roluser;
        public ModificarPadre(string cuenta, string rol, string rfc)
        {
            cuentauser = cuenta;
            roluser = rol;
            InitializeComponent();
            CargarDatos(rfc);
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas salir y cancelar la operación?",
            "Salir",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (roluser == "Director")
                {
                    this.Close();
                    DirectorMP directorMP = new DirectorMP(cuentauser, roluser);
                    directorMP.Show();
                }
                else
                {
                    this.Close();
                    ContadorMP contadorMP = new ContadorMP(cuentauser, roluser);
                }


            }
        }


        public bool ValidarCamposLlenosPadre()
        {
            // Verificar que ningún campo esté vacío o contenga el texto del placeholder.
            if (txtnombrepadre.Text == "Nombre(s)" || string.IsNullOrWhiteSpace(txtnombrepadre.Text)) return false;
            if (txtappadre.Text == "Apellido Paterno" || string.IsNullOrWhiteSpace(txtappadre.Text)) return false;
            if (txtampadre.Text == "Apellido Materno" || string.IsNullOrWhiteSpace(txtampadre.Text)) return false;
            if (txtcorreopadre.Text == "Correo Electronico" || string.IsNullOrWhiteSpace(txtcorreopadre.Text)) return false;
            if (txtcodigopostalpadre.Text == "Código Postal" || string.IsNullOrWhiteSpace(txtcodigopostalpadre.Text)) return false;
            if (txtcoloniapadre.Text == "Colonia" || string.IsNullOrWhiteSpace(txtcoloniapadre.Text)) return false;
            if (txtcallepadre.Text == "Calle" || string.IsNullOrWhiteSpace(txtcallepadre.Text)) return false;
            if (txtnoextpadre.Text == "No. Ext." || string.IsNullOrWhiteSpace(txtnoextpadre.Text)) return false;
            if (txtnointpadre.Text == "No. Int." || string.IsNullOrWhiteSpace(txtnointpadre.Text)) return false;

            return true;
        }

        public bool validarCadenasSoloLetras()
        {
            MetodosYFunciones MF = new MetodosYFunciones();
            if (MF.soloLetras(txtnombrepadre.Text) &&
                MF.soloLetras(txtappadre.Text) &&
                MF.soloLetras(txtampadre.Text))
            {
                return true;
            }
            return false;
        }

        private void cargarMunicipios(string ruta)
        {
            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaArchivo = Path.Combine(rutaBase, "Municipios", ruta);

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                comboboxmunicipiopadre.Items.Clear();  
                comboboxmunicipiopadre.Items.AddRange(lineas);
            }
            else
            {
                MessageBox.Show("El archivo no fue encontrado en la carpeta 'Municipios'.");
            }
        }

        private void comboboxestadopadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboboxestadopadre.SelectedItem.ToString())
            {
                case "AGUASCALIENTES":
                    cargarMunicipios(@"Aguascalientes.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "BAJA CALIFORNIA":
                    cargarMunicipios(@"BajaCalifornia.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "BAJA CALIFORNIA SUR":
                    cargarMunicipios(@"BajaCaliforniaSur.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "CAMPECHE":
                    cargarMunicipios("Campeche.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "CHIAPAS":
                    cargarMunicipios("Chiapas.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "CHIHUAHUA":
                    cargarMunicipios("Chihuahua.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "CDMX":
                    cargarMunicipios("CDMX.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "COAHUILA":
                    cargarMunicipios("Coahuila.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "COLIMA":
                    cargarMunicipios("Colima.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "DURANGO":
                    cargarMunicipios("Durango.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "ESTADO DE MEXICO":
                    cargarMunicipios("EdoMex.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "GUANAJUATO":
                    cargarMunicipios("Guanajuato.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "GUERRERO":
                    cargarMunicipios("Guerrero.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "HIDALGO":
                    cargarMunicipios("Hidalgo.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "JALISCO":
                    cargarMunicipios("Jalisco.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "MICHOACAN":
                    cargarMunicipios("Michoacan.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "MORELOS":
                    cargarMunicipios("Morelos.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "NAYARIT":
                    cargarMunicipios("Nayarit.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "NUEVO LEON":
                    cargarMunicipios("NuevoLeon.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "OAXACA":
                    cargarMunicipios("Oaxaca.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "PUEBLA":
                    cargarMunicipios("Puebla.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "QUERETARO":
                    cargarMunicipios("Queretaro.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "QUINTANA ROO":
                    cargarMunicipios("QuintanaRoo.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "SAN LUIS POTOSI":
                    cargarMunicipios("SanLuisPotosi.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "SINALOA":
                    cargarMunicipios("Sinaloa.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "SONORA":
                    cargarMunicipios("Sonora.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "TABASCO":
                    cargarMunicipios("Tabasco.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "TAMAULIPAS":
                    cargarMunicipios("Tamaulipas.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "TLAXCALA":
                    cargarMunicipios("Tlaxcala.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "VERACRUZ":
                    cargarMunicipios("Veracruz.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "YUCATAN":
                    cargarMunicipios("Yucatan.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                case "ZACATECAS":
                    cargarMunicipios("Zacatecas.txt");
                    comboboxmunicipiopadre.SelectedIndex = 0;
                    break;
                default:
                    MessageBox.Show("Estado no encontrado.");
                    break;
            }
        }

        private void CargarDatos(string rfc)
        {
            try
            {
                List<Padre> padres = PadreLogica.Instancia.ObtenerPadreRFC(rfc);
                if (padres.Count > 0)
                {
                    Padre padre = padres[0];
                    txtrfcpadre.Text = padre.RFC;
                    txtrfcpadre.ForeColor = Color.Black;

                    txtnombrepadre.Text = padre.Nombre;
                    txtnombrepadre.ForeColor = Color.Black;

                    txtappadre.Text = padre.ApellidoPaterno;
                    txtappadre.ForeColor = Color.Black;

                    txtampadre.Text = padre.ApellidoMaterno;


                    string anio = rfc.Substring(4, 2);
                    string mes = rfc.Substring(6, 2);
                    string dia = rfc.Substring(8, 2);

                    int anioNacimiento = int.Parse(anio) + (int.Parse(anio) >= 0 && int.Parse(anio) <= 23 ? 2000 : 1900);
                    DateTime fechaNacimiento = new DateTime(anioNacimiento, int.Parse(mes), int.Parse(dia));
                    selectorfecha.Value = fechaNacimiento;

                    txtcorreopadre.Text = padre.Correo;
                    txtcodigopostalpadre.Text = padre.CodigoPostal;
                    txtcoloniapadre.Text = padre.Colonia;
                    txtcallepadre.Text = padre.Calle;
                    txtnoextpadre.Text = padre.NumeroExterior;
                    txtnointpadre.Text = padre.NumeroInterior;

                    txtcorreopadre.ForeColor = Color.Black;
                    txtcodigopostalpadre.ForeColor = Color.Black;
                    txtcoloniapadre.ForeColor = Color.Black;
                    txtcallepadre.ForeColor = Color.Black;
                    txtnoextpadre.ForeColor = Color.Black;
                    txtnointpadre.ForeColor = Color.Black;

                    comboboxestadopadre.SelectedItem = padre.Estado;
                    comboboxmunicipiopadre.SelectedItem = padre.Municipio;
                    comboboxregimenfiscalpadre.SelectedItem = padre.RegimenFiscal;


                }
                else
                {
                    MessageBox.Show("No se encontró ningún alumno con la CURP proporcionada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }




        private void btmodificar_Click(object sender, EventArgs e)
        {
            MetodosYFunciones MF = new MetodosYFunciones();

            DateTime fecha = selectorfecha.Value;
            string fechaF = fecha.ToString("dd/MM/yyyy");

            string rfc = MF.GenerarRFC(txtnombrepadre.Text, txtappadre.Text, txtampadre.Text, fecha);
            string rfcinput = txtrfcpadre.Text.ToString();
            rfcinput = rfcinput.Substring(0, rfcinput.Length - 3);

            bool existe = PadreLogica.Instancia.ExisteRFC(txtrfcpadre.Text.ToString());

            if (!ValidarCamposLlenosPadre())
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (!validarCadenasSoloLetras())
            {
                MessageBox.Show("Está utilizando numeros o caracteres especiales en campos que solo admiten letras.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MF.ValidarCorreoElectronico(txtcorreopadre.Text) == false)
            {
                MessageBox.Show("El correo electronico no es válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MF.validoCP(txtcodigopostalpadre.Text) == false)
            {
                MessageBox.Show("El código postal es incorrecto.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!MF.rangoCP(int.Parse(txtcodigopostalpadre.Text)))
            {
                MessageBox.Show("El código postal está fuera del rango o no pertenece a México", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                DialogResult result = MessageBox.Show("Confirmar cambios del padre",
                                            "Confirmar Cancelar",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Padre objeto = new Padre()
                    {
                        RFC = txtrfcpadre.Text,
                        Nombre = txtnombrepadre.Text,
                        ApellidoPaterno = txtappadre.Text,
                        ApellidoMaterno = txtampadre.Text,
                        Correo = txtcorreopadre.Text,
                        CodigoPostal = txtcodigopostalpadre.Text,
                        Colonia = txtcoloniapadre.Text,
                        Calle = txtcallepadre.Text,
                        NumeroExterior = txtnoextpadre.Text,
                        NumeroInterior = txtnointpadre.Text,
                        Estado = comboboxestadopadre.SelectedItem.ToString(),
                        Municipio = comboboxmunicipiopadre.SelectedItem.ToString(),
                        RegimenFiscal = comboboxregimenfiscalpadre.SelectedItem.ToString()
                    };

                    bool respuesta = PadreLogica.Instancia.Actualizar(objeto);
                    if (respuesta)
                    {
                        txtnombrepadre.Text = "Nombre(s)";
                        txtnombrepadre.ForeColor = Color.Gray;
                        txtappadre.Text = "Apellido Paterno";
                        txtappadre.ForeColor = Color.Gray;
                        txtampadre.Text = "Apellido Materno";
                        txtampadre.ForeColor = Color.Gray;
                        txtcorreopadre.Text = "Correo Electronico";
                        txtcorreopadre.ForeColor = Color.Gray;
                        txtcodigopostalpadre.Text = "Código Postal";
                        txtcodigopostalpadre.ForeColor = Color.Gray;
                        txtcoloniapadre.Text = "Colonia";
                        txtcoloniapadre.ForeColor = Color.Gray;
                        txtcallepadre.Text = "Calle";
                        txtcallepadre.ForeColor = Color.Gray;
                        txtnoextpadre.Text = "No. Ext.";
                        txtnoextpadre.ForeColor = Color.Gray;
                        txtnointpadre.Text = "No. Int.";
                        txtnointpadre.ForeColor = Color.Gray;
                        txtrfcpadre.ForeColor = Color.Gray;
                        txtrfcpadre.Text = "RFC";

                        MessageBox.Show("Los datos se han guardado de manera exitosa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar los datos: Intente de nuevo o consulte el manual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
