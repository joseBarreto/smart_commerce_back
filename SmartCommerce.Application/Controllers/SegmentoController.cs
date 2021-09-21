using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Filter;
using SmartCommerce.Domain.Interfaces;
using SmartCommerce.Domain.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace SmartCommerce.Application.Controllers
{
    /// <summary>
    /// Controle de segmentos
    /// </summary>
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("[controller]")]
    public class SegmentoController : BaseController
    {
        private readonly ISegmentoService _baseService;

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="baseService"></param>
        public SegmentoController(ISegmentoService baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="segmento">Modelo para inserir</param>
        /// <returns>Id do obj</returns>
        [SwaggerResponse(200, "Ok", typeof(Response<int>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpPost]
        public IActionResult Create([FromBody] Segmento segmento)
        {
            if (segmento == null)
                return NotFound();

            return Execute(() => Response<int>.Create(_baseService.Add(segmento).Id));
        }

        /// <summary>
        /// Atualiza um registro
        /// </summary>
        /// <param name="segmento">Usuário com Id para atualização</param>
        /// <returns>Modelo atualizado</returns>
        [SwaggerResponse(200, "Ok", typeof(Response<Segmento>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpPut]
        public IActionResult Update([FromBody] Segmento segmento)
        {
            if (segmento == null)
                return NotFound();

            return Execute(() => Response<Segmento>.Create(_baseService.Update(segmento)));
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
        /// <param name="filter"></param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(PagedResponse<IList<Segmento>>))]
        [SwaggerResponse(400, "Bad Request", typeof(Response<string>))]
        [HttpGet]
        public IActionResult Get([FromQuery] PaginationFilter filter)
        {
            return Execute(() =>
            {
                var segmentos = _baseService.GetWithIncludes(filter.PageNumber, filter.PageSize, out int totalRecords);
                return CreatePagedReponse(segmentos, filter, totalRecords);
            });
        }

        /// <summary>
        /// Procura um registro por Id
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Response<Segmento>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => Response<Segmento>.Create(_baseService.GetById(id)));
        }
    }
}