using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyectofacturacion.Modelo;
using System.Data.SQLite;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;

namespace proyectofacturacion.Logica
{
    public class BitacoraLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static BitacoraLogica _instancia = null;

        public BitacoraLogica() { }

        public static BitacoraLogica Instancia
        {
            get
            {
                if(_instancia == null)
                {
                    _instancia = new BitacoraLogica();
                }
                return _instancia;
            }
        }

        public bool Registrar(Bitacora obj)
        {
            bool respuesta = true;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "INSERT INTO Sesiones(cuenta_usuario, fecha, evento)" +
                    "VALUES (@Cuenta, @Fecha, @Evento)";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@Cuenta", obj.Cuenta);
                cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                cmd.Parameters.AddWithValue("@Evento", obj.Evento);

                cmd.CommandType = System.Data.CommandType.Text;
                
                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
                return respuesta;
            }
        }
        public List<Bitacora> ObtenerSesiones()
        {
            List<Bitacora> listaSesiones = new List<Bitacora>();

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT id, cuenta_usuario, fecha, evento FROM Sesiones";
                SQLiteCommand cmd = new SQLiteCommand(query, con);

                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Bitacora sesion = new Bitacora
                        {
                            Cuenta = dr["cuenta_usuario"].ToString(),
                            Fecha = Convert.ToDateTime(dr["fecha"]).ToString("yyyy-MM-dd HH:mm:ss"),
                            Evento = dr["evento"].ToString()
                        };
                        listaSesiones.Add(sesion);
                    }
                }
            }
            return listaSesiones;
        }

    }
}
