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
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            return Calculadora.Operar(n1, n2, operador);
        }



        private void btnConverirABinario_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero();
            btnOperar_Click(sender, e);
            lblResultado.Text = numero1.DecimalBinario(lblResultado.Text);

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero();
            lblResultado.Text = numero1.BinarioDecimal(lblResultado.Text);

        }
    }
}
