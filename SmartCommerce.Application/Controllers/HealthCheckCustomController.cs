using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
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
    public class HealthCheckCustomController : BaseController
    {
        private readonly IBaseService<Usuario> _baseUserService;

        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="baseUserService"></param>
        public HealthCheckCustomController(IBaseService<Usuario> baseUserService)
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
                return Execute(() => _baseUserService.Get(1, 1, out int totalItens).Any() ?
                HealthCheckResult.Healthy()
                :
                HealthCheckResult.Unhealthy());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, HealthCheckResult.Unhealthy());
            }
        }
    }
}