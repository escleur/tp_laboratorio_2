using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Propiedad Paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Contructor, instancia las listas
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Aborta los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item.IsAlive)
                {
                    item.Abort();
                }

            }
        }

        /// <summary>
        /// Devuelve un string con informacion de los paquetes
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {

            StringBuilder sb = new StringBuilder();
            foreach (Paquete p in ((Correo)elemento).Paquetes)
            {
                sb.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Agrega un paquete si no esta y lanza un hilo con MockCicloDeVida
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete item in c.paquetes)
            {
                if(item == p)
                {
                    throw new TrackingIdRepetidoException($"El Tracking ID {p.TrackingID} ya figura en la lista de envios");
                }
            }
            c.paquetes.Add(p);
            Thread paqueteThread = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(paqueteThread);
            paqueteThread.Start();
            return c;

        }
    }
}
