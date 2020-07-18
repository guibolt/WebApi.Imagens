using FluentValidation;

namespace WebApi.Imagens.Service.Inclusao.Commands.ValidationCommands
{
    public class AdicionaImagemCommandValidation : AbstractValidator<AdicionaImagemCommand>

    {
        public AdicionaImagemCommandValidation()
        {
            RuleFor(c => c.Arquivo)
                .NotNull()
                .WithMessage("Arquivo inválido");

            RuleFor(c => c.Id)
                 .NotEmpty().
                NotNull().
                WithMessage("Id do arquivo inválido");

            RuleFor(c => c.TipoRecurso)
                .NotEmpty().
                NotNull().
                WithMessage("TipoRecurso inválido");
        }
    }
}
