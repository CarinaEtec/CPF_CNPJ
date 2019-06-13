using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidarCNPJ_CPF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rbtCNPJ_CheckedChanged(object sender, EventArgs e)
        {
            maskValor.Text = "";
            maskValor.Mask = "00,000,000/0000-00";
            maskValor.MaskInputRejected += new MaskInputRejectedEventHandler(maskValor_MaskInputRejected);
        }
        private void rdb_cpf_CheckedChanged(object sender, EventArgs e)
        {
            maskValor.Text = "";
            maskValor.Mask = "000,000,000-00";
            maskValor.MaskInputRejected += new MaskInputRejectedEventHandler(maskValor_MaskInputRejected);
        }

        void maskValor_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            toolTip1.ToolTipTitle = "Número informado inválido";
            toolTip1.Show("Somente digitos de (0-9) são permitidos.", maskValor, maskValor.Location, 5000);
        }

        private void btnValidar_Click_1(object sender, EventArgs e)
        {
            string valor = maskValor.Text;
            if (rbtCNPJ.Checked)
            {
                if (ValidaCNPJ.IsCnpj(valor))
                {
                   MessageBox.Show("O número é um CNPJ Válido !");
                }
                else
                {
                    MessageBox.Show("O número é um CNPJ Inválido !");
                }
            }

            else if (rbtCPF.Checked)
            {
                if (ValidaCPF.IsCpf(valor))
                {
                    MessageBox.Show("O número é um CPF Válido !");
                }
                else
                {
                    MessageBox.Show("O número é um CPF Inválido !");
                }
            }

            else
            {
                MessageBox.Show("Informe o número e o seu tipo para validação !");
            }
        }
    }
}
