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
    /// Controle de produtos
    /// </summary>
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _baseService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="baseService"></param>
        /// <param name="mapper"></param>
        public ProdutoController(IProdutoService baseService, IMapper mapper)
        {
            _baseService = baseService;
            _mapper = mapper;

        }

        /// <summary>
        /// Insere um novo registro
        /// </summary>
        /// <param name="produtoModel">Modelo para inserir</param>
        /// <returns>Id do obj</returns>
        [SwaggerResponse(200, "Ok", typeof(Response<int>))]
        [SwaggerResponse(400, "Bad Request", typeof(string))]
        [HttpPost]
        public IActionResult Create([FromBody] ProdutoModel produtoModel)
        {
            if (produtoModel == null || produtoModel.LocalId < 0)
                return NotFound();

            return Execute(() =>
            {
                var produto = _mapper.Map<ProdutoModel, Produto>(produtoModel);
                var response = Response<int>.Create(_baseService.Add(produto, produtoModel.LocalId).Id);
                return response;
            });
        }
    }
}
