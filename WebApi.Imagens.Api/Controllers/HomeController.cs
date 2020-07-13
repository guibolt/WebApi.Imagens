using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Imagens.Service.Inclusao.Services;

namespace WebApi.Imagens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAdicaoService _adicaoService;

        public HomeController(IAdicaoService adicaoService)
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
