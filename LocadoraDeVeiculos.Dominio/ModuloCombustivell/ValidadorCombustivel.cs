using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCombustivel
{
    public class ValidadorCombustivel : AbstractValidator<Combustivel>, IValidadorCombustivel
    {
        public ValidadorCombustivel()
        {
            RuleFor(x => x.valor).GreaterThan(0).WithMessage("O valor deve ser maior que zero e deve ser um número!").NotNull();
        }
    }
}
