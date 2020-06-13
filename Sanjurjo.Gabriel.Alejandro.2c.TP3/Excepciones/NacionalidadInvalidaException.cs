using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException(string mensaje) : this(mensaje, null)
        {

        }
        public NacionalidadInvalidaException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {

        }
    }
}
