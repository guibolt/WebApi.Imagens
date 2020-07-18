using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Data.Interfaces;

namespace WebApi.Imagens.Service.Inclusao.Services
{
    public class AdicaoService : IAdicaoService
    {
        private readonly IDocumentRepository _documentRepository;
        public AdicaoService(IDocumentRepository documentRepository) => _documentRepository = documentRepository;
        public CommandReturn AdicionaImagem()
        {
       

            return new CommandReturn(false);
        }
    }
}
