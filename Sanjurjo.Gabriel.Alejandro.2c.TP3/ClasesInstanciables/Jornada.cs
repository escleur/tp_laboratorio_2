using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Propiedad Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad Clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad Instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Guarda la jornada en formato texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            string path = Directory.GetCurrentDirectory() + "Jornada.txt";
            Texto texto = new Texto();
            bool guardo = false;
            if(texto.Guardar(path, jornada.ToString()))
            {
                guardo = true;
            }
            return guardo;

        }

        /// <summary>
        /// Constructor Jornada, instancia la lista de alumnos
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor Jornada
        /// </summary>
        /// <param name="clases"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clases, Profesor instructor)
            :this()
        {
            this.clase = clases;
            this.instructor = instructor;
        }

        /// <summary>
        /// Lee la jornada en formato texto
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            string path = Directory.GetCurrentDirectory() + "Jornada.txt";
            Texto texto = new Texto();
            string jornada = string.Empty;
            texto.Leer(path, out jornada);
            return jornada;
        }

        /// <summary>
        /// Jornada es igual a alumno si este esta en la jornada 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool esIgual = false;
            foreach (Alumno item in j.alumnos)
            {
                if(item == a)
                {
                    esIgual = true;
                }
            }
            return esIgual;
        }

        /// <summary>
        /// Operador !=
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega alumno a jornada si este no esta en ella
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Muestra informacion de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLASE DE {this.clase} POR {this.instructor.ToString()}");
            sb.AppendLine($"ALUMNOS:");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine($"{item.ToString()}");

            }
            sb.AppendLine("<------------------------------------------------->");
            return sb.ToString();
        }
    }
}
