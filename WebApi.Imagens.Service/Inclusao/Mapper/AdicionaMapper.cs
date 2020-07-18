using System;
using WebApi.Imagens.Core.Models;
using WebApi.Imagens.Service.Inclusao.Commands;
using static WebApi.Imagens.Core.Helpers.ImageHelper;

namespace WebApi.Imagens.Service.Inclusao.Mapper
{
    public static  class AdicionaMapper
    {
        public  static ImagemModel RetornaImagem(this AdicionaImagemCommand command) =>
            new ImagemModel
            {
                DataInclusao = DateTime.Now,
                NomeArquivo = command.Arquivo.FileName,
                Data64 = RetornaBase64( command.Arquivo),
                ImageId = command.Id
            };
       
    }
}
