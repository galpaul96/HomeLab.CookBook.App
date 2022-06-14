using AutoMapper;
using HomeLab.Domain.Interfaces.Services;
using HomeLab.Domain.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Mime;

namespace HomeLab.Api.Controllers
{
    /// <summary>
    /// HealthChecks controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class HealthChecksController : ControllerBase
    {
        private readonly IHealthChecksService _healthChecksService;
        private readonly ILogger<HealthChecksController> _logger;
        private readonly IMapper _mapper;
        private readonly Configs _configs;

        /// <summary>
        /// Health Chects constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configs"></param>
        /// <param name="healthChecksService"></param>
        /// <param name="mapper"></param>
        public HealthChecksController(ILogger<HealthChecksController> logger, IOptions<Configs> configs, IHealthChecksService healthChecksService, IMapper mapper)
        {
            _logger = logger;
            _configs = configs.Value;
            _healthChecksService = healthChecksService;
            _mapper = mapper;
        }

        /// <summary>
        /// EF Health Check
        /// </summary>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="400"></response>
        [HttpGet("efHealth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> EfHealth()
        {
            _logger.LogInformation("Ef check triggered.");
            if(await _healthChecksService.EfCanConnect())
                return Ok();
            else
                return BadRequest();
        }
    }
}
