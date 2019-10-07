using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {

        #region "Constructores"

        public Dulce(EMarca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque)
            : base(marca, codigoDeBarras, colorPrimarioEmpaque)
        {

        }

        #endregion

        #region "Propiedades"
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected new short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        #endregion

        #region "Métodos"
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
