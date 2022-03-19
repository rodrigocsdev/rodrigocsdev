using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string NomeCategoria { get; set; }
    }
    public class SubCategoria
    {
        public int Id { get; set; }
        public string NomeSubCategoria { get; set; }
    }
}