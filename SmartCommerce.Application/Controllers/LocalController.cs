using Microsoft.AspNetCore.Mvc;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;


namespace SmartCommerce.Application.Controllers
{
    /// <summary>
    /// Controle de locais 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class LocalController : BaseController
    {
        /// <summary>
        /// Serviço de Usuário
        /// </summary>
        private readonly ILocalService _baseService;

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="baseUserService"></param>
        public LocalController(ILocalService baseUserService)
        {
            _baseService = baseUserService;
        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="local">Modelo para inserir</param>
        /// <returns>Id do obj</returns>
        [SwaggerResponse(200, "Ok", typeof(Local))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpPost]
        public IActionResult Create([FromBody] Local local)
        {
            if (local == null)
                return NotFound();
            
            return Execute(() => _baseService.Add(local).Id);
        }

        /// <summary>
        /// Atualiza um registro
        /// </summary>
        /// <param name="local">Usuário com Id para atualização</param>
        /// <returns>Modelo atualizado</returns>
        [SwaggerResponse(200, "Ok", typeof(Local))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpPut]
        public IActionResult Update([FromBody] Local local)
        {
            if (local == null)
                return NotFound();

            return Execute(() => _baseService.Update(local));
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
        [SwaggerResponse(200, "Ok", typeof(IList<Local>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseService.Get());
        }

        /// <summary>
        /// Retorna uma lista de registros contento Usuários e Segmentos
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(IList<Local>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpGet("GetWithIncludes")]
        public IActionResult GetWithIncludes()
        {
            return Execute(() => _baseService.GetWithIncludes());
        }

        /// <summary>
        /// Procura um registro por Id
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Local))]
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
