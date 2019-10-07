using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;
        public enum EMarca
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }

        #region "Construtores"
        public Producto(EMarca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque)
        {

            this.marca = marca;
            this.codigoDeBarras = codigoDeBarras;
            this.colorPrimarioEmpaque = colorPrimarioEmpaque;
        }

        #endregion

        #region "Propiedades"

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected virtual short CantidadCalorias
        {
            get;
        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>devuelve un string con los datos del producto</returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: " + this.codigoDeBarras);
            sb.AppendLine("MARCA          : " + this.marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : " + this.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

        #region "Operadores"

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Devuelve true si los productos son iguales </returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Devuelve true si los productos son distintos </returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1.codigoDeBarras == v2.codigoDeBarras);
        }

        /// <summary>
        /// Sobrecarga el operador devolviendo los datos del producto.
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Producto p)
        {
            return p.Mostrar();
        }

        #endregion        

    }
}
