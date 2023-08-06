using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Combustivel
{
    public class ValidadorCombustivel : AbstractValidator<Combustivel>
    {
        public ValidadorCombustivel()
        {
            RuleFor(x => x.valor).GreaterThan(0).NotNull();
        }
    }
}
