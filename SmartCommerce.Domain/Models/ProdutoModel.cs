using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCommerce.Domain.Models
{
    public class ProdutoModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PrecoEstimado { get; set; }
        public DateTime DataCadastro { get; set; }
        public int Codigo { get; set; }
    }
}
