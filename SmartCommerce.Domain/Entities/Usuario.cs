using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCommerce.Domain.Entities
{
    [Table("T_USUARIO")]
    public class Usuario : BaseEntity
    {
        [Column("NOME")]
        public string NomeCliente { get; set; }

        [Column("SOBRENOME")]
        public string Sobrenome { get; set; }

        [Column("DATA_CADASTRO")]
        public DateTime? DataCadastro { get; set; }

        [Column("STATUS")]
        public bool Status { get; set; }

        [Column("EMPRESA")]
        public bool Empresa { get; set; }
    }
}
