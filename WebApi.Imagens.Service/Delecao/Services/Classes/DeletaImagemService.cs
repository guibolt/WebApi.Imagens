using System;
using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Core.Models;
using WebApi.Imagens.Data.Interfaces;
using WebApi.Imagens.Service.Delecao.Commands;
using WebApi.Imagens.Service.Delecao.Services.Interfaces;

namespace WebApi.Imagens.Service.Delecao.Services.Classes
{

    public class DeletaImagemService : IDeletaImagemService
    {
        private readonly IDocumentRepository _documentRepository;
        public DeletaImagemService(IDocumentRepository documentRepository) => _documentRepository = documentRepository;
        public CommandReturn DeletaImagem(DeletaImagemCommand command)
        {
            if (!command.EhValido())
                return new CommandReturn(false, command.Erros(), "");

            var imagemASerDeletada = _documentRepository.Buscar<ImagemModel>(c => c.ImageId == command.IdImagem, command.TipoRecurso);

            if (imagemASerDeletada is null)
                return new CommandReturn(false, "Imagem inválida");

            var imagemFoiDeletada = _documentRepository.Deletar<ImagemModel>(imagemASerDeletada.Id, command.TipoRecurso);

            return imagemFoiDeletada ? new CommandReturn(true, "Imagem deletada com sucesso") : new CommandReturn(false, "erro ao deletar");
        }
    }
}
