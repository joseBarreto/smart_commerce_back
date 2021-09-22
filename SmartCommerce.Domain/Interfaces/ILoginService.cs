using SmartCommerce.Domain.Entities;

namespace SmartCommerce.Domain.Interfaces
{
    public interface ILoginService : IBaseService<Login>
    {
        Login GetWithIncludesByEmailAndSenha(string email, string senha);

        Login GetWithIncludesByUsuarioId(int usuarioId);

        bool ExistsByEmail(string email);

        string GerarTokenJwt(Login login);
    }
}