using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Entidades;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        public enum ENacionalidad { Argentino, Extranjero}

        #region Propiedadas
        /// <summary>
        /// Propiedad Apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad Nacionalidad (Argentino o Extranjero)
        ///         Argentinos entre 0 y 89999999
        ///  Extranjero entre 90000000 y 99999999        
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad DNI, Argentinos entre 0 y 89999999
        ///         Extranjero entre 90000000 y 99999999
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }


        /// <summary>
        /// Propiedad Nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad StringToDNI. Solo escritura.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        #endregion


        #region Constructores
        /// <summary>
        /// Constructor Persona
        /// </summary>
        public Persona()
            : this("", "", ENacionalidad.Argentino)
        {
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.dni = 0;
            this.nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida el dni y la nacionalidad
        ///         Argentinos entre 0 y 89999999
        ///  Extranjero entre 90000000 y 99999999        
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato >= 0 && dato < 100000000)
            {
                if ((dato >= 0 && dato <= 89999999 && nacionalidad == ENacionalidad.Extranjero) ||
                     (dato >= 90000000 && dato <= 99999999 && nacionalidad == ENacionalidad.Argentino))
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                }

                return dato;
            }
            else
            {
                throw new DniInvalidoException("Dni invalido");
            }

        }
        /// <summary>
        /// Valida el dni y la nacionalidad
        ///         Argentinos entre 0 y 89999999
        ///  Extranjero entre 90000000 y 99999999        
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            bool error = true;
            if (int.TryParse(dato, out dni))
            {
                ValidarDni(nacionalidad, dni);
                error = false;
            }
            if (error)
            {
                throw new DniInvalidoException("Dni invalido");
            }
            return dni;
        }

        /// <summary>
        /// Valida nombre y apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = string.Empty;
            string pattern = @"\b[a-zA-Z .ñá-úÑÁ-Ú]+";
            Regex re = new Regex(pattern);
            if (re.Match(dato).Value == dato)
            {
                retorno = dato;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo toString sobrecargado
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {this.Nombre}");
            sb.AppendLine($"Apellido: {this.Apellido}");
            sb.AppendLine($"Dni: {this.DNI}");
            sb.AppendLine($"Nacionalidad: {this.Nacionalidad}");
            return sb.ToString();
        }
        #endregion
    }
}
