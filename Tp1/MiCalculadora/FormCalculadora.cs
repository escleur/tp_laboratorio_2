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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
        }

        /// <summary>
        /// boton que limpia los textos operandos y operador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// vacia operandos, operador y resultado
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        /// <summary>
        /// cierra la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// realiza las operaciones matematicas y las muestra en el resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = txtNumero1.Text;
            string numero2 = txtNumero2.Text;
            double resultado;
            string operador = (cmbOperador.SelectedIndex != -1)
                ?cmbOperador.Items[cmbOperador.SelectedIndex].ToString():"";

            resultado = FormCalculadora.Operar(numero1, numero2, operador);
            lblResultado.Text = resultado.ToString();
        }

        /// <summary>
        /// realiza las operaciones matematicas
        /// </summary>
        /// <param name="numero1">primer operando</param>
        /// <param name="numero2">segundo operando</param>
        /// <param name="operador">operador</param>
        /// <returns>retorno el resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            return Calculadora.Operar(n1, n2, operador);
        }

        /// <summary>
        /// convierte un numero a binario y lo muestra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConverirABinario_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero();
            btnOperar_Click(sender, e);
            lblResultado.Text = numero1.DecimalBinario(lblResultado.Text);

        }

        /// <summary>
        /// convierte un numero binario a decimal y lo muestra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero();
            lblResultado.Text = numero1.BinarioDecimal(lblResultado.Text);

        }
    }
}
