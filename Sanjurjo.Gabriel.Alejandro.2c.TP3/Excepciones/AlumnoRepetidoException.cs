using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mensaje"></param>
        public AlumnoRepetidoException(string mensaje) : this(mensaje, null)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public AlumnoRepetidoException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {

        }
    }
}
