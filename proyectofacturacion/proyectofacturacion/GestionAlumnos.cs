using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using proyectofacturacion.Logica;
using proyectofacturacion.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectofacturacion
{
    public partial class GestionAlumnos : Form
    {
        private string roluser;
        private string cuentauser;
        public GestionAlumnos(string cuenta, string rol)
        {
            InitializeComponent();
            roluser = rol;
            cuentauser = cuenta;
            CargarAlumnos();
        }

        private void CargarAlumnos()
        {
            List<Alumno> alumnos = AlumnoLogica.Instancia.ObtenerAlumnos();
            datalumnos.DataSource = alumnos;
        }

        private void ConsultarAlumno(string curp)
        {
            List<Alumno> alumno = AlumnoLogica.Instancia.ObtenerAlumnoCURP(curp);
            datalumnos.DataSource = alumno;
        }

        private void button6_Click(object sender, EventArgs e)
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
                contadorMP.Show();
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btsalir_Click(object sender, EventArgs e)
        {


        }

        private void btgestiondepadresyalumnos_Click(object sender, EventArgs e)
        {
            this.Close();
            AltaAlumno altaAlumno = new AltaAlumno(cuentauser, roluser);
            altaAlumno.Show();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btpdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog pdf = new SaveFileDialog();
            pdf.Filter = "PDF files (*.pdf)|*.pdf";
            pdf.FileName = DateTime.Now.ToString("dd-MM-yyyy");

            string html_texto = Properties.Resources.plantillaGestionAlumnos.ToString();

            string filas = string.Empty;

            foreach (DataGridViewRow row in datalumnos.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["CURP"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Nombre"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["ApellidoPaterno"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["ApellidoMaterno"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["NivelEducativo"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Grupo"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Grado"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["RFC_Padre"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            html_texto = html_texto.Replace("@FILAS", filas);
            html_texto = html_texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
            if (pdf.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(pdf.FileName, FileMode.Create))
                {
                    // Crear el documento PDF
                    Document pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Convertir el HTML en PDF
                    using (StringReader sr = new StringReader(html_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    // Crear la imagen del logo como marca de agua
                    string logoPath = @"C:\Users\Rocha\Desktop\GPS FACTURACION\GPS FACTURACION\proyectofacturacion\proyectofacturacion\Resources\logo.png";
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.ScaleToFit(pdfDoc.PageSize.Width / 4, pdfDoc.PageSize.Height / 4); // Escala para ocupar un cuarto de la página
                    float logoPosX = pdfDoc.PageSize.Width * 0.75f; // Cuadrante inferior derecho
                    float logoPosY = 20;

                    // Ajuste de opacidad
                    PdfContentByte canvas = writer.DirectContentUnder;
                    canvas.SaveState();
                    PdfGState gState = new PdfGState();
                    gState.FillOpacity = 0.1f; // Ajusta la opacidad (0.1 para un 10% de opacidad)
                    canvas.SetGState(gState);


                    foreach (var pageNum in Enumerable.Range(1, writer.PageNumber))
                    {
                        canvas.AddImage(logo, logo.ScaledWidth, 0, 0, logo.ScaledHeight, logoPosX, logoPosY);
                    }

                    canvas.RestoreState();


                    pdfDoc.Close();
                    writer.Close();
                    stream.Close();
                }
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btconsultar_Click(object sender, EventArgs e)
        {
            string curp = txtcurpalumno.Text.ToString();
           
            if (!AlumnoLogica.Instancia.CURPExiste(curp))
            {
                MessageBox.Show("La CURP ingresada no existe o es erronea", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ConsultarAlumno(curp);
                txtcurpalumno.Text = "CURP";
                txtcurpalumno.ForeColor = Color.Gray;
            }
        }

        private void btmodificar_Click(object sender, EventArgs e)
        {
            string curp = txtcurpalumno.Text.ToString();
            if (!AlumnoLogica.Instancia.CURPExiste(curp))
            {
                MessageBox.Show("La CURP ingresada no existe o es erronea", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ModificarAlumno MA = new ModificarAlumno(cuentauser, roluser, curp);
                this.Hide();
                MA.Show();
            }

        }

        private void btdardebaja_Click(object sender, EventArgs e)
        {
            string curp = txtcurpalumno.Text.ToString();
            if (!AlumnoLogica.Instancia.CURPExiste(curp))
            {
                MessageBox.Show("La CURP ingresada no existe o es erronea", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Confirmar baja del alumno",
                "Confirmar Cancelar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if(result == DialogResult.Yes)
                {
                    if (AlumnoLogica.Instancia.Eliminar(curp))
                    {
                        MessageBox.Show("El alumno se ha dado de baja de manera exitosa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcurpalumno.Text = "CURP";
                        txtcurpalumno.ForeColor = Color.Gray;
                        CargarAlumnos();
                    }
                    else
                    {
                        MessageBox.Show("Error al dar de baja al alumno: Intente de nuevo o consulte el manual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

        private void txtcurpalumno_Leave(object sender, EventArgs e)
        {
                if (string.IsNullOrEmpty(txtcurpalumno.Text))
                {
                    txtcurpalumno.Text = "CURP";
                    txtcurpalumno.ForeColor = Color.Gray;
                }
        
            
        }   
    }
}
