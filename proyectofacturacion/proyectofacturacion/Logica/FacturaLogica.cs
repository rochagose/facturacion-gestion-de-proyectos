using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyectofacturacion.Modelo;

namespace proyectofacturacion.Logica
{
    public class FacturaLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static FacturaLogica _instancia = null;

        public FacturaLogica() { }


        public static FacturaLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new FacturaLogica();
                }
                return _instancia;
            }

        }

        public bool Guardar(Factura obj)
        {
            bool respuesta = true;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "INSERT INTO Facturas (no_factura, subtotal_factura, total_factura, rfc_padre, rfc_usuario, descripcion_factura, " +
                    "uso_cfdi," +
                    "metodo_pago, forma_pago, concepto_factura, hora_emision, dia_emision, mes_emision, anio_emision) " +
                               "VALUES (@NoFactura, @SubTotal, @Total, @RFCPadre, @RFCUsuario, @Descripcion, @UsoCFDI, @MetodoPago, @FormaPago, " +
                               "@ConceptoFactura, @Hora," +
                               "@Dia, @Mes, @Anio)";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@NoFactura", obj.NoFactura);
                cmd.Parameters.AddWithValue("@SubTotal", obj.SubTotal);
                cmd.Parameters.AddWithValue("@Total", obj.Total);
                cmd.Parameters.AddWithValue("@RFCPadre", obj.RFCPadre);
                cmd.Parameters.AddWithValue("@RFCUsuario", obj.RFCUsuario);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("@UsoCFDI", obj.UsoCFDI);
                cmd.Parameters.AddWithValue("@MetodoPago", obj.MetodoPago);
                cmd.Parameters.AddWithValue("@FormaPago", obj.FormaPago);
                cmd.Parameters.AddWithValue("@ConceptoFactura", obj.ConceptoFactura);
                cmd.Parameters.AddWithValue("@Hora", obj.Hora);
                cmd.Parameters.AddWithValue("@Dia", obj.Dia);
                cmd.Parameters.AddWithValue("@Mes", obj.Mes);
                cmd.Parameters.AddWithValue("@Anio", obj.Anio);

                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public int ContarRegistros()
        {
            int totalRegistros = 0;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string queryCount = "SELECT COUNT(*) FROM Facturas";
                SQLiteCommand cmdCount = new SQLiteCommand(queryCount, con);
                totalRegistros = Convert.ToInt32(cmdCount.ExecuteScalar());
            }

            return totalRegistros;
        }

    }
}
