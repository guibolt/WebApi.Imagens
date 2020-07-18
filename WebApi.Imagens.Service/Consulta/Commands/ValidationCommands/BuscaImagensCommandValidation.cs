using FluentValidation;

namespace WebApi.Imagens.Service.Consulta.Commands.ValidationCommands
{
    public class BuscaImagensCommandValidation : AbstractValidator<BuscaImagensCommand>
        
    {
        public BuscaImagensCommandValidation()
        {
            RuleFor(c => c.TipoRecurso)
                .NotEmpty()
                .NotNull()
                .WithMessage("TipoRecurso inválido");
        }
    }
}
