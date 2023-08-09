using FluentValidation;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxaServico
{
    public class ValidadorTaxaServico : AbstractValidator<TaxaServico>, IValidadorTaxaServico
    {
        public ValidadorTaxaServico()
        {
            RuleFor(f => f.Nome).NotEmpty().NotNull().MinimumLength(4).MaximumLength(100);
            RuleFor(f => f.Preco).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(f => f.Plano).NotEmpty().NotNull();
        }
    }

}
