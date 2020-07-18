using Microsoft.AspNetCore.Http;

namespace WebApi.Imagens.Api.Model
{
    public class InclusaoImagemInputModel
    {
        public IFormFile Arquivo { get; set; }
        public string TipoRecurso { get; set; }
    }
}
