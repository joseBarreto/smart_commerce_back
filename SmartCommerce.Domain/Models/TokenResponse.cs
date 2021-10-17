using System;

namespace SmartCommerce.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }

    public class TokenResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
        public DateTime ExperireIn { get; set; }
    }
}
