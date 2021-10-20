using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCommerce.Domain.Entities
{
    [Table("T_LOCAL")]
    public class Local : BaseEntity
    {
        [Column("SEGMENTOID")]
        public int SegmentoId { get; set; }

        [Column("USUARIOID")]
        public int UsuarioId { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("CEP")]
        [StringLength(9, MinimumLength = 0, ErrorMessage = "O valor para {0} tem que ser igual á 8 caracteres")]
        public string Cep { get; set; }

        [Column("LATITUDE")]
        public double Latitude { get; set; }

        [Column("LONGITUDE")]
        public double Longitude { get; set; }

        [Column("LOGRADOURO")]
        public string Logradouro { get; set; }

        [Column("NUMERO")]
        public int? Numero { get; set; }

        [Column("BAIRRO")]
        public string Bairro { get; set; }

        [Column("CIDADE")]
        public string Cidade { get; set; }

        [Column("UF")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O valor para {0} tem que ser igual á 2 caracteres")]
        public string Uf { get; set; }

        [Column("COMPLEMENTO")]
        public string Complemento { get; set; }

        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Column("TOTAL_VOTACAO")]
        public int? TotalVotacao { get; set; }

        [Column("IMAGEM_URL")]
        public string ImagemURL { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [NotMapped]
        public bool Votou { get; set; }

        public Usuario Usuario { get; set; }

        public Segmento Segmento { get; set; }

        public IList<LocalProduto> LocalProdutos { get; set; }
    }
}