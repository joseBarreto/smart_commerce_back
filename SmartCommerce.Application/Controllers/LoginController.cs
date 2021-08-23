using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using SmartCommerce.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Text;

namespace SmartCommerce.Application.Controllers
{
    /// <summary>
    /// Gerencia os dados de login, como geração de Token
    /// </summary>
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="loginService"></param>
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Gera um token 
        /// </summary>
        /// <param name="autenticacaoModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [SwaggerResponse(401, "Unauthorized", typeof(string))]
        [SwaggerResponse(200, "Ok", typeof(string))]
        public IActionResult Login([FromBody] Autenticacao autenticacaoModel)
        {
            if (autenticacaoModel == null ||
                string.IsNullOrEmpty(autenticacaoModel.Email) ||
                string.IsNullOrEmpty(autenticacaoModel.Senha))
            {
                return Unauthorized();
            }

            var login = _loginService.GetWithIncludesByEmailAndSenha(autenticacaoModel.Email, autenticacaoModel.Senha);
            if (login == null)
            {
                return Unauthorized();
            }

            var tokenString = _loginService.GerarTokenJwt(login);
            return Ok(new { token = tokenString });
        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="login">Modelo para inserir</param>
        /// <returns>Id do obj</returns>
        [SwaggerResponse(200, "Ok", typeof(Login))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Login login)
        {
            if (login == null)
                return NotFound();

            return Execute(() => _loginService.Add(login).Id);
        }

        /// <summary>
        /// Retorna as Claims vinculadas no Token do Header
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObterDadosPorToken")]
        public IActionResult ObterDadosPorToken()
        {
            return Execute(() =>
            {
                var sb = new StringBuilder();
                foreach (var item in User.Claims)
                {
                    sb.AppendLine($"Tipo: {item.Type.Split('/').LastOrDefault()} / Valor: {item.Value}");
                }

                return sb.ToString();
            });
        }
    }
}
