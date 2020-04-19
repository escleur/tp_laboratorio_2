using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    static public class Calculadora
    {
        /// <summary>
        /// Realiza las operaciones matematicas entre los dos numeros
        /// </summary>
        /// <param name="num1">primer numero</param>
        /// <param name="num2">segundo numero</param>
        /// <param name="operador">operando matematico </param>
        /// <returns>retorna el resultado de la operacion, si el operando no es reconocido retorna 0</returns>
        static public double Operar(Numero num1, Numero num2, string operador)
        {
            double salida = 0;
            switch (ValidarOperador(operador))
            {
                case "-":
                    salida = num1 - num2;
                    break;
                case "*":
                    salida = num1 * num2;
                    break;
                case "/":
                    salida = num1 / num2;
                    break;
                case "+":
                    salida = num1 + num2;
                    break;
            }
            return salida;
        }

        /// <summary>
        /// Valida el operador
        /// </summary>
        /// <param name="operador">un string con un operador</param>
        /// <returns>retorna + si el operador no es reconocido</returns>
        static private string ValidarOperador(string operador)
        {
            string retorno = operador;
            if (retorno != "-" && retorno != "*" && retorno != "/")
            {
                retorno = "+";
            }
            return retorno;
        }
    }
}
