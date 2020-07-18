using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Core.Models;
using WebApi.Imagens.Data.Interfaces;
using WebApi.Imagens.Service.Inclusao.Commands;
using WebApi.Imagens.Service.Inclusao.Mapper;

namespace WebApi.Imagens.Service.Inclusao.Services
{
    public class AdicaoService : IAdicaoService
    {
        private readonly IDocumentRepository _documentRepository;
        public AdicaoService(IDocumentRepository documentRepository) => _documentRepository = documentRepository;

        public CommandReturn AdicionaImagem(AdicionaImagemCommand comando)
        {
            if (!comando.EhValido())
                return new CommandReturn(false, comando.Erros(), "");

            var imagemExiste = _documentRepository.Buscar<ImagemModel>(c => c.ImageId == comando.Id,comando.TipoRecurso);

            if(imagemExiste != null)
                return new CommandReturn(false, "Erro ao inserir imagem, ela ja esta cadastrada");

            var novaImagem = comando.RetornaImagem();

            var imagemIncluida = _documentRepository.Insere(novaImagem, comando.TipoRecurso);

            return imagemIncluida ? new CommandReturn(true, "Imagem inserida com sucesso!") : new CommandReturn(false, "Erro ao inserir imagem");
        }
      
    }
}
