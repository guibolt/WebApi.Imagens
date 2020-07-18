using LiteDB;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Imagens.Data.Context;
using WebApi.Imagens.Service.Inclusao.Services;

namespace WebApi.Imagens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IAdicaoService _adicaoService;
        private ILiteDbContext _liteDbContext;
     

        public ImagesController(IAdicaoService adicaoService, ILiteDbContext liteDbContext)
        {
            _adicaoService = adicaoService;
            _liteDbContext = liteDbContext;
        }

        //[Route("busca")]
        [HttpGet]
        public IActionResult Retornando()

            
        {
            try
            {

              var retorno =   _adicaoService.AdicionaImagem();


                return Ok(retorno  );
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
           
        }
    }

}
