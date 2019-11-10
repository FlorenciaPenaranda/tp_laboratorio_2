using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
       // private const string mensajeError = "La nacionalidad no se condice con el número DNI";

        public NacionalidadInvalidaException()
            : this("La nacionalidad no se condice con el número DNI")
        {

        }

        public NacionalidadInvalidaException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
