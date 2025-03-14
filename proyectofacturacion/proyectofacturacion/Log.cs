using proyectofacturacion.Logica;
using proyectofacturacion.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;
using System.Runtime.InteropServices;


namespace proyectofacturacion
{
    public partial class Log : Form
    {

        private string cuentauser;
        private string roluser;
        public Log(string cuenta, string rol)
        {
            cuentauser = cuenta;
            roluser = rol;
            InitializeComponent();
            CargarSesiones();
        }

        private void CargarSesiones()
        {
            List<Bitacora> sesiones = BitacoraLogica.Instancia.ObtenerSesiones();
            databitacora.DataSource = sesiones;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btpdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog pdf = new SaveFileDialog();
            pdf.Filter = "PDF files (*.pdf)|*.pdf";
            pdf.FileName = DateTime.Now.ToString("dd-MM-yyyy");

            string html_texto = Properties.Resources.plantilla.ToString();

            string filas = string.Empty;

            foreach (DataGridViewRow row in databitacora.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Cuenta"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Fecha"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Evento"].Value.ToString() + "</td>";
                filas += "</tr>";
            }

            html_texto = html_texto.Replace("@FECHA", DateTime.Now.ToString("dd-MM-yyyy"));
            html_texto = html_texto.Replace("@FILAS", filas);

            if (pdf.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(pdf.FileName, FileMode.Create))
                {
                    // Crear el documento PDF
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
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

                    // Agregar la imagen en cada página como marca de agua
                    foreach (var pageNum in Enumerable.Range(1, writer.PageNumber))
                    {
                        canvas.AddImage(logo, logo.ScaledWidth, 0, 0, logo.ScaledHeight, logoPosX, logoPosY);
                    }

                    canvas.RestoreState();

                    // Cerrar el documento PDF
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
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            DirectorMP directorMP = new DirectorMP(cuentauser, roluser);
            directorMP.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
