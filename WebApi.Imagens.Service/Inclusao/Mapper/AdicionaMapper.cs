using System;
using WebApi.Imagens.Core.Models;
using WebApi.Imagens.Service.Inclusao.Commands;
using static WebApi.Imagens.Core.Helpers.ImageHelper;
using static WebApi.Imagens.Core.Helpers.TratarImagemHelper;

namespace WebApi.Imagens.Service.Inclusao.Mapper
{
    public static  class AdicionaMapper
    {
        public  static ImagemModel RetornaImagem(this AdicionaImagemCommand command)
        {
            var base64img = RetornaBase64(command.Arquivo);

            return new ImagemModel
            {
                DataInclusao = DateTime.Now,
                NomeArquivo = command.Arquivo.FileName,
                Data64 =  ResizeBase64ImageString(command.Arquivo.ContentType,base64img,0),
                ImageId = command.Id
            };
        }
            
            
           
       
    }
}
