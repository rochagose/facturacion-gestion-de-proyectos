using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using proyectofacturacion.Logica;
using proyectofacturacion.Modelo;
using iTextSharp.tool.xml;
using System.Security.Cryptography;
using QRCoder;

namespace proyectofacturacion
{
    public partial class Facturacion : Form
    {
        private string cuentauser;
        private string roluser;
        public Facturacion(string cuenta, string rol)
        {
            InitializeComponent();
            cuentauser = cuenta;
            roluser = rol;
            comboboxmes.SelectedIndex = 0;
            comboboxmetodopago.SelectedIndex = 0;
            comboboxusocfdi.SelectedIndex = 0;
            comboboxformadepago.SelectedIndex = 0;
            
        }

        private static HashSet<Guid> generatedUUIDs = new HashSet<Guid>();


        public static string GenerarFolioSAT()
        {
            Guid newUUID;
            do
            {
                newUUID = Guid.NewGuid(); // Genera un nuevo UUID aleatorio
            } while (generatedUUIDs.Contains(newUUID)); // Verifica que no esté repetido

            generatedUUIDs.Add(newUUID); // Agrega el UUID generado al conjunto para futuras comparaciones
            return newUUID.ToString();
        }

        public static string GenerarCadenaOriginal(string version, string fecha, string rfcemisor, string rfcreceptor,  string razonsocialemisor,
            string razonsocialreceptor, string regimenfiscal, double subtotal, double iva, double total, string metodopago)
        {
            StringBuilder cadenaOriginal = new StringBuilder();

            // Concatenar los elementos de la cadena original (de acuerdo con el formato del SAT)
            cadenaOriginal.Append(version);               // Versión del CFDI
            cadenaOriginal.Append("|");                   // Separador
            cadenaOriginal.Append(fecha);                 // Fecha y hora de emisión
            cadenaOriginal.Append("|");
            cadenaOriginal.Append(rfcemisor);             // RFC del emisor
            cadenaOriginal.Append("|");
            cadenaOriginal.Append(razonsocialemisor);     // Razón social del emisor
            cadenaOriginal.Append("|");
            cadenaOriginal.Append(regimenfiscal);         // Régimen fiscal del emisor
            cadenaOriginal.Append("|");
            cadenaOriginal.Append(rfcreceptor);           // RFC del receptor
            cadenaOriginal.Append("|");
            cadenaOriginal.Append(razonsocialreceptor);   // Razón social del receptor
            cadenaOriginal.Append("|");
            cadenaOriginal.Append(subtotal.ToString("0.00"));  // Subtotal
            cadenaOriginal.Append("|");
            cadenaOriginal.Append(iva.ToString("0.00"));      // IVA
            cadenaOriginal.Append("|");
            cadenaOriginal.Append(total.ToString("0.00"));    // Total de la factura
            cadenaOriginal.Append("|");
            cadenaOriginal.Append(metodopago);              // Método de pago

            return cadenaOriginal.ToString();
        }

        public static string SimularFirmaDigital(string cadenaOriginal)
        {
            using (RSA rsa = RSA.Create())
            {
                // Generar una clave pública/privada simulada para firmar la cadena
                rsa.KeySize = 2048; // Tamaño de la clave (2048 bits es común en RSA)

                // Firmar la cadena original con la clave privada
                byte[] bytes = Encoding.UTF8.GetBytes(cadenaOriginal);
                byte[] signature = rsa.SignData(bytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                // Convertir la firma a Base64 para simular una firma digital
                return Convert.ToBase64String(signature);
            }
        }

        static string GenerarSelloDigital(string cadenaOriginal)
        {
            byte[] hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(cadenaOriginal));
            }

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                RSAParameters rsaParameters = rsa.ExportParameters(true);
                rsa.ImportParameters(rsaParameters);

