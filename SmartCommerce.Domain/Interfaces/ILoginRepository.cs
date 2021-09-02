using SmartCommerce.Domain.Entities;

namespace SmartCommerce.Domain.Interfaces
{
    public interface ILoginRepository : IBaseRepository<Login>
    {
        Login GetWithIncludesByEmailAndSenha(string email, string senha);
        Login GetWithIncludesByUsuarioId(int usuarioId);
    }
}
