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

            RuleFor(a => a.DataDevolucaoPrevista).NotNull().NotEmpty().GreaterThan(DateTime.Today);

            When(a => a.Finalizado, () =>
            {
                RuleFor(a => a.Preco).GreaterThan(0);
            });

            When(a => a.Finalizado, () =>
            {
                RuleFor(a => a.KmPercorrido).GreaterThan(0);
            });

            When(a => a.Finalizado, () =>
            {
                RuleFor(a => a.NivelTanque).NotEqual(new EnumNivelTanque());
            });
        }
    }
}
