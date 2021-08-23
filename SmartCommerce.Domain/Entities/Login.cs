using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCommerce.Domain.Entities
{
    [Table("T_LOGIN")]
    public class Login : BaseEntity
    {
        [Column("USUARIOID")]
        public int UsuarioId { get; set; }

        [Column("DATA_ULTIMO_ACESSO")]
        public DateTime DataUltimoAcesso { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }

        [Column("SENHA")]
        public string Senha { get; set; }

        public Usuario Usuario { get; set; }
    }
}
