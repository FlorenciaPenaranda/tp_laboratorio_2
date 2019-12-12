using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Usa el constructor base para mostrar un mensaje de error
        /// </summary>
        public NacionalidadInvalidaException()
            : base("La nacionalidad no se condice con el número DNI")
        {

        }


        /// <summary>
        /// Usa el constructor base que recibe un string para mostrar un mensaje de error
        /// </summary>
        /// <param name="mensaje">Mnsaje de error</param>
        public NacionalidadInvalidaException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
