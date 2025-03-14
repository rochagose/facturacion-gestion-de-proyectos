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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectofacturacion
{
    public partial class ModificarAlumno : Form
    {
        private string cuentauser;
        private string roluser;
        public ModificarAlumno(string cuenta, string rol, string curp)
        {
            cuentauser = cuenta;
            roluser = rol;
            InitializeComponent();

            comboboxestadoalumno.SelectedIndex = 0;
            comboboxsexoalumno.SelectedIndex = 0;

            DateTime fecha = selectorfecha.Value;
            string fechaF = fecha.ToString("dd/MM/yyyy");
            DateTime fechaNacimiento = DateTime.ParseExact(fechaF, "dd/MM/yyyy", null);
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaNacimiento.Year;
            cargarNE();
            ValidarGrados(edad);

            CargarDatos(curp);
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel9_MouseDown(object sender, MouseEventArgs e)
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

        public string ObtenerAbreviaturaEstado(string estado)
        {
            switch (estado.ToUpper())
            {
                case "AGUASCALIENTES": return "AS";
                case "BAJA CALIFORNIA": return "BC";
                case "BAJA CALIFORNIA SUR": return "BS";
                case "CAMPECHE": return "CC";
                case "CHIAPAS": return "CS";
                case "CHIHUAHUA": return "CH";
                case "CDMX": return "DF";
                case "COAHUILA": return "CL";
                case "COLIMA": return "CM";
                case "DURANGO": return "DG";
                case "GUANAJUATO": return "GT";
                case "GUERRERO": return "GR";
                case "HIDALGO": return "HG";
                case "JALISCO": return "JC";
                case "ESTADO DE MEXICO": return "MC";
                case "MICHOACAN": return "MN";
                case "MORELOS": return "MS";
                case "NAYARIT": return "NT";
                case "NUEVO LEON": return "NL";
                case "OAXACA": return "OC";
                case "PUEBLA": return "PL";
                case "QUERETARO": return "QT";
                case "QUINTANA ROO": return "QR";
                case "SAN LUIS POTOSI": return "SP";
                case "SINALOA": return "SL";
                case "SONORA": return "SR";
                case "TABASCO": return "TC";
                case "TAMAULIPAS": return "TS";
                case "TLAXCALA": return "TL";
                case "VERACRUZ": return "VZ";
                case "YUCATAN": return "YN";
                case "ZACATECAS": return "ZS";
                default: return "XX";
            }
        }

        public string ObtenerNombreEstado(string abreviatura)
        {
            switch (abreviatura.ToUpper())
            {
                case "AS": return "AGUASCALIENTES";
                case "BC": return "BAJA CALIFORNIA";
                case "BS": return "BAJA CALIFORNIA SUR";
                case "CC": return "CAMPECHE";
                case "CS": return "CHIAPAS";
                case "CH": return "CHIHUAHUA";
                case "DF": return "CDMX";
                case "CL": return "COAHUILA";
                case "CM": return "COLIMA";
                case "DG": return "DURANGO";
                case "GT": return "GUANAJUATO";
                case "GR": return "GUERRERO";
                case "HG": return "HIDALGO";
                case "JC": return "JALISCO";
                case "MC": return "ESTADO DE MÉXICO";
                case "MN": return "MICHOACÁN";
                case "MS": return "MORELOS";
                case "NT": return "NAYARIT";
                case "NL": return "NUEVO LEÓN";
                case "OC": return "OAXACA";
                case "PL": return "PUEBLA";
                case "QT": return "QUERÉTARO";
                case "QR": return "QUINTANA ROO";
                case "SP": return "SAN LUIS POTOSÍ";
                case "SL": return "SINALOA";
                case "SR": return "SONORA";
                case "TC": return "TABASCO";
                case "TS": return "TAMAULIPAS";
                case "TL": return "TLAXCALA";
                case "VZ": return "VERACRUZ";
                case "YN": return "YUCATÁN";
                case "ZS": return "ZACATECAS";
                default: return "ESTADO DESCONOCIDO";
            }
        }



        public void ValidarGrados(int edad)
        {
            switch (edad)
            {
                // Kinder
                case 3:
                    comboboxgrado.Items.Clear();
                    comboboxgrado.Items.Add("1ero");
                    comboboxgrado.SelectedItem = "1ero";
                    break;
                case 4:
                    comboboxgrado.Items.Clear();
                    comboboxgrado.Items.Add("2do");
                    comboboxgrado.SelectedItem = "2do";
                    break;
                case 5:
                    comboboxgrado.Items.Clear();
                    comboboxgrado.Items.Add("3ro");
                    comboboxgrado.SelectedItem = "3ro";
                    break;
                // Primaria
                case 6:
                    comboboxgrado.Items.Clear();
                    comboboxgrado.Items.Add("1ero");
                    comboboxgrado.SelectedItem = "1ero";
                    break;
                case 7:
                    comboboxgrado.Items.Clear();
                    comboboxgrado.Items.Add("2do");
                    comboboxgrado.SelectedItem = "2do";
                    break;
                case 8:
                    comboboxgrado.Items.Clear();
                    comboboxgrado.Items.Add("3ro");
                    comboboxgrado.SelectedItem = "3ro";
                    break;
                case 9:
                    comboboxgrado.Items.Clear();
                    comboboxgrado.Items.Add("4to");
                    comboboxgrado.SelectedItem = "4to";
                    break;
                case 10:
                    comboboxgrado.Items.Clear();
                    comboboxgrado.Items.Add("5to");
                    comboboxgrado.SelectedItem = "5to";
                    break;
                case 11:
                    comboboxgrado.Items.Clear();
                    comboboxgrado.Items.Add("6to");
                    comboboxgrado.SelectedItem = "6to";
                    break;
                case 12:
                    comboboxgrado.Items.Clear();
                    comboboxgrado.Items.Add("6to");
                    comboboxgrado.SelectedItem = "6to";
                    break;
                // Secundaria

                case 13:
                    comboboxgrado.Items.Clear();
                    comboboxgrado.Items.Add("1ero");
                    comboboxgrado.SelectedItem = "1ero";
                    break;
                case 14:
                    comboboxgrado.Items.Clear();
                    comboboxgrado.Items.Add("2do");
                    comboboxgrado.SelectedItem = "2do";
                    break;
                case 15:
                    comboboxgrado.Items.Clear();
                    comboboxgrado.Items.Add("3ro");
                    comboboxgrado.SelectedItem = "3ro";
                    break;


            }
        }

        private void selectorfecha_ValueChanged(object sender, EventArgs e)
        {
            cargarNE();

        }
        public void cargarNE()
        {
            comboboxniveleducativo.Items.Clear();
            DateTime fecha = selectorfecha.Value;
            string fechaF = fecha.ToString("dd/MM/yyyy");
            DateTime fechaNacimiento = DateTime.ParseExact(fechaF, "dd/MM/yyyy", null);
            DateTime fechaActual = DateTime.Today;

            int edad = fechaActual.Year - fechaNacimiento.Year;
            if (edad >= 3 && edad <= 6)
            {
                comboboxniveleducativo.Enabled = true;
                comboboxniveleducativo.Items.Clear();
                comboboxniveleducativo.Items.Add("Kinder");
                comboboxniveleducativo.SelectedItem = "Kinder";
            }
            else if (edad >= 6 && edad <= 12)
            {
                comboboxniveleducativo.Enabled = true;
                comboboxniveleducativo.Items.Clear();
                comboboxniveleducativo.Items.Add("Primaria");
                comboboxniveleducativo.SelectedItem = "Primaria";
            }
            else if (edad >= 12 && edad <= 15)
            {
                comboboxniveleducativo.Enabled = true;
                comboboxniveleducativo.Items.Clear();
                comboboxniveleducativo.Items.Add("Secundaria");
                comboboxniveleducativo.SelectedItem = "Secundaria";
            }
            else
            {
                comboboxniveleducativo.Items.Clear();
                comboboxniveleducativo.Enabled = false;
            }
        }

        private void btmodificar_Click(object sender, EventArgs e)
        {
            MetodosYFunciones MF = new MetodosYFunciones();
            DateTime fecha = selectorfecha.Value;
            string fechaF = fecha.ToString("dd/MM/yyyy");
            DateTime fechaNacimiento = DateTime.ParseExact(fechaF, "dd/MM/yyyy", null);
            DateTime fechaActual = DateTime.Today;

            int edad = fechaActual.Year - fechaNacimiento.Year;

            string sexo = comboboxsexoalumno.SelectedItem.ToString();
            string edo = ObtenerAbreviaturaEstado(comboboxestadoalumno.SelectedItem.ToString());

            string CURP = MF.GenerarCURP(txtnombrealumno.Text, txtapalumno.Text, txtamalumno.Text, fecha, sexo, edo);
            string CURPinput = txtcurpalumno.Text.ToString();
            CURPinput = CURPinput.Substring(0, CURPinput.Length - 2);

            if (!ValidarCamposLlenosAlumno())
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!validarCadenasSoloLetras())
            {
                MessageBox.Show("Está utilizando numeros o caracteres especiales en campos que solo admiten letras.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                DialogResult result = MessageBox.Show("Confirmar modificación del alumno",
                            "Confirmar Cancelar",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                bool existerfcpadre = PadreLogica.Instancia.ExisteRFC(txtrfcpadre.Text);
                bool existe = AlumnoLogica.Instancia.CURPExiste(txtcurpalumno.Text.ToString());
                if (result == DialogResult.Yes && existerfcpadre)
                {
                    Alumno objeto = new Alumno()
                    {
                        CURP = txtcurpalumno.Text,
                        Nombre = txtnombrealumno.Text,
                        ApellidoPaterno = txtapalumno.Text,
                        ApellidoMaterno = txtamalumno.Text,
                        NivelEducativo = comboboxniveleducativo.SelectedItem.ToString(),
                        Grupo = txtgrupoalumno.Text,
                        Grado = comboboxgrado.SelectedItem.ToString(),
                        RFC_Padre = txtrfcpadre.Text

                    };

                    bool respuesta = AlumnoLogica.Instancia.Actualizar(objeto);
                    Console.WriteLine(respuesta);

                    if (respuesta)
                    {
                        txtcurpalumno.Text = "CURP";
                        txtcurpalumno.ForeColor = Color.Gray;

                        txtnombrealumno.Text = "Nombre(s)";
                        txtnombrealumno.ForeColor = Color.Gray;

                        txtapalumno.Text = "Apellido Paterno";
                        txtapalumno.ForeColor = Color.Gray;

                        txtamalumno.Text = "Apellido Materno";
                        txtamalumno.ForeColor = Color.Gray;

                        txtgrupoalumno.Text = "Grupo";
                        txtgrupoalumno.ForeColor = Color.Gray;

                        comboboxgrado.SelectedIndex = -1; // Restablece la selección
                        comboboxgrado.Text = "Grado";
                        comboboxgrado.ForeColor = Color.Gray;

                        txtrfcpadre.Text = "RFC Padre";
                        txtrfcpadre.ForeColor = Color.Gray;

                        MessageBox.Show("Los datos se han guardado de manera exitosa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        GestionAlumnos GA = new GestionAlumnos(cuentauser, roluser);
                        GA.Show();
                    }
                }
                else if (existe)
                {
                    MessageBox.Show("Error: La CURP especificada ya fue dada de alta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (existerfcpadre == false)
                {
                    MessageBox.Show("Error: El RFC del padre no está dado de alta o es incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos: Intente de nuevo o consulte el manual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        static bool SoloLetras(string input)
        {
            string patron = "^[a-zA-ZÁÉÍÓÚáéíóúÑñ\\s]+$";
            Regex regex = new Regex(patron);
            return regex.IsMatch(input);
        }

        static bool ValidarRFC(string rfc)
        {
            string patron = @"^([A-Z]{3,4}\d{6}(?:[A-Z0-9]{3})?)$";
            Regex regex = new Regex(patron);
            return regex.IsMatch(rfc);
        }

        public bool validarCadenasSoloLetras()
        {
            if (SoloLetras(txtnombrealumno.Text) &&
                SoloLetras(txtapalumno.Text) &&
                SoloLetras(txtamalumno.Text) &&
                SoloLetras(txtgrupoalumno.Text))
            {
                return true;
            }
            return false;
        }

        public bool ValidarCamposLlenosAlumno()
        {

            if (txtcurpalumno.Text == "CURP" || string.IsNullOrWhiteSpace(txtcurpalumno.Text)) return false;
            if (txtnombrealumno.Text == "Nombre(s)" || string.IsNullOrWhiteSpace(txtnombrealumno.Text)) return false;
            if (txtapalumno.Text == "Apellido Paterno" || string.IsNullOrWhiteSpace(txtapalumno.Text)) return false;
            if (txtamalumno.Text == "Apellido Materno" || string.IsNullOrWhiteSpace(txtamalumno.Text)) return false;
            if (comboboxniveleducativo.SelectedItem == null || string.IsNullOrWhiteSpace(comboboxniveleducativo.SelectedItem.ToString())) return false;
            if (comboboxsexoalumno.SelectedItem == null || string.IsNullOrWhiteSpace(comboboxniveleducativo.SelectedItem.ToString())) return false;
            if (txtgrupoalumno.Text == "Grupo" || string.IsNullOrWhiteSpace(txtgrupoalumno.Text)) return false;
            if (comboboxgrado.SelectedItem == null || string.IsNullOrWhiteSpace(comboboxgrado.SelectedItem.ToString())) return false;
            if (txtrfcpadre.Text == "RFC" || string.IsNullOrWhiteSpace(txtrfcpadre.Text)) return false;
            if (txtcurpalumno.Text == "CURP" || string.IsNullOrWhiteSpace(txtcurpalumno.Text)) return false;
            return true;
        }

        private void CargarDatos(string curp)
        {
            try
            {
                List<Alumno> alumnos = AlumnoLogica.Instancia.ObtenerAlumnoCURP(curp);
                if (alumnos.Count > 0)
                {
                    Alumno alumno = alumnos[0];
                    txtcurpalumno.Text = alumno.CURP;
                    txtcurpalumno.ForeColor = Color.Black;

                    txtnombrealumno.Text = alumno.Nombre;
                    txtnombrealumno.ForeColor = Color.Black;

                    txtapalumno.Text = alumno.ApellidoPaterno;
                    txtapalumno.ForeColor = Color.Black;

                    txtamalumno.Text = alumno.ApellidoMaterno;
                    txtamalumno.ForeColor = Color.Black;

                    txtgrupoalumno.Text = alumno.Grupo;
                    txtgrupoalumno.ForeColor = Color.Black;

                    txtrfcpadre.Text = alumno.RFC_Padre;
                    txtrfcpadre.ForeColor = Color.Black;

                    string anio = curp.Substring(4, 2);
                    string mes = curp.Substring(6, 2);
                    string dia = curp.Substring(8, 2);

                    int anioNacimiento = int.Parse(anio) + (int.Parse(anio) >= 0 && int.Parse(anio) <= 23 ? 2000 : 1900);
                    DateTime fechaNacimiento = new DateTime(anioNacimiento, int.Parse(mes), int.Parse(dia));
                    selectorfecha.Value = fechaNacimiento;

                    string sexo = curp.Substring(10, 1);
                    comboboxsexoalumno.SelectedItem = sexo;

                    comboboxestadoalumno.SelectedItem = ObtenerNombreEstado(curp.Substring(11, 2));


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

        private void txtnombrealumno_Enter(object sender, EventArgs e)
        {
            if (txtnombrealumno.Text == "Nombre(s)")
            {
                txtnombrealumno.Text = "";
                txtnombrealumno.ForeColor = Color.Black;
            }
        }

        private void txtapalumno_Enter(object sender, EventArgs e)
        {
            if (txtapalumno.Text == "Apellido Paterno")
            {
                txtapalumno.Text = "";
                txtapalumno.ForeColor = Color.Black;
            }
        }

        private void txtamalumno_Enter(object sender, EventArgs e)
        {
            if (txtamalumno.Text == "Apellido Materno")
            {
                txtamalumno.Text = "";
                txtamalumno.ForeColor = Color.Black;
            }
        }

        private void txtcurpalumno_Enter(object sender, EventArgs e)
        {
            if (txtcurpalumno.Text == "CURP")
            {
                txtcurpalumno.Text = "";
                txtcurpalumno.ForeColor = Color.Black;
            }
        }

        private void txtgrupoalumno_Enter(object sender, EventArgs e)
        {
            if (txtgrupoalumno.Text == "Grupo")
            {
                txtgrupoalumno.Text = "";
                txtgrupoalumno.ForeColor = Color.Black;
            }

        }

        private void txtrfcpadre_Enter(object sender, EventArgs e)
        {
            if (txtrfcpadre.Text == "RFC Padre")
            {
                txtrfcpadre.Text = "";
                txtrfcpadre.ForeColor = Color.Black;
            }

        }

        private void txtnombrealumno_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtnombrealumno.Text))
            {
                txtnombrealumno.Text = "Nombre(s)";
                txtnombrealumno.ForeColor = Color.Gray;
            }
        }

        private void txtapalumno_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtapalumno.Text))
            {
                txtapalumno.Text = "Apellido Paterno";
                txtapalumno.ForeColor = Color.Gray;
            }
        }

        private void txtamalumno_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtamalumno.Text))
            {
                txtamalumno.Text = "Apellido Materno";
                txtamalumno.ForeColor = Color.Gray;
            }
        }

        private void txtcurpalumno_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcurpalumno.Text))
            {
                txtcurpalumno.Text = "CURP";
                txtcurpalumno.ForeColor = Color.Gray;
            }
        }

        private void txtgrupoalumno_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtgrupoalumno.Text))
            {
                txtgrupoalumno.Text = "Grupo";
                txtgrupoalumno.ForeColor = Color.Gray;
            }
        }

        private void txtrfcpadre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtrfcpadre.Text))
            {
                txtrfcpadre.Text = "RFC Padre";
                txtrfcpadre.ForeColor = Color.Gray;
            }
        }
    }
}
