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

        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Parsea un string que contiene un numero binario a decimal
        /// </summary>
        /// <param name="binario">String con la cadena correspondiente a un numero binario</param>
        /// <returns>retorna un numero decimal en formato string o el menaje "No binario" si no es un numero binario </returns>
        public string BinarioDecimal(string binario)
        {
            double dec = 0;
            bool chequeo = true;
            foreach  (char caracter in binario)
            {
                if(caracter != '0' && caracter != '1' && caracter != '-' && caracter != '.' && caracter != ',')
                {
                    chequeo = false;
                }
            }
            if (chequeo)
            {

                int punto = binario.IndexOf('.');


                string binarioFraccion = (punto != -1) ? binario.Substring(punto + 1) : "";

                int signo = (binario.IndexOf('-') != -1) ? -1 : 1;
                if (punto == -1)
                    punto = binario.Length;

                //Calcula la parte entera del numero
                for (int i = 0; i < punto; i++)
                {
                    if (binario[punto - i - 1] == '1')
                    {
                        dec += Math.Pow(2, i);
                    }
                }

                //Calcula la parte fraccionaria del numero
                for (int i = 0; i < binarioFraccion.Length; i++)
                {
                    if (binarioFraccion[i] == '1')
                    {
                        dec += Math.Pow(2, -i - 1);
                    }

                }

                dec *= signo;
            }
            else
            {
                return "No binario";
            }
            return dec.ToString();

        }

        /// <summary>
        /// Convierte un numero double a una cadena con el numero binario correspondiente 
        /// </summary>
        /// <param name="binario">Double correspondiente a un numero decimal</param>
        /// <returns>retorna un numero binario en formato string </returns>
        public string DecimalBinario(double numero)
        {
            int signo = (numero >= 0) ? 1 : -1;
            int parteEntera = Math.Abs((int)numero);
            double parteDecimal = Math.Abs(numero) - parteEntera;

            string binario = "";

            //Calculo la parte entera del binario con divisiones por 2
            while (parteEntera > 0)
            {
                binario = ((parteEntera % 2 == 1) ? "1" : "0") + binario;
                parteEntera /= 2;
            }

            //Pongo el signo menos si corresponde
            binario = ((signo < 0) ? "-" : "") + binario;

            string binarioFraccion = (parteDecimal == 0) ? "" : ".";
            int presicion = 20;

            //Calculo la parte fraccional con multiplicaciones por 2
            while (parteDecimal != 0 && presicion != 0)
            {
                parteDecimal *= 2;
                binarioFraccion += ((parteDecimal >= 1) ? "1" : "0");
                parteDecimal = parteDecimal - (int)parteDecimal;
                presicion--;
            }

            binario += binarioFraccion;

            return binario;
        }

        /// <summary>
        /// Parsea un numero en string a una cadena con el numero binario correspondiente 
        /// </summary>
        /// <param name="binario">String correspondiente a un numero decimal</param>
        /// <returns>retorna un numero binario en formato string </returns>
        public string DecimalBinario(string numero)
        {
            double salida;
            if (!double.TryParse(numero, out salida))
            {
                salida = 0;
            }
            return DecimalBinario(salida);
        }

        /// <summary>
        /// Constructor de numero
        /// </summary>
        public Numero()
        {
            numero = 0.0;
        }

        /// <summary>
        /// Constructor de numero
        /// </summary>
        /// <param name="numero">Valor del atributo numero</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor de numero
        /// </summary>
        /// <param name="strNumero">Valor del numero en string</param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// Realiza una resta entre dos clases numero
        /// </summary>
        /// <param name="n1">Valor del primer numero</param>
        /// <param name="n2">Valor del segundo numero</param>
        /// <returns>Retorna un double con el valor de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza una multiplicacion entre dos clases numero
        /// </summary>
        /// <param name="n1">Valor del primer numero</param>
        /// <param name="n2">Valor del segundo numero</param>
        /// <returns>Retorna un double con el valor de la multiplicacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza una divicion entre dos clases numero
        /// </summary>
        /// <param name="n1">Valor del primer numero</param>
        /// <param name="n2">Valor del segundo numero</param>
        /// <returns>Retorna un double con el valor de la divicion, si n2 == 0 retorna double.MinValue</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double salida;
            if (n2.numero == 0)
                salida = double.MinValue;
            else
                salida = n1.numero / n2.numero;
            return salida;
        }

        /// <summary>
        /// Realiza una suma entre dos clases numero
        /// </summary>
        /// <param name="n1">Valor del primer numero</param>
        /// <param name="n2">Valor del segundo numero</param>
        /// <returns>Retorna un double con el valor de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Parsea el string a double
        /// </summary>
        /// <param name="strNumero">string del numero a parsear</param>
        /// <returns>si no se puede parsear devuelve 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double salida;
            if(!double.TryParse(strNumero, out salida))
            {
                salida = 0;
            }
            return salida;
        }
    }
}
