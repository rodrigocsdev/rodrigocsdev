using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using Web_API.Data;
using Web_API.Models;

namespace Web_API
{
    public class Funcionalidades
    {
        private readonly string connectionString;
        public Funcionalidades()
        {
            connectionString = @"Server=localhost\SQLEXPRESS;Database=Ecommerce;User Id=sa;Password=clk@2021;";            
        }
        //------------Cliente------------
        public List<Cliente> ListaClientes()
        {
            List<Cliente> listaCliente = new List<Cliente>();

            string sql = "SELECT [Id]," +
                "[NomeCompleto]," +
                "[Idade]," +
                "[DataNascimento]," +
                "[Endereco]," +
                "[Numero]," +
                "[Complemento]," +
                "[CEP]," +
                "[Cidade]," +
                "[UF]," +
                "[Email]" +
                "[CelularWhatsapp]" +
                "FROM[dbo].[Cliente]";

            Conexao conexao = new Conexao(connectionString);
            conexao.Abrir();
            IDataReader sqlDataReader = conexao.ObterDados(sql);

            while (sqlDataReader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = sqlDataReader.GetInt32(0);
                cliente.NomeCompleto = sqlDataReader.GetString(1);
                cliente.Idade = sqlDataReader.GetInt32(2);
                cliente.DataNascimento = sqlDataReader.GetDateTime(3);
                cliente.Endereco = sqlDataReader.GetString(4);
                cliente.Numero = sqlDataReader.GetInt32(5);
                cliente.Complemento = sqlDataReader.GetString(6);
                cliente.CEP = sqlDataReader.GetString(7);
                cliente.Cidade = sqlDataReader.GetString(8);
                cliente.UF = sqlDataReader.GetString(9);
                cliente.Email = sqlDataReader.GetString(10);
                cliente.CelularWhatsapp = sqlDataReader.GetString(11);

                listaCliente.Add(cliente);
            }

            conexao.Fechar();

            return listaCliente;
        }

        public Cliente ObterCliente(int id)
        {
            List<Cliente> listaCliente = new List<Cliente>();
            string sql = "SELECT [Id]," +
                "[NomeCompleto]," +
                "[Idade]," +
                "[DataNascimento]," +
                "[Endereco]," +
                "[Numero]," +
                "[Complemento]," +
                "[CEP]," +
                "[Cidade]," +
                "[UF]," +
                "[Email]" +
                "[CelularWhatsapp]" +
                "FROM[dbo].[Cliente]" +
                " WHERE ID = @ID";

            var conexao = new Conexao(connectionString);
            conexao.Abrir();

            var parametros = new List<Parametro>
            {
                new Parametro { Nome = "ID", Tipo = SqlDbType.Int, Valor = id }
            };

            var sqlDataReader = conexao.ObterDados(sql, parametros);
            while (sqlDataReader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = sqlDataReader.GetInt32(0);
                cliente.NomeCompleto = sqlDataReader.GetString(1);
                cliente.Idade = sqlDataReader.GetInt32(2);
                cliente.DataNascimento = sqlDataReader.GetDateTime(3);
                cliente.Endereco = sqlDataReader.GetString(4);
                cliente.Numero = sqlDataReader.GetInt32(5);
                cliente.Complemento = sqlDataReader.GetString(6);
                cliente.CEP = sqlDataReader.GetString(7);
                cliente.Cidade = sqlDataReader.GetString(8);
                cliente.UF = sqlDataReader.GetString(9);
                cliente.Email = sqlDataReader.GetString(10);
                cliente.CelularWhatsapp = sqlDataReader.GetString(11);

                listaCliente.Add(cliente);
            }

            conexao.Fechar();

            return listaCliente.FirstOrDefault();
        }

        public int DeletarCliente(int id)
        {
            string sql = "DELETE FROM [dbo].[Cliente] WHERE ID = @ID";
            var conexao = new Conexao(connectionString);
            conexao.Abrir();

            var parametros = new List<Parametro>
            {
                new Parametro { Nome = "Id", Tipo = SqlDbType.Int, Valor = id }
            };

            var numeroLinhasAfetadas = conexao.ExecutaComando(sql, parametros);

            conexao.Fechar();

            return numeroLinhasAfetadas;
        }

