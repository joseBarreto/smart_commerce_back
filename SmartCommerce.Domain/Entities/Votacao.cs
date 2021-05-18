using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCommerce.Domain.Entities
{
    [Table("T_VOTACAO")]
    public class Votacao : BaseEntity
    {

        [Column("USUARIOID")]
        public int UsuarioId { get; set; }

        [Column("LOCALID")]
        public int LocalId { get; set; }

        [Column("VOTO")]
        public bool Voto { get; set; }

        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }
    }
}
