using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Web_API.Data
{
    public class Conexao
    {
        private readonly string _connectionString;
        private SqlConnection sqlConnection;

        public Conexao(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void Abrir()
        {
            sqlConnection = new SqlConnection(this._connectionString);
            sqlConnection.Open();
        }

        public void Fechar()
        {
            sqlConnection.Close();
        }

        

        public IDataReader ObterDados(string sql, List<Parametro> parametros = null)
        {
            var sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = sql;
            if( parametros != null)
            {
                foreach (Parametro _parametro in parametros)
                {
                    var parametro = sqlCommand.CreateParameter();
                    parametro.ParameterName = _parametro.Nome;
                    parametro.SqlDbType = _parametro.Tipo;
                    parametro.Value = _parametro.Valor;

                    sqlCommand.Parameters.Add(parametro);
                }
            }            
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            return sqlDataReader;
        }
        
        public int ExecutaComando(string sql, List<Parametro> parametros)
        {
            var sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = sql;

            foreach (Parametro _parametro in parametros)
            {
                var parametro = sqlCommand.CreateParameter();
                parametro.ParameterName = _parametro.Nome;
                parametro.SqlDbType = _parametro.Tipo;
                parametro.Value = _parametro.Valor;

                sqlCommand.Parameters.Add(parametro);
            }
            int numeroLinhasAfetadas = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return numeroLinhasAfetadas;
        }
    }
}