using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace SmartCommerce.Application.Controllers
{
    /// <summary>
    /// Controle de usuários 
    /// </summary>
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : BaseController
    {
        private readonly IBaseService<Usuario> _baseService;

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="baseUserService"></param>
        public UsuarioController(IBaseService<Usuario> baseUserService)
        {
            _baseService = baseUserService;
        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="user">Modelo para inserir</param>
        /// <returns>Id do obj</returns>
        [SwaggerResponse(200, "Ok", typeof(Usuario))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpPost]
        public IActionResult Create([FromBody] Usuario user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseService.Add(user).Id);
        }

        /// <summary>
        /// Atualiza um registro
        /// </summary>
        /// <param name="user">Usuário com Id para atualização</param>
        /// <returns>Modelo atualizado</returns>
        [SwaggerResponse(200, "Ok", typeof(Usuario))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpPut]
        public IActionResult Update([FromBody] Usuario user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseService.Update(user));
        }

        /// <summary>
        /// Remove um registro 
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns></returns>
        [SwaggerResponse(204, "Ok")]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() =>
            {
                _baseService.Delete(id);
                return new NoContentResult();
            });
        }

        /// <summary>
        /// Retorna uma lista de registros
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(IList<Usuario>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseService.Get());
        }

        /// <summary>
        /// Procura um registro por Id
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Usuario))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseService.GetById(id));
        }

    }
}
