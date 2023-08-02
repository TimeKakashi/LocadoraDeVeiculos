using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public class ValidadorPlanoCobranca : AbstractValidator<PlanoCobranca>, IValidadorPlanoCobranca
    {
        public ValidadorPlanoCobranca()
        {
            RuleFor(p => p.ValorDiaria).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(p => p.Plano).NotNull();
            RuleFor(p => p.PrecoKm).Custom((precoKm, context) =>
            {
                if (context.InstanceToValidate.Plano == planoCobranca.Diaria && precoKm == null)
                {
                    context.AddFailure("Valor Plano", "Valor do km não pode ser null caso o plano for Diaria");
                }

                if (context.InstanceToValidate.Plano == planoCobranca.Controlado && precoKm == null)
                {
                    context.AddFailure("Valor Plano", "Valor do km não pode ser vazio, eh necessario passar um valor pora cada km extra");
                }
            });

            RuleFor(p => p.KmDisponivel).Custom((KmDisponivel, context) =>
            {
                if (context.InstanceToValidate.Plano == planoCobranca.Controlado && KmDisponivel == null)
                {
                    context.AddFailure("Valor Plano", "Quantidade de km disponiveis nao pode ser vazio");
                }
            });
        }
    }
}
