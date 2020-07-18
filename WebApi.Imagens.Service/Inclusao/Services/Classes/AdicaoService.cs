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


            var novaImagem = comando.RetornaImagem();

            var imagemIncluida = _documentRepository.Insere(novaImagem, comando.TipoRecurso);

            var votla = _documentRepository.BuscarLista<ImagemModel>("Imagens");

            return imagemIncluida ? new CommandReturn(true, "Imagem inserida com sucesso!", votla) : new CommandReturn(false, "Erro ao inserir imagem");
        }
      
    }
}
