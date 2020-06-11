using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Imagens.Core.Command
{
    public abstract class CommandBase
    {
        protected ValidationResult Validation { get; set; }
        public abstract bool EhValido();
        public abstract IList<ValidationFailure> Erros();
    }
}
