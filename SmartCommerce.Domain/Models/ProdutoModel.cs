using System;

namespace SmartCommerce.Domain.Models
{
    public class ProdutoModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double PrecoEstimado { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public int Codigo { get; set; }
        public int LocalId { get; set; }
    }
}