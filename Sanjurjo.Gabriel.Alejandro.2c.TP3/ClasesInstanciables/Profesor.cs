using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Entidades
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Agrega una clase aleatoriamente
        /// </summary>
        void _randomClases()
        {
            int indice = random.Next(0, 4);
            switch (indice)
            {
                case 0:
                    clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                    break;
                case 1:
                    clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                    break;
                case 2:
                    clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                    break;
                case 3:
                    clasesDelDia.Enqueue(Universidad.EClases.SPD);
                    break;
            }
        }

        /// <summary>
        /// Muestra la informacion del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.MostrarDatos()}");
            sb.AppendLine($"{this.ParticiparEnClase()}");
            return sb.ToString();
        }

        /// <summary>
        /// Profesor es igual a la clase si la dicta
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool encontro = false;
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if(item == clase)
                {
                    encontro = true;
                }
            }
            return encontro;
        }

        /// <summary>
        /// Operador !=
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Devuelve clases del dia y lista de clases
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLASES DEL DIA:");
            foreach (Universidad.EClases item in clasesDelDia)
            {
                sb.AppendLine($"{item}");

            }
            return sb.ToString();
        }

        /// <summary>
        /// Constructor Profesor
        /// </summary>
        public Profesor()
            : this(0, "", "", "0", ENacionalidad.Argentino)
        {

        }

        /// <summary>
        /// Constructor estatico
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor Profesor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
       public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
            _randomClases();
        }

        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


    }
}
