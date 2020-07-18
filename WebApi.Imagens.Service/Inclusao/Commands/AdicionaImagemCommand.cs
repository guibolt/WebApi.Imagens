using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Imagens.Core.Command;
using WebApi.Imagens.Service.Inclusao.Commands.ValidationCommands;

namespace WebApi.Imagens.Service.Inclusao.Commands
{
    public class AdicionaImagemCommand : CommandBase
    {
        public string TipoRecurso { get; private set; }
        public string BaseArquivo64 { get; private set; }
        public string NomeArquivo { get; private set; }

        public AdicionaImagemCommand(string tipoRecurso, string baseArquivo64, string nomeArquivo)
        {
            TipoRecurso = tipoRecurso;
            BaseArquivo64 = baseArquivo64;
            NomeArquivo = nomeArquivo;
        }

        public override bool EhValido()
        {
            Validation = new AdicionaImagemCommandValidation().Validate(this);

            return Validation.IsValid;
        }

        public override IList<ValidationFailure> Erros() => Validation.Errors;
      
    }
}