        public int IncluirCliente(Cliente cliente)
        {
            string sql = "INSERT INTO [dbo].[Cliente]"+
           "([NomeCompleto]" +
           ",[Idade] "+
           ",[DataNascimento]"+
           ",[Endereco]"+
           ",[Numero]"+
           ",[Complemento]"+
           ",[CEP]"+
           ",[Cidade]"+
           ",[UF]"+
           ",[Email]" +
           ",[CelularWhatsapp)"+
            "VALUES"+
           ("(@NomeCompleto" +
           ",@Idade " +
           ",@DataNascimento" +
           ",@Endereco" +
           ",@Numero" +
           ",@Complemento" +
           ",@CEP" +
           ",@Cidade" +
           ",@UF" +
           ",@Email" +
           ",@CelularWhatsapp");
            var conexao = new Conexao(connectionString);
            conexao.Abrir();

            var parametros = new List<Parametro>
            {
                new Parametro{Nome = "NomeCompleto", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.NomeCompleto },
                new Parametro{Nome = "Idade", Tipo = System.Data.SqlDbType.Int, Valor= cliente.Idade },
                new Parametro{Nome = "DataNascimento", Tipo = System.Data.SqlDbType.DateTime, Valor= cliente.DataNascimento },
                new Parametro{Nome = "Endereco", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.Endereco },
                new Parametro{Nome = "Numero", Tipo = System.Data.SqlDbType.Int, Valor= cliente.Numero },
                new Parametro{Nome = "Complemento", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.Complemento },
                new Parametro{Nome = "CEP", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.CEP },
                new Parametro{Nome = "Cidade", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.Cidade },
                new Parametro{Nome = "UF", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.UF },
                new Parametro{Nome = "Email", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.Email },
                new Parametro{Nome = "@CelularWhatsapp", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.CelularWhatsapp }
            };

            var numeroLinhasAfetadas = conexao.ExecutaComando(sql, parametros);

            conexao.Fechar();

            return numeroLinhasAfetadas;
        }

        public int AtualizaCliente(Cliente cliente)
        {
            string sql = "UPDATE [dbo].[Cliente] " +        
        " SET NomeCompleto = @NomeCompleto" +
        ",Idade = @Idade" +
        ",DataNascimento = @DataNascimento" +
        ",Endereco = @Endereco" +
        ",Numero = @Numero" +
        ",Complemento = @Complemento" +
        ",CEP = @CEP" +
        ",Cidade = @Cidade" +
        ",UF = @UF" +
        ",Email = @Email" +
        ", CelularWhatsapp = @CelularWhatsapp" +
        " WHERE Id = @Id";
            var conexao = new Conexao(connectionString);
            conexao.Abrir();

            var parametros = new List<Parametro>
            {
                new Parametro{Nome = "@Id", Tipo = System.Data.SqlDbType.Int, Valor= cliente.Id },
                new Parametro{Nome = "@NomeCompleto", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.NomeCompleto },
                new Parametro{Nome = "@Idade", Tipo = System.Data.SqlDbType.Int, Valor= cliente.Idade },
                new Parametro{Nome = "@DataNascimento", Tipo = System.Data.SqlDbType.DateTime, Valor= cliente.DataNascimento },
                new Parametro{Nome = "@Endereco", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.Endereco },
                new Parametro{Nome = "@Numero", Tipo = System.Data.SqlDbType.Int, Valor= cliente.Numero },
                new Parametro{Nome = "@Complemento", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.Complemento },
                new Parametro{Nome = "@CEP", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.CEP },
                new Parametro{Nome = "@Cidade", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.Cidade },
                new Parametro{Nome = "@UF", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.UF },
                new Parametro{Nome = "@Email", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.Email },
                new Parametro{Nome = "@CelularWhatsapp", Tipo = System.Data.SqlDbType.VarChar, Valor= cliente.CelularWhatsapp }
            };


            var numeroLinhasAfetadas = conexao.ExecutaComando(sql, parametros);

            conexao.Fechar();

            return numeroLinhasAfetadas;
        }
        //------------Produto------------
        public List<Produto> ListaProduto()
        {
            List<Produto> listaProduto = new List<Produto>();

            string sql = "SELECT ID,"+ 
                "DESCRICAO," +
                " PRECO" +
                " FROM PRODUTOS";

            Conexao conexao = new Conexao(connectionString);
            conexao.Abrir();
            IDataReader sqlDataReader = conexao.ObterDados(sql);

            while (sqlDataReader.Read())
            {
                Produto produto = new Produto();
                produto.Id = sqlDataReader.GetInt32(0);
                produto.DescricaoProduto = sqlDataReader.GetString(1);
                produto.DescricaoDetalhadaProduto = sqlDataReader.GetString(1);
                produto.Preco = sqlDataReader.GetDouble(2);

                listaProduto.Add(produto);
            }

            conexao.Fechar();

            return listaProduto;
        }

