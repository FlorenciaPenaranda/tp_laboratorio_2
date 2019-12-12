using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Excepción que se lanza en el caso que un TrackingID se encuentre repetido.
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIdRepetidoException(string mensaje)
            :base(mensaje)
        {
        }

        public TrackingIdRepetidoException(string mensaje, Exception innerException)
            : base(mensaje)
        {

        }
    }
}
