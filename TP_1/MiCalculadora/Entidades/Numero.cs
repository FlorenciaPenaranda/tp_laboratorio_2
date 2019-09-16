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
        /// <summary>
        /// Inicializa un objeto del tipo Numero y valida que sea correcto.
        /// </summary>
        public string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }
        /// <summary>
        /// Inicializa una instancia del tipo Numero con valor "cero".
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Inicializa una instancia del tipo Numero recibiendo un numero de tipo double.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Inicializa una instancia del tipo Numero recibiendo un string validando que sea un valor correcto.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }
        #endregion


        #region Operadores
        /// <summary>
        /// Metodo estático de sobrecarga del operador + que suma dos atributos entre dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la suma de los atributos</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// Metodo estático de sobrecarga del operador - que resta dos atributos entre dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la resta de los atributos</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Metodo estático de sobrecarga del operador * que multiplica dos atributos entre dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la multiplicacion de los atributos</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Metodo estático de sobrecarga del operador / que divide dos atributos entre dos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>Retorna el resultado de la divison de los atributos, si el segundo es 0 retorna MinValue </returns>
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
        /// <summary>
        /// Convierte un dato del tipo string a un string en decimal.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorna el resultado si logra hacer la conversion, de lo contrario, retorna "Valor Invalido".</returns>
        public string BinarioDecimal(string strNumero)
        {
            string ret = "Valor invalido";
            if (double.TryParse(strNumero, out double doble) && int.Parse(strNumero) > 0)
            {
                return Convert.ToString(Convert.ToInt64(strNumero, 2));

            }
            else { return ret; }            
        }
        /// <summary>
        /// Convierte un dato del tipo string a un string en binario.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorna el resultado si logra hacer la conversion, de lo contrario, retorna "Valor Invalido".</returns>
        public string DecimalBinario(string strNumero)
        {
            string ret = "Valor invalido";
            if (double.TryParse(strNumero, out double doble) && int.Parse(strNumero) > 0)
            {

                return Convert.ToString(Convert.ToByte(strNumero), 2);
            }
            else { return ret; }
        }
        /// <summary>
        /// Convierte un dato del tipo double a un string en binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna el resultado de la conversion</returns>
        public string DecimalBinario(double numero)
        {
            return Convert.ToString(Convert.ToByte(numero), 2);
        }
        #endregion

        /// <summary>
        /// Metodo de la clase que valida que un dato del tipo string se puede convertir en un dato del tipo double.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorna el resultado si sale bien,de lo contrario, retorna  0</returns>
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
