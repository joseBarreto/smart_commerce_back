using System;

namespace SmartCommerce.Domain.Models
{
    public class LoginModel
    {
        public string NomeCliente { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataCadastro { get; set; }
        public bool Status { get; set; }
        public bool Empresa { get; set; }
        public DateTime DataUltimoAcesso { get; set; }
        public string Email { get; set; }
    }
}