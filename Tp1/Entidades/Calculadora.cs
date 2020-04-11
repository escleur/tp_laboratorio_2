using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    static public class Calculadora
    {
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
