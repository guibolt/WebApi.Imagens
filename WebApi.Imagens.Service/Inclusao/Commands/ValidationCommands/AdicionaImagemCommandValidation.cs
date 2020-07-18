using FluentValidation;

namespace WebApi.Imagens.Service.Inclusao.Commands.ValidationCommands
{
    public class AdicionaImagemCommandValidation : AbstractValidator<AdicionaImagemCommand>

    {
        public AdicionaImagemCommandValidation()
        {
            RuleFor(c => c.BaseArquivo64)
                .NotEmpty()
                .NotNull()
                .WithMessage("Arquivo inválido");

            RuleFor(c => c.NomeArquivo)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome do arquivo inválido");

            RuleFor(c => c.TipoRecurso)
                .NotEmpty().
                NotNull().
                WithMessage("TipoRecurso inválido");
        }
    }
}
