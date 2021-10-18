using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCommerce.Domain.Entities
{
    [Table("T_LOCAL_PRODUTO")]
    public class LocalProduto : BaseEntity
    {
        [Column("LOCALID")]
        public int LocalId { get; set; }

        public Local Local { get; set; }

        [Column("PRODUTOID")]
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        [Column("DATA_CADASTRO")]
        public DateTime? DataCadastro { get; set; } = DateTime.Now;
    }
}