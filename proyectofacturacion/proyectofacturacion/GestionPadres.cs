using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using proyectofacturacion.Logica;
using proyectofacturacion.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace proyectofacturacion
{
    public partial class GestionPadres : Form
    {
        private string roluser;
        private string cuentauser;
        public GestionPadres(string cuenta, string rol)
        {
            InitializeComponent();
            roluser = rol;
            cuentauser = cuenta;
            CargarPadres();
        }

        private void CargarPadres()
        {
            List<Padre> padres = PadreLogica.Instancia.ObtenerPadres();
            datapadres.DataSource = padres;
        }

        private void btsalir_Click(object sender, EventArgs e)
        {
            if(roluser == "Director")
            {
                DirectorMP directorMP = new DirectorMP(cuentauser, roluser);
                directorMP.Show();
                this.Close();
            }
            else
            {
                ContadorMP contadorMP = new ContadorMP(cuentauser, roluser);
                contadorMP.Show();
                this.Close();
            }
        }

        private void btdaraltapadre_Click(object sender, EventArgs e)
        {
            AltaPadre altapadre = new AltaPadre(cuentauser, roluser);
            altapadre.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (roluser == "Director")
            {
                DirectorMP directorMP = new DirectorMP(cuentauser, roluser);
                directorMP.Show();
                this.Close();
            }
            if(roluser == "Contador")
            {
                ContadorMP contadorMP = new ContadorMP(cuentauser, roluser);
                contadorMP.Show();
                this.Close();
            }
        }

        private void btpdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog pdf = new SaveFileDialog();
            pdf.Filter = "PDF files (*.pdf)|*.pdf";
            pdf.FileName = DateTime.Now.ToString("dd-MM-yyyy");

            string html_texto = Properties.Resources.plantillaGestionPadres.ToString();

            string filas = string.Empty;


            foreach (DataGridViewRow row in datapadres.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["RFC"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Nombre"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["ApellidoPaterno"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["ApellidoMaterno"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Correo"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["CodigoPostal"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Colonia"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Calle"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["NumeroExterior"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["NumeroInterior"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Estado"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Municipio"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["RegimenFiscal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            html_texto = html_texto.Replace("@FECHA", DateTime.Now.ToString("dd-MM-yyyy"));
            html_texto = html_texto.Replace("@FILAS", filas);
            if (pdf.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(pdf.FileName, FileMode.Create))
                {
                    // Crear el documento PDF
                    Document pdfDoc = new Document(PageSize.A3.Rotate(), 25, 25, 25, 25);
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

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

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

        private void btconsultar_Click(object sender, EventArgs e)
        {
            string rfc= txtrfcpadre.Text.ToString();

            if (!PadreLogica.Instancia.ExisteRFC(rfc))
            {
                MessageBox.Show("El RFC ingresadp no existe o es erronea", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ConsultarPadre(rfc);
                txtrfcpadre.Text = "RFC";
                txtrfcpadre.ForeColor = Color.Gray;
            }
        }

        private void txtrfcpadre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtrfcpadre.Text))
            {
                txtrfcpadre.Text = "RFC";
                txtrfcpadre.ForeColor = Color.Gray;
            }
        }

        private void txtrfcpadre_Enter(object sender, EventArgs e)
        {
            if (txtrfcpadre.Text == "RFC")
            {
                txtrfcpadre.Text = "";
                txtrfcpadre.ForeColor = Color.Black;
            }
        }

        private void ConsultarPadre(string rfc)
        {
            List<Padre> padre = PadreLogica.Instancia.ObtenerPadreRFC(rfc);
            datapadres.DataSource = padre;
        }

        private void btdardebaja_Click(object sender, EventArgs e)
        {
            string rfc = txtrfcpadre.Text.ToString();
            if (!PadreLogica.Instancia.ExisteRFC(rfc))
            {
                MessageBox.Show("El RFC ingresado no existe o es erronea", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Confirmar baja del padre",
                "Confirmar Cancelar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (PadreLogica.Instancia.Eliminar(rfc))
                    {
                        MessageBox.Show("El padre se ha dado de baja de manera exitosa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtrfcpadre.Text = "";
                        txtrfcpadre.ForeColor = Color.Black;
                        AlumnoLogica.Instancia.EliminarRFCPadre(rfc);
                        CargarPadres();     
                    }
                    else
                    {
                        MessageBox.Show("Error al dar de baja al alumno: Intente de nuevo o consulte el manual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btmodificar_Click(object sender, EventArgs e)
        {
            string rfc = txtrfcpadre.Text.ToString();
            if (!PadreLogica.Instancia.ExisteRFC(rfc))
            {
                MessageBox.Show("El RFC ingresado no existe o es erronea", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ModificarPadre MPa = new ModificarPadre(cuentauser, roluser, rfc);
                this.Hide();
                MPa.Show();
            }

        }
    }
}
