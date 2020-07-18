using FluentValidation;

namespace WebApi.Imagens.Service.Consulta.Commands.ValidationCommands
{
    public class BuscaImagemPorIdCommandValidation: AbstractValidator<BuscaImagemPorIdCommand>

    {

        public BuscaImagemPorIdCommandValidation()
        {
            RuleFor(c => c.TipoRecurso)
                .NotNull().
                NotEmpty().
                WithMessage("TipoRecurso inváldio");

            RuleFor(c => c.IdImagem)
                 .NotNull().
                NotEmpty()
                .WithMessage("IdImagem inválido");
        }
    }
}
