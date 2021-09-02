using Microsoft.EntityFrameworkCore;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using SmartCommerce.Infra.Data.Context;
using System.Linq;


namespace SmartCommerce.Infra.Data.Repository
{
    public class LoginRepository : BaseRepository<Login>, ILoginRepository
    {
        public LoginRepository(SmartCommerceContext mySqlContext) : base(mySqlContext)
        {

        }

        public Login GetWithIncludesByEmailAndSenha(string email, string senha) => _myOracleContext.Login
                                                                      .Include(l => l.Usuario)
                                                                      .FirstOrDefault(x => x.Email == email && x.Senha == senha);

        public Login GetWithIncludesByUsuarioId(int usuarioId) => _myOracleContext.Login
                                                                      .Include(l => l.Usuario)
                                                                      .FirstOrDefault(x => x.UsuarioId == usuarioId);
    }
}
