using System;
using WebApi.Imagens.Core.Models;
using WebApi.Imagens.Service.Inclusao.Commands;

namespace WebApi.Imagens.Service.Inclusao.Mapper
{
    public static  class AdicionaMapper
    {
        public  static ImagemModel RetornaImagem(this AdicionaImagemCommand command) =>
            new ImagemModel
            {
                DataInclusao = DateTime.Now,
                NomeArquivo = command.NomeArquivo,
                Data64 = command.BaseArquivo64
            };
       

    }
}
