using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {

        #region "Constructores"
        public Snacks(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {

        }

        #endregion

        #region "Propiedades"
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected new short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        #endregion

        #region "Métodos"
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
