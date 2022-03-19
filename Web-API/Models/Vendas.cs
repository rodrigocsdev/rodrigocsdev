using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class Vendas
    {
        public int ID { get; set; }
        public int IdProduto { get; set; }
        public int IdCategoria { get; set; }
        public int IdSubCategoria { get; set; }
        public int IdCliente { get; set; }
        public int Quantidade { get; set; }
        public double Total { get; set; }

        public Produto Produto { get; set; }
        public Cliente  Cliente { get; set; }
        public Categoria categoria { get; set; }
        public SubCategoria subCategoria { get; set; }
    }
}