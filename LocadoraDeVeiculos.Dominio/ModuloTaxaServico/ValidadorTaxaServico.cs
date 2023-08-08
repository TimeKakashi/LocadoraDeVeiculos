using FluentValidation;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxaServico
{
    public class ValidadorTaxaServico : AbstractValidator<TaxaServico>
    {
        public ValidadorTaxaServico()
        {
            RuleFor(f => f.Nome).NotEmpty().NotNull().MinimumLength(4);
            RuleFor(f => f.Preco).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
