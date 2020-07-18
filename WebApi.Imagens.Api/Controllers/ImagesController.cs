using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Imagens.Api.Model;
using WebApi.Imagens.Data.Context;
using WebApi.Imagens.Service.Inclusao.Commands;
using WebApi.Imagens.Service.Inclusao.Services;
using static WebApi.Imagens.Api.Helpers.ImageHelper;

namespace WebApi.Imagens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IAdicaoService _adicaoService;
        public ImagesController(IAdicaoService adicaoService, ILiteDbContext liteDbContext)
        {
            _adicaoService = adicaoService;

        }

        //[Route("busca")]
        [HttpGet]
        public IActionResult Retornando()
        {
            try
            {
                return Ok("Eae" );
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
           
        }

        [Route("insere")]
        [HttpPost]
        public IActionResult EnviaImagem( [FromForm] InclusaoImagemInputModel imagemInputModel)
        {
            try
            {
                var imagemBase64 = "";

                if (imagemInputModel.Arquivo != null)
                    imagemBase64 = RetornaBase64(imagemInputModel.Arquivo);

                var comando = new AdicionaImagemCommand(imagemInputModel.TipoRecurso, imagemBase64, imagemInputModel.Arquivo.FileName);

                var retorno = _adicaoService.AdicionaImagem(comando);

                return retorno.Sucesso ? Ok(retorno) : (ActionResult)BadRequest(comando);
            }
            catch (Exception ex )
            {

               return  BadRequest(ex.Message);
            }
        }

    }

}
