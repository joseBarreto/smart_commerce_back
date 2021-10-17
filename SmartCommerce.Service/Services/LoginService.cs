using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using SmartCommerce.Domain.Models;
using SmartCommerce.Domain.Settings;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartCommerce.Service.Services
{
    public class LoginService : BaseService<Login>, ILoginService
    {
        public ILoginRepository _localRepository { get; set; }
        private readonly JwtSettings _jwtSettings;

        public LoginService(ILoginRepository localRepository, IOptions<JwtSettings> jwtSettings) : base(localRepository)
        {
            _localRepository = localRepository;
            _jwtSettings = jwtSettings.Value;
        }

        public Login GetWithIncludesByEmailAndSenha(string email, string senha)
        {
            return _localRepository.GetWithIncludesByEmailAndSenha(email, senha);
        }

        public Login GetWithIncludesByUsuarioId(int usuarioId)
        {
            return _localRepository.GetWithIncludesByUsuarioId(usuarioId);
        }

        public bool ExistsByEmail(string email)
        {
            return _localRepository.ExistsByEmail(email);
        }

        public TokenResponse GerarTokenJwt(Login login)
        {
            var newDateExpiry = _jwtSettings.NewDateExpiry;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Usuario.NomeCliente),
                new Claim(ClaimTypes.Email,login.Email),
                new Claim(ClaimTypes.NameIdentifier, login.UsuarioId.ToString()),
                new Claim(ClaimTypes.Role, "User")
            };

            var token = new JwtSecurityToken(issuer: _jwtSettings.Issuer,
                                             audience: _jwtSettings.Audience,
                                             expires: newDateExpiry,
                                             signingCredentials: credentials,
                                             claims: claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            var tokenRespnse = new TokenResponse()
            {
                User = new User()
                {
                    Id = login.UsuarioId,
                    Email = login.Email
                },
                Token = stringToken,
                ExperireIn = newDateExpiry
            };

            return tokenRespnse;
        }
    }
}