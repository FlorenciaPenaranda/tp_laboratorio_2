using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Recibe operador del tipo string y lo valida.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Retorna el operador si es valido.</returns>
        private static string ValidarOperador(string operador)
        {

            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else
            { return "+"; }
        }
        /// <summary>
        /// Recibe dos objetos del tipo Numero y un operador del tipo string y realiza la operacion de los atributos.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns> Retorna el resultado de la operacion o MinValue si no puede operar</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double ret = 0;

            switch (ValidarOperador(operador))
            {
                    case "+":
                        ret = num1 + num2;
                        break;                    
                    case "-":
                        ret = num1 - num2;
                        break;
                    case "*":
                        ret = num1 * num2;
                        break;
                    case "/":
                        ret = num1 / num2;
                        break;
            }
            return ret;
        }

    }
}
