using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        //private const string mensajeError = "Error con el archivo";
        public ArchivosException(Exception innerException)
             : base("Error con el archivo", innerException)
        {

        }
    }
}
