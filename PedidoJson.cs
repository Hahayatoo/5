using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace atv1_3Etapa_HayatoDaviMiyamoto
{
    // ATENÇÃO: moldes do JSON gerado pelo site.
    // Os nomes entre aspas em [JsonPropertyName("...")] precisam ser IGUAIS
    // aos nomes dos campos do arquivo .json do site. Ajuste conforme o seu JSON.

    public class ClienteJson
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("telefone")]
        public string Telefone { get; set; }

        [JsonPropertyName("endereco")]
        public string Endereco { get; set; }
    }

    public class ItemJson
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("quantidade")]
        public int Quantidade { get; set; }

        [JsonPropertyName("preco")]
        public decimal Preco { get; set; }
    }

    public class PedidoJson
    {
        [JsonPropertyName("pedidoId")]
        public string PedidoId { get; set; }

        [JsonPropertyName("cliente")]
        public ClienteJson Cliente { get; set; }

        [JsonPropertyName("itens")]
        public List<ItemJson> Itens { get; set; }

        [JsonPropertyName("total")]
        public decimal Total { get; set; }
    }
}
