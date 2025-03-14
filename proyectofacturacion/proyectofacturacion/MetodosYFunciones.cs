using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace proyectofacturacion
{
    public class MetodosYFunciones
    {
        //REGEX CODIGO POSTAL
        public bool validoCP(string cp)
        {
            string regexCP = @"^\d{5}$";
            return Regex.IsMatch(cp, regexCP);
        }

        public bool rangoCP(int cp)
        {
            if(cp < 20000 || cp > 99998)
            {
                return false;
            }
            return true;
        }

        //REGEX SOLO LETRAS
        public bool soloLetras(string entrada)
        {
            string regexLetras = @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$";
            return Regex.IsMatch(entrada.Trim(), regexLetras);
        }


        //REGEX SOLO NUMEROS
        public bool soloNumeros(string entrada)
        {
            string regexNumeros = @"^\d+$";
            return Regex.IsMatch(entrada, regexNumeros);
        }

        //REGEX RFC
        public bool ValidarRFC(string rfc)
        {
            string patron = @"^([A-Z]{3,4}\d{6}(?:[A-Z0-9]{3})?)$";
            Regex regex = new Regex(patron);
            return regex.IsMatch(rfc);
        }

        //REGEX CORREO
        public bool ValidarCorreoElectronico(string correo)
        {
            string patron = @"^[^@\s]+@(gmail\.com|outlook\.com|yahoo\.com|hotmail\.com|icloud\.com)$";
            Regex regex = new Regex(patron, RegexOptions.IgnoreCase);
            return regex.IsMatch(correo);
        }

        //GENERAR RFC
        public string GenerarRFC(string nombre, string primerApellido, string segundoApellido, DateTime fechaNacimiento)
        {
            string rfc = ObtenerInicialesConRegex(nombre, primerApellido, segundoApellido);

            // Fecha en formato "AAMMDD"
            rfc += fechaNacimiento.ToString("yyMMdd");

            return rfc.ToUpper();
        }

        // INICIALES PARA EL RFC
        public string ObtenerInicialesConRegex(string nombre, string primerApellido, string segundoApellido)
        {
            nombre = LimpiarTexto(nombre);
            primerApellido = LimpiarTexto(primerApellido);
            segundoApellido = LimpiarTexto(segundoApellido);

            string iniciales = "";

            // Tomar la primera letra y primera vocal interna del primer apellido
            var matchPrimerApellido = Regex.Match(primerApellido, @"^([A-Z])[^AEIOU]*(A|E|I|O|U)", RegexOptions.IgnoreCase);
            if (matchPrimerApellido.Success)
            {
                iniciales += matchPrimerApellido.Groups[1].Value; // Primera letra
                iniciales += matchPrimerApellido.Groups[2].Value; // Primera vocal interna
            }
            else
            {
                // Si no hay vocal interna, agregar la primera letra del apellido y "X"
                iniciales += primerApellido[0] + "X";
            }

            // Tomar la primera letra del segundo apellido o "X" si no tiene
            iniciales += !string.IsNullOrEmpty(segundoApellido) ? segundoApellido[0].ToString() : "X";

            // Tomar la primera letra del primer nombre
            iniciales += nombre.Length > 0 ? nombre[0].ToString() : "X";

            return iniciales;
        }

        // QUITAR ESPACIOS EN BLANCO DEL TEXTO
        private string LimpiarTexto(string texto)
        {
            return Regex.Replace(texto.ToUpper(), @"[^A-Z]", "");
        }


        public string GenerarCURP(string nombre, string primerApellido, string segundoApellido, DateTime fechaNacimiento, string sexo, string estado)
        {
            string curp = ObtenerIniciales(primerApellido, segundoApellido, nombre);

            string fechaFormateada = fechaNacimiento.ToString("yyMMdd");
            curp += fechaFormateada;

            curp += sexo.Equals("H", StringComparison.OrdinalIgnoreCase) ? "H" : "M";
            curp += estado.ToUpper();

            curp += ObtenerConsonantes(primerApellido, segundoApellido, nombre);

            return curp.ToUpper();
        }

        // Obtener iniciales para la CURP
        private string ObtenerIniciales(string primerApellido, string segundoApellido, string nombre)
        {
            primerApellido = LimpiarTexto(primerApellido);
            segundoApellido = LimpiarTexto(segundoApellido);
            nombre = LimpiarTexto(nombre);

            string iniciales = primerApellido[0].ToString();

            var matchVocal = Regex.Match(primerApellido.Substring(1), "[AEIOUaeiou]");
            iniciales += matchVocal.Success ? matchVocal.Value.ToUpper() : "X"; // 'X' si no hay vocal

            iniciales += segundoApellido.Length > 0 ? segundoApellido[0].ToString() : "X"; // 'X' si no tiene segundo apellido

            iniciales += nombre[0];

            return iniciales;
        }

        // Obtener consonantes internas para la CURP
        private string ObtenerConsonantes(string primerApellido, string segundoApellido, string nombre)
        {
            string consonantes = "";

            consonantes += ObtenerPrimeraConsonanteInterna(primerApellido);
            consonantes += ObtenerPrimeraConsonanteInterna(segundoApellido);
            consonantes += ObtenerPrimeraConsonanteInterna(nombre);

            return consonantes;
        }

        // Obtener la primera consonante interna de una palabra
        private string ObtenerPrimeraConsonanteInterna(string texto)
        {
            for (int i = 1; i < texto.Length; i++) // Inicia desde el segundo carácter
            {
                if (Regex.IsMatch(texto[i].ToString(), "[BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyz]"))
                {
                    return texto[i].ToString().ToUpper();
                }
            }
            return "X"; // Si no hay consonantes internas, usa 'X'
        }


        public  bool ValidarCURP(string curp)
        {
            // Expresión regular para validar la estructura de una CURP
            string patron = @"^[A-Z]{4}\d{6}[H|M][A-Z]{5}\d{2}$";

            // Validar usando Regex.Match
            return Regex.IsMatch(curp.ToUpper(), patron);
        }

    }
}
