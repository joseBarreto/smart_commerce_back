using System;
using System.Collections.Generic;

namespace SmartCommerce.Domain.Models
{
    public class LocalModel
    {
        public string Nome { get; set; }
        public Uri ImageURL { get; set; } = new Uri("https://super.abril.com.br/wp-content/uploads/2016/10/super_imgfilhote_de_pug_0.jpg");
        public DateTime DataCadastro { get; set; }

        public EnderecoModel Endereco { get; set; }

        public SegmentoModel Segmento { get; set; }

        public IList<ProdutoModel> Produtos { get; set; }
    }
}
