using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public class ValidadorAutomovel : AbstractValidator<Veiculo>, IValidadorAutomovel
    {
        public ValidadorAutomovel()
        {
            RuleFor(x => x.Placa).NotEmpty().NotNull().Custom((placa, ctx) =>
            {
                if (!Regex.IsMatch(placa, @"^[A-Z]{3}\d{4}$") && !Regex.IsMatch(placa, @"^[A-Z]{3}\d[A-Z]\d{3}$"))
                {
                    ctx.AddFailure("Placa inválida");
                }
            });

            RuleFor(x => x.Modelo).NotNull().NotEmpty().MinimumLength(3);

            RuleFor(x => x.Kilometragem).NotEmpty().NotNull().GreaterThanOrEqualTo(0);

            RuleFor(x => x.CapacidadeEmLitros).NotEmpty().GreaterThanOrEqualTo(30).NotNull();

            RuleFor(x => x.Cor).NotEmpty().NotNull().MinimumLength(3);

            RuleFor(x => x.EnumCombusteivel).NotEmpty().NotNull();

            RuleFor(x => x.GrupoAutomovel).NotEmpty().NotNull();

            RuleFor(x => x.Cor).NotEmpty().NotNull().MinimumLength(3);

            RuleFor(x => x.Marca).NotEmpty().NotNull().MinimumLength(3);
        }
    }
}
