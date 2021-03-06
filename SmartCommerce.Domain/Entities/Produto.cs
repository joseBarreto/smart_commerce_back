using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCommerce.Domain.Entities
{
    [Table("T_PRODUTO")]
    public class Produto : BaseEntity
    {
        [Column("NOME")]
        public string Nome { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [Column("PRECO_ESTIMADO")]
        public double PrecoEstimado { get; set; }

        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Column("CODIGO")]
        public int Codigo { get; set; }

        public IList<LocalProduto> LocalProdutos { get; set; }
    }
}