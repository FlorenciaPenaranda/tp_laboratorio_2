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
        }

        #region controladores
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, comboBox1.Text).ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero number = new Numero(lblResultado.Text);
            lblResultado.Text = number.DecimalBinario(lblResultado.Text);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero number = new Numero(lblResultado.Text);
            lblResultado.Text = number.BinarioDecimal(lblResultado.Text);
        }
        #endregion


        #region metodos limpiar/operar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(string num1, string num2, string operador)
        {
            Numero numero1 = new Numero(num1);
            Numero numero2 = new Numero(num2);

            return Calculadora.Operar(numero1, numero2, operador);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            comboBox1.Text = "";
            lblResultado.Text = "";
        }
        #endregion


    }
}