                byte[] firma = rsa.SignHash(hash, CryptoConfig.MapNameToOID("SHA256"));
                return Convert.ToBase64String(firma);
            }
        }

        static string GenerarSelloSAT(string cadenaOriginal)
        {
            byte[] hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(cadenaOriginal));
            }

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {

                RSAParameters rsaParameters = rsa.ExportParameters(true);
                rsa.ImportParameters(rsaParameters);

                byte[] firma = rsa.SignHash(hash, CryptoConfig.MapNameToOID("SHA256"));


                return Convert.ToBase64String(firma);
            }
        }

        public Bitmap GenerateQRCode(string text)
        {

            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);

            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20); 

            return qrCodeImage;
        }

        public void generarPDF(string nombrearchivo, string nofactura, string fechaEmision, string fechaCertificacion, string codigoPostalEmisor, 
            string rfcEmisor, string nombreEmisor, string regimenFiscalEmisor, string folioSAT, string serieCertificadoEmisor, 
            string nombreReceptor, string rfcReceptor, string usoCFDI, string regimenFiscalReceptor, 
            string domicilioFiscalReceptor, string descripcion, string importe, string metodoPago, string formaPago, string moneda, 
            string total, string totalLetra, string cadenaoriginal, string sellodigital, string sellosat,
            string curpalumno, string nivelalumno, string nombrealumno)
        {
            SaveFileDialog pdf = new SaveFileDialog();
            pdf.Filter = "PDF files (*.pdf)|*.pdf";
            pdf.FileName = nombrearchivo;

            
            string html_texto = Properties.Resources.plantillaFactura.ToString();
            
            html_texto = html_texto.Replace("@NOFACTURA", nofactura);
            html_texto = html_texto.Replace("@FECHAEMISION", fechaEmision);
            html_texto = html_texto.Replace("@FECHACERTIFICACION", fechaCertificacion);
            html_texto = html_texto.Replace("@CODIGOPOSTALEMISOR", codigoPostalEmisor);
            html_texto = html_texto.Replace("@RFCEMISOR", rfcEmisor);
            html_texto = html_texto.Replace("@NOMBREEMISOR", nombreEmisor);
            html_texto = html_texto.Replace("@REGIMENFISCALEMISOR", regimenFiscalEmisor);
            html_texto = html_texto.Replace("@FOLIOSAT", folioSAT);
            html_texto = html_texto.Replace("@SERIECERTIFICADOSAT", serieCertificadoEmisor);
            html_texto = html_texto.Replace("@NOMBRERECEPTOR", nombreReceptor);
            html_texto = html_texto.Replace("@RFCRECEPTOR", rfcReceptor);
            html_texto = html_texto.Replace("@CFDI", usoCFDI);
            html_texto = html_texto.Replace("@REGIMENFISCALRECEPTOR", regimenFiscalReceptor);
            html_texto = html_texto.Replace("@CODIGOPOSTALRECEPTOR", domicilioFiscalReceptor);
            html_texto = html_texto.Replace("@DESCRIPCION", descripcion);
            html_texto = html_texto.Replace("@IMPORTE", importe);
            html_texto = html_texto.Replace("@METODOPAGO", metodoPago);
            html_texto = html_texto.Replace("@FORMAPAGO", formaPago);
            html_texto = html_texto.Replace("@MONEDA", moneda);
            html_texto = html_texto.Replace("@TOTAL", total);
            html_texto = html_texto.Replace("@LETRA", totalLetra);
            html_texto = html_texto.Replace("@CADENAORIGINAL", cadenaoriginal);
            html_texto = html_texto.Replace("@SELLOCFDI", sellodigital);
            html_texto = html_texto.Replace("@SELLOSAT", sellosat);
            html_texto = html_texto.Replace("@NOSERIECERTEMISOR", "00001000000567891234");
            html_texto = html_texto.Replace("@NOSERIECERTSAT", "00001000000987654321");
            html_texto = html_texto.Replace("@CURPALUMNO", curpalumno.ToUpper());
            html_texto = html_texto.Replace("@NIVELALUMNO", nivelalumno.ToUpper());
            html_texto = html_texto.Replace("@NOMBREALUMNO", nombrealumno.ToUpper());
            Bitmap qrCode = GenerateQRCode(sellosat);


            if (pdf.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(pdf.FileName, FileMode.Create))
                {
                    
                    Document pdfDoc = new Document(PageSize.A3, 10, 10, 10, 10);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    
                    using (StringReader sr = new StringReader(html_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }


                    iTextSharp.text.Image qrImage = iTextSharp.text.Image.GetInstance(qrCode, System.Drawing.Imaging.ImageFormat.Png);
                    qrImage.ScaleToFit(120, 120);
                    qrImage.SetAbsolutePosition(pdfDoc.Left + 10, pdfDoc.Bottom + 75); 

                    
                    pdfDoc.Add(qrImage);


                    PdfContentByte canvas = writer.DirectContentUnder;
                    canvas.SaveState();
                    PdfGState gState = new PdfGState();
                    gState.FillOpacity = 0.1f; 
                    canvas.SetGState(gState);

                    canvas.RestoreState();


                    pdfDoc.Close();
                    writer.Close();
                    stream.Close();
                }
            }

        }
        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

        }



        private void btemitir_Click(object sender, EventArgs e)
        {
            //Emisor
            string nombreemisor = UsuarioLogica.Instancia.ObtenerNombreUsuario(cuentauser).ToUpper();
            string rfcemisor = UsuarioLogica.Instancia.ObtenerRFC(cuentauser);
            string regimenemisor = UsuarioLogica.Instancia.ObtenerRegimen(cuentauser);
            string cpemisor = UsuarioLogica.Instancia.ObtenerCP(cuentauser);

            //Receptor
            string nombrereceptor = txtnombrepadre.Text.ToUpper() + " " + txtappadre.Text.ToUpper() + " " + txtampadre.Text.ToUpper();
            string rfcreceptor = txtrfcpadre.Text;
            string regimenreceptor = lblregimenfiscal.Text;
            string cpreceptor = txtcodigopostalpadre.Text;
            string cfdi = comboboxusocfdi.Text;

            //Alumno
            string nombrealumno = txtnombrealumno.Text + " " + txtapalumno.Text + " " + txtamalumno.Text;
            string nivelalumno = txtniveleducativoalumno.Text;
            string gradoalumno = txtgradoalumno.Text;
            string curpalumno = comboboxcurp.Text;

            //Pago y Factura
            int contadorfacturas = FacturaLogica.Instancia.ContarRegistros() + 1;
            string folio = GenerarFolioSAT();
            string nofactura = "A" + contadorfacturas.ToString();
            string fecha = System.DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            string mes = comboboxmes.SelectedItem.ToString();
            string anio = DateTime.Now.Year.ToString();
            string hora = DateTime.Now.Hour.ToString();
            string dia = DateTime.Now.Day.ToString();
            string descripcion = "PAGO POR CONCEPTO DE " + cfdi + " DEL COLEGIO ALTOS DEL CEDRO CON CLAVE: 12PPR0395H CORRESPONDIENTE" +
                " AL MES DE " + mes.ToUpper() + " DEL " + anio + ", DEL ALUMNO " + nombrealumno.ToUpper() + ", QUE CURSA EL " + gradoalumno[0] + " GRADO DE "+ nivelalumno.ToUpper() + 
                ". CURP: " + curpalumno +".";
            string importe = comboboxmonto.SelectedItem.ToString();
            float importefloat = float.Parse(importe.Substring(1));
            string metodopago = comboboxmetodopago.Text;
            string total = comboboxmonto.SelectedItem.ToString();
            float totalfloat = float.Parse(total.Substring(1));
            string totalletra = enletras(total.Substring(1)) + " MXN 00/100";
            string simple = GenerarCadenaOriginal("1.1", fecha, rfcemisor, rfcreceptor, "Colegio Altos del Cedro", "Cliente", regimenemisor, 0.0, 0.0, 0.0, metodopago);
            string cadenaoccsat = SimularFirmaDigital(simple);
            string sellodigital = GenerarSelloDigital(simple);
            string sellosat = GenerarSelloSAT(simple);



            if (txtrfcpadre.Text == "RFC" || string.IsNullOrEmpty(txtrfcpadre.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Confirmar la emisión de la factura",
                                            "Confirmar Cancelar",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    Factura obj = new Factura()
                    {
                        NoFactura = nofactura,
                        SubTotal = importefloat,
                        Total = totalfloat,
                        RFCPadre = rfcreceptor,
                        RFCUsuario = regimenemisor,
                        Descripcion = descripcion,
                        UsoCFDI = cfdi,
                        MetodoPago = metodopago,
                        FormaPago = comboboxformadepago.SelectedItem.ToString(),
                        ConceptoFactura = cfdi,
                        Hora = hora,
                        Dia = dia,
                        Mes = mes,
                        Anio = anio

                    };

                    bool respuesta = FacturaLogica.Instancia.Guardar(obj);
                    if (respuesta) {
                        Certificacion cert = new Certificacion()
                        {
                            CadenaCertificacion = cadenaoccsat,
                            SelloDigital = sellodigital,
                            SelloSAT = sellosat,
                            NoFactura = nofactura
                        };
                        bool res = CertificacionLogica.Instancia.Guardar(cert);
                        if (res) {
                            generarPDF(nofactura, nofactura, fecha, fecha, cpemisor, rfcemisor, nombreemisor, regimenemisor, folio,
                            "Y66DGKJXZZASE3W99V7M", nombrereceptor, rfcreceptor, cfdi, regimenreceptor, cpreceptor,
                            descripcion, importe, metodopago, comboboxformadepago.SelectedItem.ToString(), "MXN Peso Mexicano", total, totalletra, cadenaoccsat,
                            sellodigital, sellosat, curpalumno, nivelalumno, nombrealumno);
                            MessageBox.Show("La factura se ha emitido de manera éxitosa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error al emitir la factura: Intente de nuevo o consulte el manual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Operacion cancelada", "Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
        }

        private void panel9_MouseDown(object sender, MouseEventArgs e)
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

        private void btconsultar_Click(object sender, EventArgs e)
        {
            string rfc = txtrfcpadre.Text.ToString();
            List<string> alumno = AlumnoLogica.Instancia.ObtenerCurpsPorRFCPadre(rfc);

            if (alumno.Count == 0) {
                MessageBox.Show("No se encontró ningún alumno registrado para el RFC del padre.");
            }
            else
            {
                CargarDatos(rfc);
                comboboxcurp.Items.AddRange(alumno.ToArray());
                comboboxcurp.SelectedIndex = 0;
                if(lblregimenfiscal.Text == "605 - SUELDOS Y SALARIOS E INGRESOS ASIMILADOS A SALARIOS")
                {
                    comboboxusocfdi.Items.Clear();
                    comboboxusocfdi.Items.Add("TRANSPORTE ESCOLAR");
                    comboboxusocfdi.Items.Add("PAGOS POR SERVICIOS EDUCATIVOS (COLEGIATURAS)");
                    comboboxusocfdi.SelectedIndex = 0;
                }else if (lblregimenfiscal.Text == "626 - SIMPLIFICADO DE CONFIANZA")
                {
                    comboboxusocfdi.Items.Clear();
                    comboboxusocfdi.Items.Add("GASTOS EN GENERAL");
                    comboboxusocfdi.Items.Add("PAGOS POR SERVICIOS EDUCATIVOS (COLEGIATURAS)");
                    comboboxusocfdi.SelectedIndex = 0;
                }
                else if(lblregimenfiscal.Text == "612 - PERSONA FISICA CON ACTIVIDAD EMPRESARIAL")
                {
                    comboboxusocfdi.Items.Clear();
                    comboboxusocfdi.Items.Add("GASTOS EN GENERAL");
                    comboboxusocfdi.Items.Add("PAGOS POR SERVICIOS EDUCATIVOS (COLEGIATURAS)");
                    comboboxusocfdi.SelectedIndex = 0;
                }
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
                    txtampadre.ForeColor = Color.Black;

                    txtcorreopadre.Text = padre.Correo;
                    txtcorreopadre.ForeColor = Color.Black;

                    txtcodigopostalpadre.Text = padre.CodigoPostal;
                    txtcodigopostalpadre.ForeColor = Color.Black;

                    lblregimenfiscal.Text = padre.RegimenFiscal;
                    lblregimenfiscal.ForeColor = Color.Black;

                }
                else
                {
                    MessageBox.Show("No se encontró ningún padre con el RFC proporcionado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
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

        private void txtrfcpadre_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtrfcpadre.Text))
            {
                txtrfcpadre.Text = "RFC";
                txtrfcpadre.ForeColor = Color.Gray;
            }
        }

        private void comboboxcurp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curp = comboboxcurp.Text.ToString();
            List<Alumno> alumnos = AlumnoLogica.Instancia.ObtenerAlumnoCURP(curp);
            Alumno alumno = alumnos[0];

            txtnombrealumno.Text = alumno.Nombre;
            txtnombrealumno.ForeColor = Color.Black;

            txtapalumno.Text = alumno.ApellidoPaterno;
            txtapalumno.ForeColor = Color.Black;

            txtamalumno.Text = alumno.ApellidoMaterno;
            txtamalumno.ForeColor = Color.Black;

            txtgradoalumno.Text = alumno.Grado;
            txtgradoalumno.ForeColor = Color.Black;

            txtgrupoalumno.Text = alumno.Grupo;
            txtgrupoalumno.ForeColor = Color.Black;

            txtniveleducativoalumno.Text = alumno.NivelEducativo;
            txtniveleducativoalumno.ForeColor = Color.Black;

            comboboxusocfdi.SelectedIndex = 2;

        }


        private void txtniveleducativoalumno_TextChanged(object sender, EventArgs e)
        {
            if(txtniveleducativoalumno.Text == "Kinder")
            {
                comboboxmonto.Items.Clear();
                comboboxmonto.Items.Add("$2000");
                comboboxmonto.SelectedIndex = 0;
                
            }
            if(txtniveleducativoalumno.Text == "Primaria")
            {
                comboboxmonto.Items.Clear();
                comboboxmonto.Items.Add("$2500");
                comboboxmonto.SelectedIndex = 0;
            }
            if (txtniveleducativoalumno.Text == "Secundaria")
            {
                comboboxmonto.Items.Clear();
                comboboxmonto.Items.Add("$3000");
                comboboxmonto.SelectedIndex = 0;
            }


        }

        private void comboboxusocfdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboboxusocfdi.SelectedIndex == 0)
            {
                comboboxmonto.Items.Clear();
                comboboxmonto.Items.Add("$500");
                comboboxmonto.Items.Add("$1000");
                comboboxmonto.Items.Add("$1500");
                comboboxmonto.Items.Add("$2000");
                comboboxmonto.Items.Add("$2500");
                comboboxmonto.Items.Add("$3000");
                comboboxmonto.SelectedIndex = 0;
            }
            if (comboboxusocfdi.SelectedIndex == 1)
            {
                comboboxmonto.Items.Clear();
                comboboxmonto.Items.Add("$250");
                comboboxmonto.Items.Add("$500");
                comboboxmonto.Items.Add("$1000");
                comboboxmonto.SelectedIndex = 0;
            }
        }
    }
}
