using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using proyectofacturacion.Modelo;


namespace proyectofacturacion.Logica
{
    public class AlumnoLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static AlumnoLogica _instancia = null;

        public AlumnoLogica() { }

        public static AlumnoLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new AlumnoLogica();
                }
                return _instancia;
            }

        }
        public bool Guardar(Alumno obj)
        {
            bool respuesta = true;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "INSERT INTO Alumnos (curp_alumno, nombre_alumno, " +
                               "ap_alumno, am_alumno, nivel_educativo_alumno, grupo_alumno, grado_alumno, rfc_padre) " +
                               "VALUES (@CURP, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @NivelEducativo, @Grupo, @Grado, @RFC_Padre)";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@CURP", obj.CURP);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", obj.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", obj.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@NivelEducativo", obj.NivelEducativo);
                cmd.Parameters.AddWithValue("@Grupo", obj.Grupo);
                cmd.Parameters.AddWithValue("@Grado", obj.Grado);
                cmd.Parameters.AddWithValue("@RFC_Padre", obj.RFC_Padre);
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }
        public List<Alumno> ObtenerAlumnos()
        {
            List<Alumno> listaAlumnos = new List<Alumno>();

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT curp_alumno, nombre_alumno, ap_alumno, am_alumno, nivel_educativo_alumno, " +
                               "grupo_alumno, grado_alumno, rfc_padre FROM Alumnos ORDER BY curp_alumno ASC"; // Ordenar por RFC_Padre
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Alumno alumno = new Alumno
                        {
                            CURP = dr["curp_alumno"].ToString(),
                            Nombre = dr["nombre_alumno"].ToString(),
                            ApellidoPaterno = dr["ap_alumno"].ToString(),
                            ApellidoMaterno = dr["am_alumno"].ToString(),
                            NivelEducativo = dr["nivel_educativo_alumno"].ToString(),
                            Grupo = dr["grupo_alumno"].ToString(),
                            Grado = dr["grado_alumno"].ToString(),
                            RFC_Padre = dr["rfc_padre"].ToString()
                        };
                        listaAlumnos.Add(alumno);
                    }
                }
            }
            return listaAlumnos;
        }


        public List<Alumno> ObtenerAlumnoCURP(string curp)
        {
            List<Alumno> listaAlumnos = new List<Alumno>();

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT curp_alumno, nombre_alumno, ap_alumno, am_alumno, nivel_educativo_alumno, " +
                               "grupo_alumno, grado_alumno, rfc_padre FROM Alumnos WHERE curp_alumno = @CURP";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    // Asignar el valor del parámetro @CURP
                    cmd.Parameters.AddWithValue("@CURP", curp);

                    // Ejecutar el lector de datos
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Alumno alumno = new Alumno
                            {
                                CURP = dr["curp_alumno"].ToString(),
                                Nombre = dr["nombre_alumno"].ToString(),
                                ApellidoPaterno = dr["ap_alumno"].ToString(),
                                ApellidoMaterno = dr["am_alumno"].ToString(),
                                NivelEducativo = dr["nivel_educativo_alumno"].ToString(),
                                Grupo = dr["grupo_alumno"].ToString(),
                                Grado = dr["grado_alumno"].ToString(),
                                RFC_Padre = dr["rfc_padre"].ToString()
                            };
                            listaAlumnos.Add(alumno);
                        }
                    }
                }
            }
            return listaAlumnos;
        }

        public bool Actualizar(Alumno obj)
        {
            bool respuesta = true;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "UPDATE Alumnos SET nombre_alumno = @Nombre, ap_alumno = @ApellidoPaterno, " +
                               "am_alumno = @ApellidoMaterno, nivel_educativo_alumno = @NivelEducativo, " +
                               "grupo_alumno = @Grupo, grado_alumno = @Grado, rfc_padre = @RFC_Padre " +
                               "WHERE curp_alumno = @CURP";
                SQLiteCommand cmd = new SQLiteCommand(query, con);

                // Asignar valores a los parámetros
                cmd.Parameters.AddWithValue("@CURP", obj.CURP);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", obj.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", obj.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@NivelEducativo", obj.NivelEducativo);
                cmd.Parameters.AddWithValue("@Grupo", obj.Grupo);
                cmd.Parameters.AddWithValue("@Grado", obj.Grado);
                cmd.Parameters.AddWithValue("@RFC_Padre", obj.RFC_Padre);

                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false; 
                }
            }

            return respuesta;
        }

        public bool Eliminar(string curp)
        {
            bool respuesta = true;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "DELETE FROM Alumnos WHERE curp_alumno = @CURP";
                SQLiteCommand cmd = new SQLiteCommand(query, con);

                // Asignar valor al parámetro
                cmd.Parameters.AddWithValue("@CURP", curp);
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false; // No se eliminó ningún registro
                }
            }

            return respuesta;
        }

        public bool EliminarRFCPadre(string rfc)
        {
            bool respuesta = true;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "DELETE FROM Alumnos WHERE rfc_padre = @RFC_Padre";
                SQLiteCommand cmd = new SQLiteCommand(query, con);

                // Asignar valor al parámetro
                cmd.Parameters.AddWithValue("@RFC_Padre", rfc);
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false; // No se eliminó ningún registro
                }
            }

            return respuesta;
        }

        public bool CURPExiste(string curp)
        {
            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Alumnos WHERE curp_alumno = @CURP";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@CURP", curp);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public List<string> ObtenerCurpsPorRFCPadre(string rfc)
        {
            List<string> listaCurps = new List<string>();

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT curp_alumno FROM Alumnos WHERE rfc_padre = @RFCPadre";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RFCPadre", rfc);

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaCurps.Add(dr["curp_alumno"].ToString());
                        }
                    }
                }
            }
            return listaCurps;
        }



    }

}
