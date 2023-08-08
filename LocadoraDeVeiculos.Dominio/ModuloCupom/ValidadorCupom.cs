using FluentValidation;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCupom
{
    public class ValidadorCupom : AbstractValidator<Cupom>, IValidadorCupom
    {
        public ValidadorCupom() 
        {
            RuleFor(f => f.Nome).NotEmpty().NotNull().MinimumLength(4);
            RuleFor(f => f.Valor).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(f => f.DataDeValidade).NotEmpty().NotNull();
            RuleFor(f => f.Parceiro).NotEmpty().NotNull();
        }
        
    }
}
