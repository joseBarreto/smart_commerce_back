using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCommerce.Domain.Models
{
    public class EnderecoModel
    {
        public int Cep { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Complemento { get; set; }
    }
}
