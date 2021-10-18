using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartCommerce.Application.Controllers
{
    /// <summary>
    /// Controle de votação
    /// </summary>
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("[controller]")]
    public class VotacaoController : BaseController
    {
        private readonly IBaseService<Local> _baseLocalService;
        private readonly IVotacaoService _baseService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="baseService"></param>
        /// <param name="baseLocalService"></param>
        /// <param name="mapper"></param>
        public VotacaoController(IVotacaoService baseService, IBaseService<Local> baseLocalService, IMapper mapper)
        {
            _baseService = baseService;
            _baseLocalService = baseLocalService;
            _mapper = mapper;
        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="votacao">Modelo para inserir</param>
        /// <returns></returns>
        [SwaggerResponse(204, "Ok")]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpPost]
        public IActionResult Create([FromBody] Votacao votacao)
        {
            if (votacao == null || !_baseLocalService.Exists(votacao.LocalId))
                return NotFound();

            return Execute(() =>
            {
                votacao.UsuarioId = GetCurrentUserId();
                _baseService.Votar(votacao);
                return new NoContentResult();
            });
        }
    }
}
