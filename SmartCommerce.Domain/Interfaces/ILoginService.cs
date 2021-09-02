using SmartCommerce.Domain.Entities;

namespace SmartCommerce.Domain.Interfaces
{
    public interface ILoginService : IBaseService<Login>
    {
        Login GetWithIncludesByEmailAndSenha(string email, string senha);
        Login GetWithIncludesByUsuarioId(int usuarioId);
        string GerarTokenJwt(Login login);

    }
}