        public int CadastraProduto(Produto produto)
        {
            string sql = "INSERT INTO PRODUTOS(DESCRICAO, PRECO) VALUES (@DESCRICAO, @PRECO)";

            var conexao = new Conexao(connectionString);
            conexao.Abrir();

            var parametros = new List<Parametro>
            {
                new Parametro{Nome = "DESCRICAO", Tipo = System.Data.SqlDbType.VarChar, Valor = produto.DescricaoProduto},
                new Parametro{Nome = "PRECO", Tipo = System.Data.SqlDbType.Float, Valor = produto.Preco}
            };

            var numeroLinhasAfetadas = conexao.ExecutaComando(sql, parametros);

            conexao.Fechar();

            return numeroLinhasAfetadas;
        }
        
        public Produto BuscaProduto(int id)
        {
            List<Produto> listaProduto = new List<Produto>();

            string sql = "SELECT ID, DESCRICAO, PRECO FROM PRODUTOS WHERE ID = @ID";

            var conexao = new Conexao(connectionString);
            conexao.Abrir();

            var parametros = new List<Parametro>
            {
                new Parametro { Nome = "ID", Tipo = SqlDbType.Int, Valor = id }
            };

            var sqlDataReader = conexao.ObterDados(sql, parametros);
            while (sqlDataReader.Read())
            {
                Produto produto = new Produto();
                produto.Id = sqlDataReader.GetInt32(0);
                produto.DescricaoProduto = sqlDataReader.GetString(1);
                produto.Preco = sqlDataReader.GetDouble(2);

                listaProduto.Add(produto);
            }

            conexao.Fechar();

            return listaProduto.FirstOrDefault();

        }

        public int DeletarProduto(int id)
        {
            string sql = "DELETE FROM PRODUTOS WHERE ID = @ID";
            var conexao = new Conexao(connectionString);
            conexao.Abrir();

            var parametros = new List<Parametro>
            {
                new Parametro { Nome = "ID", Tipo = SqlDbType.Int, Valor = id }
            };

            var numeroLinhasAfetadas = conexao.ExecutaComando(sql, parametros);

            conexao.Fechar();

            return numeroLinhasAfetadas;
        }

        public int AtualizaProduto(Produto produto)
        {
            string sql = "UPDATE PRODUTOS SET DESCRICAO = @DESCRICAO, PRECO = @PRECO WHERE ID = @ID;";
            var conexao = new Conexao(connectionString);
            conexao.Abrir();

            var parametros = new List<Parametro>
            {
                new Parametro{Nome = "ID", Tipo = System.Data.SqlDbType.Int, Valor= produto.Id },
                new Parametro{Nome = "DESCRICAO", Tipo = System.Data.SqlDbType.VarChar, Valor= produto.DescricaoProduto },
                new Parametro{Nome = "PRECO", Tipo = System.Data.SqlDbType.Float, Valor= produto.Preco }               
            };

            var numeroLinhasAfetadas = conexao.ExecutaComando(sql, parametros);

            conexao.Fechar();

            return numeroLinhasAfetadas;
        }

        public List<Vendas> ConsultaVenda (int id)
        {
            string sql = @"
                SELECT VENDAS.ID,IDCLIENTE,IDPRODUTO,DESCRICAO,PRECO,QUANTIDADE,NOME,CLIENTES.DATA_NASCIMENTO,CLIENTES.EMAIL 
                FROM VENDAS 
                INNER JOIN PRODUTOS ON VENDAS.IDPRODUTO = PRODUTOS.ID
                INNER JOIN CLIENTES ON VENDAS.IDCLIENTE = CLIENTES.ID
                WHERE IDCLIENTE = @IDCLIENTE
             ";

            var conexao = new Conexao(connectionString);
            conexao.Abrir();

            var parametros = new List<Parametro>
            {
                new Parametro { Nome = "IDCLIENTE", Tipo = SqlDbType.Int, Valor = id }                
            };

            var sqlDataReader = conexao.ObterDados(sql, parametros);

            List<Vendas> listaVenda = new List<Vendas>();
            while (sqlDataReader.Read())
            {
                var produto = new Produto();
                produto.Id = sqlDataReader.GetInt32(2);
                produto.DescricaoProduto = sqlDataReader.GetString(3);
                produto.DescricaoDetalhadaProduto = sqlDataReader.GetString(3);
                produto.Preco = sqlDataReader.GetDouble(4);

                var cliente = new Cliente();
                cliente.Id = sqlDataReader.GetInt32(1);
                cliente.NomeCompleto = sqlDataReader.GetString(6);
                cliente.DataNascimento = sqlDataReader.GetDateTime(7);
                cliente.Email = sqlDataReader.GetString(8);

                Vendas venda = new Vendas();
                venda.ID = sqlDataReader.GetInt32(0);
                venda.IdCliente = sqlDataReader.GetInt32(1);
                venda.IdProduto = sqlDataReader.GetInt32(2);
                venda.Quantidade = sqlDataReader.GetInt32(5);
                venda.Produto = produto;
                venda.Cliente = cliente;

                listaVenda.Add(venda);
            }
            
            conexao.Fechar();

            return listaVenda;
        }

