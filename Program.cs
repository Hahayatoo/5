using System;
using System.Windows.Forms;

namespace atv1_3Etapa_HayatoDaviMiyamoto
{
    internal static class Program
    {
        // 12502243
        // Hayato Davi Miyamoto
        // 2E1
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // O sistema começa pela tela de login (Parte 4)
            Application.Run(new FrmLogin());
        }
    }
}
