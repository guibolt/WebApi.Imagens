using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Service.Delecao.Commands;

namespace WebApi.Imagens.Service.Delecao.Services.Interfaces
{
    public interface IDeletaImagemService
    {
        CommandReturn DeletaImagem(DeletaImagemCommand command);
    }
}
