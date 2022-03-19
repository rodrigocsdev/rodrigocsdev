using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    [RoutePrefix("api/NomeLoja")]
    public class DefaultController : ApiController
    {
        private readonly Funcionalidades funcionalidades;

        public DefaultController()
        {
            this.funcionalidades = new Funcionalidades();
        }
        //------------Cliente------------
        [HttpGet, Route("ListaClientes")]
        public List<Cliente> ListaClientes()
        {
            return funcionalidades.ListaClientes();
        }

        [HttpGet, Route("ObterCliente/{id}")]
        public Cliente ObterCliente([FromUri] int id)
        {
            return funcionalidades.ObterCliente(id);
        }

        [HttpDelete, Route("DeletarCliente/{id}")]
        public int DeletarCliente([FromUri] int id)
        {
            return funcionalidades.DeletarCliente(id);
        }

        [HttpPost, Route("IncluirCliente")]
        public int IncluirCliente([FromBody] Cliente cliente)
        {
            return funcionalidades.IncluirCliente(cliente);
        }

        [HttpPut, Route("AtualizaCliente")]
        public int AtualizaCliente([FromBody] Cliente cliente)
        {
            return funcionalidades.AtualizaCliente(cliente);
        }
        //------------Produto------------
        [HttpGet, Route("ListaProdutos")]
        public List<Produto> ListaProdutos()
        {
            return funcionalidades.ListaProduto();
        }

        [HttpGet, Route("BuscaProduto/{id}")]
        public Produto BuscaProduto([FromUri] int id)
        {
            return funcionalidades.BuscaProduto(id);
        }

        [HttpPost, Route("CadastraProduto")]
        public int CadastraProduto([FromBody] Produto produto)
        {
            return funcionalidades.CadastraProduto(produto);
        }

        [HttpPut, Route("AtualizaProduto")]
        public int AtualizaProduto([FromBody] Produto produto)
        {
            return funcionalidades.AtualizaProduto(produto);
        }

        [HttpDelete, Route("DeletarProduto/{id}")]
        public int DeletarProduto([FromUri] int id)
        {
            return funcionalidades.DeletarProduto(id);
        }
        //------------Venda------------
        [HttpGet, Route("ConsultaVenda/{id}")]
        public List<Vendas> ConsultaVenda([FromUri] int id)
        {
            return funcionalidades.ConsultaVenda(id);
        }

        [HttpPost, Route("CriaVenda")]
        public int CriaVenda([FromBody] Vendas venda)
        {
            return funcionalidades.CriaVenda(venda);
        }

        [HttpPut, Route("AtualizaVenda")]
        public int AtualizaVenda([FromBody] Vendas venda)
        {
            return funcionalidades.AtualizaVenda(venda);
        }

        [HttpDelete, Route("DeletarVenda/{id}")]
        public int DeletarVenda([FromUri] int id)
        {
            return funcionalidades.DeletarVenda(id);
        }

        [HttpGet, Route("ListaVendas")]
        public List<Vendas> ListaVendas()
        {
            return funcionalidades.ListaVendas();
        }
    }
}