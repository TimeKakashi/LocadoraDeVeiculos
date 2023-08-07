using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloParceiro
{
    public class ValidadorParceiro : AbstractValidator<Parceiro>, IValidadorParceiro
    {
        public ValidadorParceiro()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4);
        }
    }
}
