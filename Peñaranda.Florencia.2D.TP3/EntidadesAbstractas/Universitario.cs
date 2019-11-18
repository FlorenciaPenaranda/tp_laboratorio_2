using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos

        private int legajo;

        #endregion


        #region Constructores

        /// <summary>
        /// Constructor por defecto que hereda de persona e inicializa un obejto del tipo universitario
        /// </summary>
        public Universitario()
            : base()
        {
        }


        /// <summary>
        /// Hereda el constructor base e inicializa un universitario agregando el atributo legajo
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Sobreescribe el método Equals para saber si un objeto es del tipo universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorna true si el objeto es del tipo universitario, caso contrario retorna false</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                return this == (Universitario)obj;
            }

            return false;
        }


        /// <summary>
        /// Implementa sin sobreescribir el metodo heredado MostrarDatos para mostrar todos los datos de un universitario 
        /// </summary>
        /// <returns>Muestra todos los datos de un universitario </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NUMERO: " + this.legajo);
            return sb.ToString();
        }


        /// <summary>
        /// Metodo abstracto sin implementación
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticipaEnClase();

        #endregion


        #region Operadores

        /// <summary>
        /// Reutilizando el metodo Equals y compara un universitario con otro comparando si sus dni son iguales o legajos.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Si son iguales segun criterio devuelve true, caso conrtario devuelve false</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

            if (pg1.Dni == pg2.Dni || pg1.legajo == pg2.legajo)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        ///  Compara un universitario con otro comparando para saber si no son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>Si no son iguales devuelve true, caso conrtario devuelve false</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
