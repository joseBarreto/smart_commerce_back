using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using SmartCommerce.Domain.Models;
using SmartCommerce.Domain.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using System;
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
        private readonly ILoginService _baseService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="baseService"></param>
        /// <param name="mapper"></param>
        public LoginController(ILoginService baseService, IMapper mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
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

            var login = _baseService.GetWithIncludesByEmailAndSenha(autenticacaoModel.Email, autenticacaoModel.Senha);
            if (login == null)
            {
                return Unauthorized();
            }

            var tokenRespnse = _baseService.GerarTokenJwt(login);
            return Ok(tokenRespnse);
        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="login">Modelo para inserir</param>
        /// <returns>Id do obj</returns>
#if RELEASE
        [ApiExplorerSettings(IgnoreApi = true)]
#endif
        [AllowAnonymous]
        [SwaggerResponse(200, "Ok", typeof(Response<int>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] LoginCreateModel login)
        {
            if (login == null)
                return NotFound();

            if (_baseService.ExistsByEmail(login.Email))
            {
                var response = new Response<string>
                {
                    Message = "E-mail já esta em uso."
                };
                return Conflict(response);
            }

            return Execute(() =>
            {
                var newLogin = _mapper.Map<Login>(login);
                newLogin.Usuario.Status = false;
                newLogin.Usuario.DataCadastro = DateTime.Now;

                return Response<int>.Create(_baseService.Add(newLogin).Id);
            });
        }

        /// <summary>
        /// Retorna as Claims vinculadas no Token do Header
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Response<string>))]
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

                return Response<string>.Create(sb.ToString());
            });
        }

        /// <summary>
        /// Retorna os dados do usuário autenticado
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Response<LoginModel>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpGet()]
        public IActionResult Get()
        {
            var userId = GetCurrentUserId();

            if (userId <= 0)
                return NotFound();

            return Execute(() =>
            {
                return Response<LoginModel>.Create(_mapper.Map<LoginModel>(_baseService.GetWithIncludesByUsuarioId(userId)));
            });
        }
    }
}