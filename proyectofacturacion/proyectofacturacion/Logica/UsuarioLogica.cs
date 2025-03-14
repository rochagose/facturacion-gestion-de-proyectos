
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using proyectofacturacion.Modelo;
using System.Data.SQLite;

namespace proyectofacturacion.Logica
{
    public class UsuarioLogica
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        private static UsuarioLogica _instancia = null;

        public UsuarioLogica() { }  

        public static UsuarioLogica Instancia{
            get{
                if(_instancia == null)
                {
                    _instancia = new UsuarioLogica();
                }
                return _instancia;
            }
            
        }

        public bool Guardar(Usuario obj)
        {
            bool respuesta = true;

            using (SQLiteConnection con = new SQLiteConnection(cadena)) {
                con.Open();
                string query = "INSERT INTO Usuarios (rfc_usuario, cuenta_usuario, contrasena_usuario, rol_usuario, nombre_usuario, " +
                               "ap_usuario, am_usuario, correo_usuario, cp_usuario, colonia_usuario, calle_usuario, no_ext_usuario, " +
                               "no_int_usuario, estado_usuario, municipio_usuario, regimen_fiscal_usuario) " +
                               "VALUES (@RFC, @Cuenta, @Contrasena, @Rol, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Correo, " +
                               "@CodigoPostal, @Colonia, @Calle, @NumeroExterior, @NumeroInterior, @Estado, @Municipio, @RegimenFiscal)";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.Parameters.AddWithValue("@RFC", obj.RFC);
                cmd.Parameters.AddWithValue("@Cuenta", obj.Cuenta);
                cmd.Parameters.AddWithValue("@Contrasena", obj.Contrasena);
                cmd.Parameters.AddWithValue("@Rol", obj.Rol);
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

                if(cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool UsuariosRegistrados()
        {
            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Usuarios";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count >= 1;
                }
            }
        }

        public bool RFCExiste(string rfc)
        {
            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Usuarios WHERE rfc_usuario = @RFC";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    // Agregar el parámetro para el RFC
                    cmd.Parameters.AddWithValue("@RFC", rfc);

                    // Ejecutar la consulta y convertir el resultado a entero
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // Retornar true si hay al menos un resultado
                    return count > 0;
                }
            }
        }

        public bool RolExiste(string rol)
        {
            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM Usuarios WHERE rol_usuario = @Rol";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    // Agregar el parámetro para el rol
                    cmd.Parameters.AddWithValue("@Rol", rol);

                    // Ejecutar la consulta y convertir el resultado a entero
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // Retornar true si hay al menos un resultado
                    return count > 0;
                }
            }
        }




        public bool LogearUsuario(Usuario obj, string rolseleccionado)
        {
            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT rol_usuario FROM Usuarios WHERE cuenta_usuario = @Cuenta AND contrasena_usuario = @Contrasena";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Cuenta", obj.Cuenta);
                    cmd.Parameters.AddWithValue("@Contrasena", obj.Contrasena);
                    var resultadorol = cmd.ExecuteScalar();
                    
                    if(resultadorol != null)
                    {
                        string result = resultadorol.ToString();
                        return result == rolseleccionado;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            
        }

        public string ObtenerNombreUsuario(string cuenta)
        {
            string nombreCompleto = string.Empty;
            using (SQLiteConnection con =new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT nombre_usuario, ap_usuario, am_usuario FROM Usuarios WHERE cuenta_usuario = @Cuenta";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Cuenta", cuenta);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nombre = reader["nombre_usuario"].ToString();
                            string apellidoPaterno = reader["ap_usuario"].ToString();
                            string apellidoMaterno = reader["am_usuario"].ToString();

                            nombreCompleto = $"{nombre} {apellidoPaterno} {apellidoMaterno}";
                        }
                    }
                }
            }
            return nombreCompleto;
        }

        public string ObtenerRFC(string cuenta)
        {
            string rfc = string.Empty;
            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT rfc_usuario FROM Usuarios WHERE cuenta_usuario = @Cuenta";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Cuenta", cuenta);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rfc = reader["rfc_usuario"].ToString();
                        }
                    }
                }
            }
            return rfc;
        }

        public string ObtenerRegimen(string cuenta)
        {
            string regimen = string.Empty;
            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT regimen_fiscal_usuario FROM Usuarios WHERE cuenta_usuario = @Cuenta";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Cuenta", cuenta);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            regimen = reader["regimen_fiscal_usuario"].ToString();
                        }
                    }
                }
            }
            return regimen;
        }

        public string ObtenerCP(string cuenta)
        {
            string cp = string.Empty;
            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT cp_usuario FROM Usuarios WHERE cuenta_usuario = @Cuenta";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Cuenta", cuenta);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cp = reader["cp_usuario"].ToString();
                        }
                    }
                }
            }
            return cp;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "SELECT rfc_usuario, cuenta_usuario, rol_usuario, nombre_usuario, " +
                               "ap_usuario, am_usuario, correo_usuario, cp_usuario, colonia_usuario, calle_usuario, " +
                               "no_ext_usuario, no_int_usuario, estado_usuario, municipio_usuario, regimen_fiscal_usuario " +
                               "FROM Usuarios";
                SQLiteCommand cmd = new SQLiteCommand(query, con);

                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Usuario sesion = new Usuario
                        {
                            RFC = dr["rfc_usuario"].ToString(),
                            Cuenta = dr["cuenta_usuario"].ToString(),
                            Rol = dr["rol_usuario"].ToString(),
                            Nombre = dr["nombre_usuario"].ToString(),
                            ApellidoPaterno = dr["ap_usuario"].ToString(),
                            ApellidoMaterno = dr["am_usuario"].ToString(),
                            Correo = dr["correo_usuario"].ToString(),
                            CodigoPostal = dr["cp_usuario"].ToString(),
                            Colonia = dr["colonia_usuario"].ToString(),
                            Calle = dr["calle_usuario"].ToString(),
                            NumeroExterior = dr["no_ext_usuario"].ToString(),
                            NumeroInterior = dr["no_int_usuario"].ToString(),
                            Estado = dr["estado_usuario"].ToString(),
                            Municipio = dr["municipio_usuario"].ToString(),
                            RegimenFiscal = dr["regimen_fiscal_usuario"].ToString()
                        };
                        listaUsuarios.Add(sesion);
                    }
                }
            }
            return listaUsuarios;
        }

        public bool Actualizar(Usuario obj)
        {
            bool respuesta = true;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "UPDATE Usuarios SET cuenta_usuario = @Cuenta, contrasena_usuario = @Contrasena, rol_usuario = @Rol, " +
                               "nombre_usuario = @Nombre, ap_usuario = @ApellidoPaterno, am_usuario = @ApellidoMaterno, " +
                               "correo_usuario = @Correo, cp_usuario = @CodigoPostal, colonia_usuario = @Colonia, calle_usuario = @Calle, " +
                               "no_ext_usuario = @NumeroExterior, no_int_usuario = @NumeroInterior, estado_usuario = @Estado, " +
                               "municipio_usuario = @Municipio, regimen_fiscal_usuario = @RegimenFiscal " +
                               "WHERE rfc_usuario = @RFC";
                SQLiteCommand cmd = new SQLiteCommand(query, con);

                // Asignar valores a los parámetros
                cmd.Parameters.AddWithValue("@RFC", obj.RFC);
                cmd.Parameters.AddWithValue("@Cuenta", obj.Cuenta);
                cmd.Parameters.AddWithValue("@Contrasena", obj.Contrasena);
                cmd.Parameters.AddWithValue("@Rol", obj.Rol);
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


        public bool Eliminar(string rfc)
        {
            bool respuesta = true;

            using (SQLiteConnection con = new SQLiteConnection(cadena))
            {
                con.Open();
                string query = "DELETE FROM Usuarios WHERE rfc_usuario = @RFC";
                SQLiteCommand cmd = new SQLiteCommand(query, con);

                // Asignar valor al parámetro
                cmd.Parameters.AddWithValue("@RFC", rfc);
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false; // No se eliminó ningún registro
                }
            }

            return respuesta;
        }



    }
}
