using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Core.Models;
using WebApi.Imagens.Data.Interfaces;
using WebApi.Imagens.Service.Consulta.Commands;
using WebApi.Imagens.Service.Consulta.Services.Interfaces;

namespace WebApi.Imagens.Service.Consulta.Services.Classes
{
    public class ConsultaService : IConsultaService
    {

        private readonly IDocumentRepository _documentRepository;
        public ConsultaService(IDocumentRepository documentRepository) => _documentRepository = documentRepository;

        public CommandReturn BuscarImagens(BuscaImagensCommand command)
        {
            if (!command.EhValido())
                return new CommandReturn(false, command.Erros(), "");

            var lstImagens = _documentRepository.BuscarLista<ImagemModel>(command.TipoRecurso);

            return lstImagens is null ? new CommandReturn(false, "Erro ao buscar lista") : new CommandReturn(true, "Consulta realizada com sucesso!", lstImagens);
        }

        public CommandReturn BuscarPorId(BuscaImagemPorIdCommand command)
        {
            if (!command.EhValido())
                return new CommandReturn(false, command.Erros(), "");

            var imagemBuscada = _documentRepository.Buscar<ImagemModel>(c => c.ImageId == command.IdImagem, command.TipoRecurso);

            return imagemBuscada is null ? new CommandReturn(false, "Erro ao buscar imagem, ela não deve existir.") : new CommandReturn(true, "Consulta realizada com sucesso!", imagemBuscada);
        }
    }
}
