using FluentValidation.Results;
using System;
using System.Collections.Generic;
using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Service.Consulta.Commands.ValidationCommands;

namespace WebApi.Imagens.Service.Consulta.Commands
{
    public  class BuscaImagemPorIdCommand : CommandBase
    {
        public string TipoRecurso { get; private set; }
        public string IdImagem { get; private set; }

        public BuscaImagemPorIdCommand(string tipoRecurso, string idImagem)
        {
            TipoRecurso = tipoRecurso;
            IdImagem = idImagem;
        }

        public override bool EhValido()
        {
            Validation = new BuscaImagemPorIdCommandValidation().Validate(this);
            return Validation.IsValid;   
        }

        public override IList<ValidationFailure> Erros() => Validation.Errors;
      
    }
}
