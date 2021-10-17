using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Models;

namespace SmartCommerce.Domain.Interfaces
{
    public interface ILoginService : IBaseService<Login>
    {
        Login GetWithIncludesByEmailAndSenha(string email, string senha);

        Login GetWithIncludesByUsuarioId(int usuarioId);

        bool ExistsByEmail(string email);

        TokenResponse GerarTokenJwt(Login login);
    }
}