using System;

namespace Web_API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string DescricaoDetalhadaProduto { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }

        public Categoria NomeCategoria { get; set; }
        public SubCategoria NomeSubCategoria { get; set; }
    }
}