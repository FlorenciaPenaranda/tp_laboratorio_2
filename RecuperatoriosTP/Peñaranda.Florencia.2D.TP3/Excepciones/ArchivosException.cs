using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        ///  Usa al constructor de la clase base que resibe una excepcion para mostrar un mensaje de error
        /// </summary>
        /// <param name="innerException">Excepcion recibida</param>
        public ArchivosException(Exception innerException)
             : base("Error con el archivo", innerException)
        {

        }
    }
}
