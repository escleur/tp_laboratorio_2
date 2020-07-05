using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado { Ingresado, EnViaje, Entregado}

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        /// <summary>
        /// Propiedad DireccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Propiedad Estado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Propiedad TrackingID
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;
        /// <summary>
        /// Cambia el estado, lanza evento y guarda en db
        /// </summary>
        public void MockCicloDeVida()
        {
            this.estado = EEstado.Ingresado;
            Thread.Sleep(4000);
            this.estado = EEstado.EnViaje;
            this.InformaEstado(this, null);
            Thread.Sleep(4000);
            this.estado = EEstado.Entregado;
            this.InformaEstado(this, null);

            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Devuelve string con informacion de un paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string retorno = string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
            return retorno;
        }

        /// <summary>
        /// Dos paquetes son iguales si tienen el mismo tracking ID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.trackingID == p2.trackingID);
        }

        /// <summary>
        /// !=
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        /// <summary>
        /// Muestra los datos del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        
    }
}
