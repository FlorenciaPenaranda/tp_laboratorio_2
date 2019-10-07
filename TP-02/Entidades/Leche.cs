using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        private ETipo tipo;
        public enum ETipo
        {
            Entera,
            Descremada
        }

        #region "Constructores"
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {

        }
        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo)
            : base(marca, patente, color)
        {
            this.tipo = ETipo.Entera;
        }

        #endregion

        #region "Propiedades"
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected new short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        #endregion

        #region "Métodos"
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
