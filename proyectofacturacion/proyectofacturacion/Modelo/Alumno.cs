using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectofacturacion.Modelo
{
    public class Alumno
    {
        public string CURP {  get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NivelEducativo { get; set; }
        public string Grupo { get; set; }
        public string Grado { get; set; }
        public string RFC_Padre { get; set; }
    }
}
