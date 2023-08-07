using FluentValidation;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>, IValidadorCondutor
    {
        private readonly IRepositorioCliente repositorioCliente;

        public ValidadorCondutor(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;

            RuleFor(c => c.Nome).NotEmpty().NotNull().MinimumLength(4);
            RuleFor(c => c.CNH).NotEmpty().NotNull();
            RuleFor(c => c.ValidadeCNH).NotEmpty().NotNull();
            RuleFor(c => c.Tipo).NotNull().IsInEnum();
            RuleFor(c => c.CPF).NotEmpty().NotNull().When(c => c.Tipo == Condutor.TipoCondutor.PessoaFisica);
        }
    }


}
