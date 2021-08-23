﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCommerce.Domain.Entities;
using SmartCommerce.Domain.Interfaces;
using System.Linq;

namespace SmartCommerce.Application.Controllers
{
    /// <summary>
    ///  HealthCheck da aplicação
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HealthCheckController : BaseController
    {
        private readonly IBaseService<Usuario> _baseUserService;

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="baseUserService"></param>
        public HealthCheckController(IBaseService<Usuario> baseUserService)
        {
            _baseUserService = baseUserService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return Execute(() => _baseUserService.Get().Any());
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());

            }
        }
    }
}
