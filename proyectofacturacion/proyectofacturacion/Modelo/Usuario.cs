using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectofacturacion.Modelo
{
    public class Usuario
    {
        public string RFC { get; set; }  // rfc_usuario
        public string Cuenta { get; set; }  // cuenta_usuario
        public string Contrasena { get; set; }  // contrasena_usuario
        public string Rol { get; set; }  // rol_usuario
        public string Nombre { get; set; }  // nombre_usuario
        public string ApellidoPaterno { get; set; }  // ap_usuario
        public string ApellidoMaterno { get; set; }  // am_usuario
        public string Correo { get; set; }  // correo_usuario
        public string CodigoPostal { get; set; }  // cp_usuario
        public string Colonia { get; set; }  // colonia_usuario
        public string Calle { get; set; }  // calle_usuario
        public string NumeroExterior { get; set; }  // no_ext_usuario
        public string NumeroInterior { get; set; }  // no_int_usuario
        public string Estado { get; set; }  // estado_usuario
        public string Municipio { get; set; }  // municipio_usuario
        public string RegimenFiscal { get; set; }  // regimen_fiscal_usuario
    }
}

