using System;
using System.Windows.Forms;

namespace atv1_3Etapa_HayatoDaviMiyamoto
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            Form1 telaProdutos = new Form1();
            telaProdutos.ShowDialog();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            FrmPedidos telaPedidos = new FrmPedidos();
            telaPedidos.ShowDialog();
        }

        // Como o login está escondido (Hide), fechar a tela principal encerra o programa
        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
