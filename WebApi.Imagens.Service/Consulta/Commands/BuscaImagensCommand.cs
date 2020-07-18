using FluentValidation.Results;
using System.Collections.Generic;
using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Service.Consulta.Commands.ValidationCommands;


namespace WebApi.Imagens.Service.Consulta.Commands
{
    public class BuscaImagensCommand : CommandBase
    {
        public string TipoRecurso { get; private set; }

        public BuscaImagensCommand(string tipoRecurso) => TipoRecurso = tipoRecurso;
        

        public override bool EhValido()
        {
            Validation = new BuscaImagensCommandValidation().Validate(this);

            return Validation.IsValid;
        }

       public override IList<ValidationFailure> Erros() => Validation.Errors;
    }
}
