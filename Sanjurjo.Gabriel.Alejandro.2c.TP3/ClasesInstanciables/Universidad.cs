using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

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
        /// Propiedad Instructores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Indexador Jornada
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Jornada this[int index]
        {
            get
            {
                return jornada[index];
            }
            set
            {
                jornada[index] = value;
            }
        }

        /// <summary>
        /// Guarda universidad en formato xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            string path = Directory.GetCurrentDirectory() + @"\universidad.xml";
            Xml<Universidad> xmlu = new Xml<Universidad>();
            xmlu.Guardar(path, uni);
            return true;
        }

        /// <summary>
        /// Lee universidad en formato xml
        /// </summary>
        /// <returns></returns>
        public Universidad Leer()
        {
            Universidad u;
            string path = Directory.GetCurrentDirectory() + @"\universidad.xml";
            Xml<Universidad> xmlu = new Xml<Universidad>();
            xmlu.Leer(path, out u);
            return u;
        }

        /// <summary>
        /// retorna un string con los datos de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"JORNADA:");
            foreach (Jornada item in uni.jornada)
            {
                sb.AppendLine($"{item.ToString()}");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Retorna verdadero si el alumno esta en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool contenido = false;
            foreach (Alumno item in g.alumnos)
            {
                if(item == a)
                {
                    contenido = true;
                }
            }
            return contenido;
        }

        /// <summary>
        /// Retorna verdadero si el alumno no esta en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Retorna verdadero si el profesor esta en la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool contenido = false;
            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                {
                    contenido = true;
                }
            }
            return contenido;
        }

        /// <summary>
        /// Retorna verdadero si el profesor no esta en la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Retorna el primer profesor que dicta la clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profesor = null;
            foreach (Profesor item in u.profesores)
            {

                if(item == clase)
                {
                    profesor = item;
                    break;
                }
            }
            if(profesor is null)
            {
                throw new SinProfesorException("No hay Profesor para la clase.");
            }
            return profesor;
        }

        /// <summary>
        /// Retorna el primer profesor que no dicta la clase
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesor = null;
            foreach (Profesor item in u.profesores)
            {

                if (item != clase)
                {
                    profesor = item;
                    break;
                }
            }
            return profesor;
        }

        /// <summary>
        /// Agrega una jornada con profesor y alumnos
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor p = g == clase;
            Jornada j = new Jornada(clase, p);
            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)
                {
                    j += item;
                }
            }
            g.jornada.Add(j);
            return g;
        }

        /// <summary>
        /// Agrega un alumno si este no esta
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido.");
            }
            return u;
        }

        /// <summary>
        /// Agrega un profesor si este no esta
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }
            return u;

        }

        /// <summary>
        /// Devuelve un string con los datos de universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
    }
}
