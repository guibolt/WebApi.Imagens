using FluentValidation;

namespace WebApi.Imagens.Service.Delecao.Commands.ValidationCommands
{
    class DeletaImagemCommandValidation : AbstractValidator<DeletaImagemCommand>
    {
        public DeletaImagemCommandValidation()
        {
            RuleFor(c => c.IdImagem)
                .NotEmpty()
                .NotNull()
                .WithMessage("ImagemId inválido");

            RuleFor(c => c.TipoRecurso)
               .NotEmpty()
               .NotNull()
               .WithMessage("TipoRecurso inválido");
        }
    }
}
