using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectofacturacion.Modelo
{
    public class Factura
    {
        public string NoFactura { get; set; }   
        public float SubTotal { get; set; }
        public float Total { get; set; }    
        public string RFCPadre { get; set; }
        public string RFCUsuario { get; set; }
        public string Descripcion { get; set; }
        public string UsoCFDI { get; set; }
        public string MetodoPago { get; set; }
        public string FormaPago { get; set; }
        public string ConceptoFactura { get; set; }
        public string Hora {  get; set; }
        public string Dia { get; set; }
        public string Mes {  get; set; }
        public string Anio { get; set; }


    }
}
