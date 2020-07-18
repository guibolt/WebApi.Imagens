using FluentValidation.Results;
using System.Collections.Generic;
using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Service.Delecao.Commands.ValidationCommands;

namespace WebApi.Imagens.Service.Delecao.Commands
{
    public class DeletaImagemCommand : CommandBase
    {
        public string TipoRecurso { get; private set; }
        public string IdImagem { get; private set; }

        public DeletaImagemCommand(string tipoRecurso, string idImagem)
        {
            TipoRecurso = tipoRecurso;
            IdImagem = idImagem;
        }

        public override bool EhValido()
        {
            Validation = new DeletaImagemCommandValidation().Validate(this);
            return Validation.IsValid;
        }

        public override IList<ValidationFailure> Erros() => Validation.Errors;
      
    }
}
