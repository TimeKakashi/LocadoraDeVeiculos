using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public class ValidadorAutomovel : AbstractValidator<Veiculo>, IValidadorAutomovel
    {
        public ValidadorAutomovel()
        {
            RuleFor(x => x.Imagem).NotNull().NotEmpty();

            RuleFor(x => x.GrupoAutomovel).NotEmpty().NotNull();

            RuleFor(x => x.Kilometragem).NotEmpty().NotNull().GreaterThanOrEqualTo(0);

            RuleFor(x => x.Placa).NotEmpty().NotNull().Custom((placa, ctx) =>
            {
                if (!Regex.IsMatch(placa, @"^[A-Z]{3}\d{4}$") && !Regex.IsMatch(placa, @"^[A-Z]{3}\d[A-Z]\d{3}$"))
                {
                    ctx.AddFailure("Placa inválida");
                }
            });

            RuleFor(x => x.Modelo).NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Marca).NotEmpty().NotNull().MinimumLength(3);

            RuleFor(x => x.Cor).NotEmpty().NotNull().MinimumLength(3);

            RuleFor(x => x.EnumCombusteivel).NotEmpty().NotNull();

            RuleFor(x => x.CapacidadeEmLitros).NotEmpty().GreaterThanOrEqualTo(30).NotNull();
        }
    }
}
