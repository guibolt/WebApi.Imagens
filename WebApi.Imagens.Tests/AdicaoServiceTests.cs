using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Diagnostics;
using System.IO;
using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Core.Models;
using WebApi.Imagens.Data.Interfaces;
using WebApi.Imagens.Service.Inclusao.Commands;
using WebApi.Imagens.Service.Inclusao.Services;
using WebApi.Imagens.Tests.FakeObjects;
using Xunit;

namespace WebApi.Imagens.Tests
{
    public class AdicaoServiceTests
    {
        private Mock<IDocumentRepository> _documentRepository = new Mock<IDocumentRepository>();
        private Mock<IFormFile> _file = new Mock<IFormFile>();

        [Fact]
        public void PassandoDadosCorreos_ChamandoMetodoDeAdicao_DeveRetornarSucesso()
        {
            //Arrange
            var tipoRecurso = "imagens";
            DefineArquivo("Hello World from a Fake File", "test.png","image/png");

            // Act 
            _documentRepository.Setup(c => c.Insere(It.IsAny<ImagemModel>(), tipoRecurso)).Returns(true);

            var comando = new AdicionaImagemCommand(tipoRecurso, "1", _file.Object);

            var serviceMoq = new AdicaoService(_documentRepository.Object);

            var retorno = serviceMoq.AdicionaImagem(comando);

            //Assert
            Assert.NotNull(retorno);
            Assert.True(retorno.Sucesso);
        }

        private void DefineArquivo(string nomeArquivo, string conteudoArquivo, string contentType)
        {
            var content = conteudoArquivo;
            var fileName = nomeArquivo;
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            _file.Setup(_ => _.OpenReadStream()).Returns(ms);
            _file.Setup(_ => _.FileName).Returns(fileName);
            _file.Setup(_ => _.Length).Returns(ms.Length);
            _file.Setup(_ => _.ContentType).Returns(contentType);
        }
    }
}
