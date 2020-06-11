using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Imagens.Core.Command;

using WebApi.Imagens.Service.Inclusao.Services;

namespace WebApi.Imagens.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IAdicaoService _adicaoService;

        public WeatherForecastController(IAdicaoService adicaoService)
        {
            _adicaoService = adicaoService;
        }

       
        [HttpGet]
        public IActionResult Retornando()
        {
            return Ok(_adicaoService.Retorna());
        }
    }
}
