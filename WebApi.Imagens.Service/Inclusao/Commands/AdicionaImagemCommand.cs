using FluentValidation.Results;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;
using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Service.Inclusao.Commands.ValidationCommands;

namespace WebApi.Imagens.Service.Inclusao.Commands
{
    public class AdicionaImagemCommand : CommandBase
    {
        public string TipoRecurso { get; private set; }
        public string Id { get; private set; }
        public IFormFile Arquivo { get; private set; }

        public AdicionaImagemCommand(string tipoRecurso, string id, IFormFile arquivo)
        {
            TipoRecurso = tipoRecurso;
            Id = id;
            Arquivo = arquivo;
        }

        public override bool EhValido()
        {
            Validation = new AdicionaImagemCommandValidation().Validate(this);

            return Validation.IsValid;
        }

        public override IList<ValidationFailure> Erros() => Validation.Errors;
      
    }
}
