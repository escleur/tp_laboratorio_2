using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;


        #region Constructores
        public Universitario()
            : this(0, "", "", "", ENacionalidad.Argentino)
        {

        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        /// <summary>
        /// Son iguales si son del mismo tipo y su legajo o dni es el mismo
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Operador !=
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Son iguales si son del mismo tipo y su legajo o dni es el mismo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType() && (this.legajo == ((Universitario)obj).legajo || this.DNI == ((Universitario)obj).DNI);
        }

        protected abstract string ParticiparEnClase();
        
        /// <summary>
        /// Muestra datos de universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");
            sb.AppendLine($"LEGAJO NUMERO: {this.legajo}");
            return sb.ToString();


        }
    }
}
