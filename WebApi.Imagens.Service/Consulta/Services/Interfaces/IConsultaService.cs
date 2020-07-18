using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Service.Consulta.Commands;

namespace WebApi.Imagens.Service.Consulta.Services.Interfaces
{
    public interface IConsultaService
    {
        CommandReturn BuscarPorId(BuscaImagemPorIdCommand command);
        CommandReturn BuscarImagens(BuscaImagensCommand command);
    }
}
