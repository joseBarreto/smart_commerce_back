using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Filter;
using SmartCommerce.Domain.Interfaces;
using SmartCommerce.Domain.Models;
using SmartCommerce.Domain.Wrappers;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace SmartCommerce.Application.Controllers
{
    /// <summary>
    /// Controle de locais 
    /// </summary>
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("[controller]")]
    public class LocalController : BaseController
    {
        /// <summary>
        /// Serviço de Usuário
        /// </summary>
        private readonly ILocalService _baseService;

        private readonly IMapper _mapper;

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="baseUserService"></param>
        /// <param name="mapper"></param>
        public LocalController(ILocalService baseUserService, IMapper mapper)
        {
            _baseService = baseUserService;
            _mapper = mapper;
        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="local">Modelo para inserir</param>
        /// <returns>Id do obj</returns>
        [SwaggerResponse(200, "Ok", typeof(Response<int>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpPost]
        public IActionResult Create([FromBody] Local local)
        {
            if (local == null)
                return NotFound();

            return Execute(() => Response<int>.Create(_baseService.Add(local).Id));
        }

        /// <summary>
        /// Atualiza um registro
        /// </summary>
        /// <param name="local">Usuário com Id para atualização</param>
        /// <returns>Modelo atualizado</returns>
        [SwaggerResponse(200, "Ok", typeof(Response<Local>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpPut]
        public IActionResult Update([FromBody] Local local)
        {
            if (local == null)
                return NotFound();

            return Execute(() => Response<Local>.Create(_baseService.Update(local)));
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
        [SwaggerResponse(200, "Ok", typeof(PagedResponse<IList<LocalModel>>))]
        [SwaggerResponse(400, "Bad Request", typeof(Response<string>))]
        [HttpGet]
        public IActionResult Get([FromQuery] PaginationFilter filter)
        {
            return Execute(() =>
            {
                var local = _baseService.GetWithIncludes(filter.PageNumber, filter.PageSize, out int totalRecords);
                var localModel = _mapper.Map<IList<Local>, IList<LocalModel>>(local);
                return CreatePagedReponse(localModel, filter, totalRecords);
            });
        }

        /// <summary>
        /// Procura um registro por Id
        /// </summary>
        /// <param name="id">Identificador único</param>
        /// <returns></returns>
        [SwaggerResponse(200, "Ok", typeof(Response<Local>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() =>
            {
                return Response<Local>.Create(_baseService.GetById(id));
            });
        }

    }
}
