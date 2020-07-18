using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Service.Inclusao.Commands;

namespace WebApi.Imagens.Service.Inclusao.Services
{
    public interface IAdicaoService
    {
         CommandReturn AdicionaImagem(AdicionaImagemCommand comando);
    }
}
