using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace atv1_3Etapa_HayatoDaviMiyamoto
{
    public partial class FrmPedidos : Form
    {
        // Pasta onde o site salva o arquivo .json do pedido (o programa lê o mais recente).
        // TROCAR pelo caminho real da pasta do front-end.
        private const string PASTA_JSON = @"C:\caminho\do\front-end";

        public FrmPedidos()
        {
            InitializeComponent();
        }

        private void ListarPedidos()
        {
            try
            {
                Conexao banco = new Conexao();
                MySqlConnection conn = banco.conectarBD();

                string sql = "SELECT * FROM pedidos";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPedidos.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar pedidos: " + ex.Message);
            }
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            ListarPedidos();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                // Lê o arquivo .json mais recente da pasta (nome dinâmico)
                string textoJson;
                DirectoryInfo pasta = new DirectoryInfo(PASTA_JSON);
                FileInfo[] arquivos = pasta.GetFiles("*.json");

                if (arquivos.Length == 0)
                {
                    MessageBox.Show("Nenhum arquivo .json encontrado na pasta: " + PASTA_JSON);
                    return;
                }

                FileInfo arquivoMaisRecente = arquivos.OrderByDescending(f => f.LastWriteTime).First();
                textoJson = File.ReadAllText(arquivoMaisRecente.FullName);

                // Desserialização: texto JSON -> objeto C#
                PedidoJson pedidoDoSite = JsonSerializer.Deserialize<PedidoJson>(textoJson);

                if (pedidoDoSite == null || pedidoDoSite.Cliente == null)
                {
                    MessageBox.Show("O arquivo JSON não está no formato esperado.");
                    return;
                }

                Conexao banco = new Conexao();
                MySqlConnection conn = banco.conectarBD();

                string sql = "INSERT INTO pedidos (codigo_pedido, nome_cliente, total, status) VALUES (@codigo, @cliente, @total, 'Pendente')";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@codigo", pedidoDoSite.PedidoId);
                cmd.Parameters.AddWithValue("@cliente", pedidoDoSite.Cliente.Nome);
                cmd.Parameters.AddWithValue("@total", pedidoDoSite.Total);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show($"Pedido {pedidoDoSite.PedidoId} importado com sucesso!");
                ListarPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao importar pedido: " + ex.Message);
            }
        }
    }
}
