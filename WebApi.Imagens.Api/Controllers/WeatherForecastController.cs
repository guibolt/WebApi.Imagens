using Microsoft.AspNetCore.Mvc;

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
            return Ok("");
        }
    }
}
