using WebApi.Imagens.Core.Command;

namespace WebApi.Imagens.Service.Inclusao.Services
{
    public class AdicaoService : IAdicaoService
    {
        public CommandReturn Retorna()
        {
            return new CommandReturn(true);
        }
    }
}