        public int CriaVenda(Vendas venda)
        {
            string sql = "insert into vendas (IDCLIENTE,IDPRODUTO,QUANTIDADE) values (@IDCLIENTE, @IDPRODUTO, @QUANTIDADE)";

            var conexao = new Conexao(connectionString);
            conexao.Abrir();

            var parametros = new List<Parametro>
            {
                new Parametro{Nome = "IDCLIENTE", Tipo = System.Data.SqlDbType.Int, Valor = venda.IdCliente },
                new Parametro{Nome = "IDPRODUTO", Tipo = System.Data.SqlDbType.Int, Valor = venda.IdProduto },
                new Parametro{Nome = "QUANTIDADE", Tipo = System.Data.SqlDbType.Int, Valor = venda.Quantidade }
            };

            var numeroLinhasAfetadas = conexao.ExecutaComando(sql, parametros);

            conexao.Fechar();

            return numeroLinhasAfetadas;
        }

        public int AtualizaVenda(Vendas venda)
        {
            string sql = "UPDATE VENDAS SET IDPRODUTO = @IDPRODUTO, IDCLIENTE=@IDCLIENTE, QUANTIDADE=@QUANTIDADE";
            var conexao = new Conexao(connectionString);
            conexao.Abrir();

            var parametros = new List<Parametro>
            {
                new Parametro{Nome = "IDCLIENTE", Tipo = System.Data.SqlDbType.Int, Valor = venda.IdCliente },
                new Parametro{Nome = "IDPRODUTO", Tipo = System.Data.SqlDbType.Int, Valor = venda.IdProduto },
                new Parametro{Nome = "QUANTIDADE", Tipo = System.Data.SqlDbType.Int, Valor = venda.Quantidade }
            };

            var numeroLinhasAfetadas = conexao.ExecutaComando(sql, parametros);

            conexao.Fechar();

            return numeroLinhasAfetadas;
        }

        public int DeletarVenda(int id)
        {
            string sql = "DELETE FROM VENDAS WHERE ID = @ID";
            var conexao = new Conexao(connectionString);
            conexao.Abrir();

            var parametros = new List<Parametro>
            {
                new Parametro { Nome = "ID", Tipo = SqlDbType.Int, Valor = id }
            };

            var numeroLinhasAfetadas = conexao.ExecutaComando(sql, parametros);

            conexao.Fechar();

            return numeroLinhasAfetadas;
        }

        public List<Vendas> ListaVendas()
        {

            string sql = @"SELECT VENDAS.ID,IDCLIENTE,IDPRODUTO,DESCRICAO,PRECO,QUANTIDADE,NOME,CLIENTES.DATA_NASCIMENTO,CLIENTES.EMAIL
                FROM VENDAS  
                INNER JOIN PRODUTOS ON VENDAS.IDPRODUTO = PRODUTOS.ID
                INNER JOIN CLIENTES ON VENDAS.IDCLIENTE = CLIENTES.ID";

            Conexao conexao = new Conexao(connectionString);
            conexao.Abrir();
            IDataReader sqlDataReader = conexao.ObterDados(sql);

            List<Vendas> listaVenda = new List<Vendas>();
            while (sqlDataReader.Read())
            {
                var produto = new Produto();
                produto.Id = sqlDataReader.GetInt32(2);
                produto.DescricaoProduto = sqlDataReader.GetString(3);
                produto.Preco = sqlDataReader.GetDouble(4);

                var cliente = new Cliente();
                cliente.Id = sqlDataReader.GetInt32(1);
                cliente.NomeCompleto = sqlDataReader.GetString(6);
                cliente.DataNascimento = sqlDataReader.GetDateTime(7);
                cliente.Email = sqlDataReader.GetString(8);

                Vendas venda = new Vendas();
                venda.ID = sqlDataReader.GetInt32(0);
                venda.IdCliente = sqlDataReader.GetInt32(1);
                venda.IdProduto = sqlDataReader.GetInt32(2);
                venda.Quantidade = sqlDataReader.GetInt32(5);
                venda.Produto = produto;
                venda.Cliente = cliente;


                listaVenda.Add(venda);
            }

            conexao.Fechar();

            return listaVenda;
        }
    }
}