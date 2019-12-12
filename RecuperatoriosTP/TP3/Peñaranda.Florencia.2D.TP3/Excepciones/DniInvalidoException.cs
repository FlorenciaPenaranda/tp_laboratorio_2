using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Usa el constructor base para mostrar un mensaje de error
        /// </summary>
        public DniInvalidoException()
            : base("DNI inválido")
        {

        }

        /// <summary>
        /// Usa al constructor de la clase base que resibe una excepcion para mostrar un mensaje de error
        /// </summary>
        /// <param name="e">Excepcion recibida</param>
        public DniInvalidoException(Exception e)
            : base("DNI inválido", e)
        {

        }

        /// <summary>
        /// Usa el constructor base qe recibe un string para mostrar un mensaje de error
        /// </summary>
        /// <param name="mensaje">Mensaje de error</param>
        public DniInvalidoException(string mensaje)
            : base("DNI inválido")
        {

        }

        /// <summary>
        /// Usa al constructor de la clase base que resibe una excepcion y un string para mostrar un mensaje de error
        /// </summary>
        /// <param name="mensaje">Mensaje de error</param>
        /// <param name="e">Excepcion recibida</param>
        public DniInvalidoException(string mensaje, Exception e)
            : base("DNI inválido", e)
        {

        }

    }
}
