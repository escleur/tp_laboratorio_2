using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace CorreoAplicacion
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        /// <summary>
        /// Constructor, instancia correo y agrega manejador de evento ErrorDAO
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            PaqueteDAO.ErrorDAO += this.ErrorDAO;
        }

        /// <summary>
        /// Vacia los listBox y los carga con el estado actualizado
        /// </summary>
        private void ActualizarEstado()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            foreach (Paquete item in correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(item);
                        break;
                }
                
            }
        }

        /// <summary>
        /// Manajador de error de db
        /// </summary>
        private void ErrorDAO()
        {
            MessageBox.Show("Error al guardar los datos en la db.");
        }

        /// <summary>
        /// Agrega un paquete y actualiza el estado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            p.InformaEstado += paq_InformaEstado;

            try
            {
                correo += p;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
            }
            this.ActualizarEstado();
        }

        /// <summary>
        /// Ejecuta el hilo correcto y Actualiza el estado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);

                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstado();
            }
        }

        /// <summary>
        /// Finaliza los hilos activos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Muestra los paquetes en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Muestra el elemento seleccionado en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Muestra paquetes en pantalla y guarda en archivo en el escritorio
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(!(elemento is null))
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                rtbMostrar.Text.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\salida.txt");
            }
        }
    }
    
   
}
