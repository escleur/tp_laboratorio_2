using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Excepcion que se lanza cuando el paquete esta repetido
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIdRepetidoException(string mensaje)
            : this(mensaje, null)
        {

        }

        /// <summary>
        /// Excepcion que se lanza cuando el paquete esta repetido
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="inner"></param>
        public TrackingIdRepetidoException(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }

    }
}
