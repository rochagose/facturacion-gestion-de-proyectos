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
    public class CertificacionLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static CertificacionLogica _instancia = null;

        public CertificacionLogica() { }


        public static CertificacionLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new CertificacionLogica();
                }
                return _instancia;
            }

        }

        public bool Guardar(Certificacion obj)
        {
            bool respuesta = true;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "INSERT INTO Certificaciones (cadena_certificacion, sello_digital, sello_sat, no_factura) " +
                               "VALUES (@CadenaCertificacion, @SelloDigital, @SelloSAT, @NoFactura)";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@CadenaCertificacion", obj.CadenaCertificacion);
                cmd.Parameters.AddWithValue("@SelloDigital", obj.SelloDigital);
                cmd.Parameters.AddWithValue("@SelloSAT", obj.SelloSAT);
                cmd.Parameters.AddWithValue("@NoFactura", obj.NoFactura);

                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }
    }
}
