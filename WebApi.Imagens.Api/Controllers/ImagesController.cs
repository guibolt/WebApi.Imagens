using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Imagens.Api.Model;
using WebApi.Imagens.Service.Consulta.Commands;
using WebApi.Imagens.Service.Consulta.Services.Interfaces;
using WebApi.Imagens.Service.Delecao.Commands;
using WebApi.Imagens.Service.Delecao.Services.Interfaces;
using WebApi.Imagens.Service.Inclusao.Commands;
using WebApi.Imagens.Service.Inclusao.Services;

namespace WebApi.Imagens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IAdicaoService _adicaoService;
        private readonly IConsultaService _consultaService;
        private readonly IDeletaImagemService _deletaImagemService;
        public ImagesController(IAdicaoService adicaoService, IConsultaService consultaService, IDeletaImagemService deletaImagemService)
        {
            _adicaoService = adicaoService;
            _consultaService = consultaService;
            _deletaImagemService = deletaImagemService;
        }

        [Route("buscatodas")]
        [HttpGet]
        public IActionResult BuscaImagens([FromQuery] string tipoRecurso)
        {
            try
            {

                var comando = new BuscaImagensCommand(tipoRecurso);

                var retorno = _consultaService.BuscarImagens(comando);

                return retorno.Sucesso ? Ok(retorno) : (ActionResult)BadRequest(retorno);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
           
        }

        [Route("buscaporid")]
        [HttpGet]
        public IActionResult BuscaImagenPorId([FromQuery] string idImagem, [FromQuery] string tipoRecurso)
        {
            try
            {

                var comando = new BuscaImagemPorIdCommand(tipoRecurso, idImagem);

                var retorno = _consultaService.BuscarPorId(comando);

                return retorno.Sucesso ? Ok(retorno) : (ActionResult)BadRequest(retorno);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }


        [Route("insere")]
        [HttpPost]
        public IActionResult EnviaImagem( [FromForm] InclusaoImagemInputModel imagemInputModel )
        {
            try
            {  
    
                var comando = new AdicionaImagemCommand(imagemInputModel.TipoRecurso, imagemInputModel.Id, imagemInputModel.Arquivo);

                var retorno = _adicaoService.AdicionaImagem(comando);

                return retorno.Sucesso ? Ok(retorno) : (ActionResult)BadRequest(retorno);
            }
            catch (Exception ex )
            {

              return  BadRequest(ex.Message);
            }
        }

        [Route("deletaporid")]
        [HttpDelete]
        public IActionResult DeletaImagemPorId( [FromQuery] string idImagem, [FromQuery] string tipoRecurso)
        {
            try
            {

                var comando = new DeletaImagemCommand(tipoRecurso, idImagem);

                var retorno = _deletaImagemService.DeletaImagem(comando);

                return retorno.Sucesso ? Ok(retorno) : (ActionResult)BadRequest(retorno);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }

    }
}
