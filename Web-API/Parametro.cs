using System.Data;

namespace Web_API
{
    public class Parametro
    {
        public string Nome { get; set; }
        public SqlDbType Tipo { get; set; }
        public object Valor { get; set; }
    }
}