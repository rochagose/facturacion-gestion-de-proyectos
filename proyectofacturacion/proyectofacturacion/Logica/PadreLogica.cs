using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using proyectofacturacion.Modelo;

namespace proyectofacturacion.Logica
{
    public class PadreLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static PadreLogica _instancia = null;

        public PadreLogica() { }

        public static PadreLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new PadreLogica();
                }
                return _instancia;
            }

        }
        public bool Guardar(Padre obj)
        {
            bool respuesta = true;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "INSERT INTO Padres (rfc_padre, nombre_padre, " +
                               "ap_padre, am_padre, correo_padre, cp_padre, colonia_padre, calle_padre, no_ext_padre, " +
                               "no_int_padre, estado_padre, municipio_padre, regimen_fiscal_padre) " +
                               "VALUES (@RFC, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Correo, " +
                               "@CodigoPostal, @Colonia, @Calle, @NumeroExterior, @NumeroInterior, @Estado, @Municipio, @RegimenFiscal)";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@RFC", obj.RFC);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", obj.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", obj.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@Correo", obj.Correo);
                cmd.Parameters.AddWithValue("@CodigoPostal", obj.CodigoPostal);
                cmd.Parameters.AddWithValue("@Colonia", obj.Colonia);
                cmd.Parameters.AddWithValue("@Calle", obj.Calle);
                cmd.Parameters.AddWithValue("@NumeroExterior", obj.NumeroExterior);
                cmd.Parameters.AddWithValue("@NumeroInterior", obj.NumeroInterior);
                cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                cmd.Parameters.AddWithValue("@Municipio", obj.Municipio);
                cmd.Parameters.AddWithValue("@RegimenFiscal", obj.RegimenFiscal);

                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public List<Padre> ObtenerPadres()
        {
            List<Padre> listaPadres = new List<Padre>();

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT rfc_padre, nombre_padre, ap_padre, am_padre, correo_padre, cp_padre, " +
                               "colonia_padre, calle_padre, no_ext_padre, no_int_padre, estado_padre, " +
                               "municipio_padre, regimen_fiscal_padre FROM Padres ORDER BY rfc_padre ASC"; // Ordenar por RFC
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Padre padre = new Padre
                        {
                            RFC = dr["rfc_padre"].ToString(),
                            Nombre = dr["nombre_padre"].ToString(),
                            ApellidoPaterno = dr["ap_padre"].ToString(),
                            ApellidoMaterno = dr["am_padre"].ToString(),
                            Correo = dr["correo_padre"].ToString(),
                            CodigoPostal = dr["cp_padre"].ToString(),
                            Colonia = dr["colonia_padre"].ToString(),
                            Calle = dr["calle_padre"].ToString(),
                            NumeroExterior = dr["no_ext_padre"].ToString(),
                            NumeroInterior = dr["no_int_padre"].ToString(),
                            Estado = dr["estado_padre"].ToString(),
                            Municipio = dr["municipio_padre"].ToString(),
                            RegimenFiscal = dr["regimen_fiscal_padre"].ToString()
                        };
                        listaPadres.Add(padre);
                    }
                }
            }
            return listaPadres;
        }

        public List<Padre> ObtenerPadreRFC(string rfc)
        {
            List<Padre> listaPadres = new List<Padre>();

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT rfc_padre, nombre_padre, ap_padre, am_padre, correo_padre, cp_padre, " +
                               "colonia_padre, calle_padre, no_ext_padre, no_int_padre, estado_padre, " +
                               "municipio_padre, regimen_fiscal_padre " +
                               "FROM Padres WHERE rfc_padre = @RFC";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    // Asignar el valor del parámetro @RFC
                    cmd.Parameters.AddWithValue("@RFC", rfc);

                    // Ejecutar el lector de datos
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Padre padre = new Padre
                            {
                                RFC = dr["rfc_padre"].ToString(),
                                Nombre = dr["nombre_padre"].ToString(),
                                ApellidoPaterno = dr["ap_padre"].ToString(),
                                ApellidoMaterno = dr["am_padre"].ToString(),
                                Correo = dr["correo_padre"].ToString(),
                                CodigoPostal = dr["cp_padre"].ToString(),
                                Colonia = dr["colonia_padre"].ToString(),
                                Calle = dr["calle_padre"].ToString(),
                                NumeroExterior = dr["no_ext_padre"].ToString(),
                                NumeroInterior = dr["no_int_padre"].ToString(),
                                Estado = dr["estado_padre"].ToString(),
                                Municipio = dr["municipio_padre"].ToString(),
                                RegimenFiscal = dr["regimen_fiscal_padre"].ToString()
                            };
                            listaPadres.Add(padre);
                        }
                    }
                }
            }
            return listaPadres;
        }



        public bool ExisteRFC(string rfc)
        {
            bool existe = false;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT COUNT(1) FROM Padres WHERE rfc_padre = @RFC";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RFC", rfc);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        existe = true;
                    }
                }
            }

            return existe;
        }

        public bool Eliminar(string rfc)
        {
            bool respuesta = true;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "DELETE FROM Padres WHERE rfc_padre = @RFC";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@RFC", rfc);

                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false; // No se eliminó ningún registro
                }
            }

            return respuesta;
        }


        public bool Actualizar(Padre obj)
        {
            bool respuesta = true;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "UPDATE Padres SET nombre_padre = @Nombre, ap_padre = @ApellidoPaterno, " +
                               "am_padre = @ApellidoMaterno, correo_padre = @Correo, cp_padre = @CodigoPostal, " +
                               "colonia_padre = @Colonia, calle_padre = @Calle, no_ext_padre = @NumeroExterior, " +
                               "no_int_padre = @NumeroInterior, estado_padre = @Estado, municipio_padre = @Municipio, " +
                               "regimen_fiscal_padre = @RegimenFiscal " +
                               "WHERE rfc_padre = @RFC";
                SQLiteCommand cmd = new SQLiteCommand(query, con);

                // Asignar valores a los parámetros
                cmd.Parameters.AddWithValue("@RFC", obj.RFC);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", obj.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", obj.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@Correo", obj.Correo);
                cmd.Parameters.AddWithValue("@CodigoPostal", obj.CodigoPostal);
                cmd.Parameters.AddWithValue("@Colonia", obj.Colonia);
                cmd.Parameters.AddWithValue("@Calle", obj.Calle);
                cmd.Parameters.AddWithValue("@NumeroExterior", obj.NumeroExterior);
                cmd.Parameters.AddWithValue("@NumeroInterior", obj.NumeroInterior);
                cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                cmd.Parameters.AddWithValue("@Municipio", obj.Municipio);
                cmd.Parameters.AddWithValue("@RegimenFiscal", obj.RegimenFiscal);

                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false; // No se actualizó ningún registro
                }
            }

            return respuesta;
        }






    }
}
