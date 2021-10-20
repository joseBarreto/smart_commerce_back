namespace SmartCommerce.Domain.Models
{
    public class LocalSimpleModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ImageURL { get; set; }
        public int SegmentoId { get; set; }
        public EnderecoModel Endereco { get; set; }
    }
}
