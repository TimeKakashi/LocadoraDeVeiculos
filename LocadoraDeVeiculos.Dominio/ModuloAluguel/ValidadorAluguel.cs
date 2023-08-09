using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public class ValidadorAluguel : AbstractValidator<Aluguel>, IValidadorAluguel
    {
        public ValidadorAluguel()
        {
            RuleFor(a => a.Funcionario).NotNull();

            RuleFor(a => a.Cliente).NotNull();

            RuleFor(a => a.GrupoAutomovel).NotNull();

            RuleFor(a => a.PlanoCobranca).NotNull();

            RuleFor(a => a.DataLocacao).NotNull().NotEmpty();

            RuleFor(a => a.Condutor).NotNull();

            RuleFor(a => a.Veiculo).NotNull();

            RuleFor(a => a.DataDevolucaoPrevista).NotNull().NotEmpty().GreaterThan(a => a.DataLocacao);

            When(a => a.Finalizado, () =>
            {
                RuleFor(a => a.KmPercorrido).GreaterThan(0).NotNull();
            });

            When(a => a.Finalizado, () =>
            {
                RuleFor(a => a.NivelTanque).NotEqual(new EnumNivelTanque()).NotNull();
            });

            When(a => a.Finalizado, () =>
            {
                RuleFor(a => a.DataDevolucao).GreaterThan(a => a.DataLocacao.AddDays(1)).WithMessage("A Data de Devolução deve ser maior que a Data de Locação").NotNull();
            });

            When(a => a.Finalizado, () =>
            {
                RuleFor(a => a.Preco).GreaterThan(0);
            });
        }
    }
}
