using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {

        private const string mensajeError = "DNI inválido";
        public DniInvalidoException()
            : base(mensajeError)
        {

        }
        public DniInvalidoException(Exception e)
            : base(mensajeError, e)
        {

        }
        public DniInvalidoException(string mensaje)
            : base(mensaje)
        {

        }
        public DniInvalidoException(string mensaje, Exception e)
            : base(mensaje, e)
        {

        }

    }
}
