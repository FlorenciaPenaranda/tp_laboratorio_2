using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructores
        public string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }

        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }
        #endregion


        #region Operadores
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
        #endregion


        #region conversores
        public string BinarioDecimal(string strNumero)
        {
            string ret = "Valor invalido";
            if (double.TryParse(strNumero, out double doble) && int.Parse(strNumero) > 0)
            {
                return Convert.ToString(Convert.ToInt64(strNumero, 2));

            }
            else { return ret; }            
        }

        public string DecimalBinario(string strNumero)
        {
            string ret = "Valor invalido";
            if (double.TryParse(strNumero, out double doble) && int.Parse(strNumero) > 0)
            {

                return Convert.ToString(Convert.ToByte(strNumero), 2);
            }
            else { return ret; }
        }

        public string DecimalBinario(double numero)
        {
            return Convert.ToString(Convert.ToByte(numero), 2);
        }
        #endregion


        private double ValidarNumero(string strNumero)
        {
            double ret;
            if (double.TryParse(strNumero, out ret))
            {
                return ret;
            }
            else { return 0; }
        }

    }
}
