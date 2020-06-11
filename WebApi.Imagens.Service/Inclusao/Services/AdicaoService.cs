using System;
using System.IO;
using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Data.Interfaces;
using WebApi.Imagens.Domain.Entities;

namespace WebApi.Imagens.Service.Inclusao.Services
{
    public class AdicaoService : IAdicaoService
    {
        private readonly IDocument _document;

        public AdicaoService(IDocument document)
        {
            _document = document;
        }

        public CommandReturn Retorna()
        {
            var algo = _document.GetData<ImagemEntity>("ImagensCollection");
            _document.Salva(new ImagemEntity { NomeArquivo = "Teste", Data64 = "aasasas" },"ImagensCollection");
            return new CommandReturn(true, AppDomain.CurrentDomain.BaseDirectory, algo);
        }
    }
}
