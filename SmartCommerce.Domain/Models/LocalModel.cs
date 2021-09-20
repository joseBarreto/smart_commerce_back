using System;
using System.Collections.Generic;

namespace SmartCommerce.Domain.Models
{
    public class LocalModel
    {
        public string Nome { get; set; }
        public string ImagemURL { get; set; }
        public DateTime DataCadastro { get; set; }
        public int TotalVotacao { get; set; }

        public EnderecoModel Endereco { get; set; }

        public SegmentoModel Segmento { get; set; }

        public IList<ProdutoModel> Produtos { get; set; }
    }
}
