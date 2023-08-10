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
        private IRepositorioCondutor repositorioCondutor;

        public ValidadorCondutor(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;

            RuleFor(c => c.Nome).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(c => c.CNH).NotEmpty().NotNull().Length(11);
            RuleFor(c => c.ValidadeCNH).NotEmpty().NotNull().Must(BeValidCNHDate).WithMessage("A data de validade da CNH deve ser válida.");
            RuleFor(c => c.Telefone).NotEmpty().NotNull().Length(11);
            RuleFor(c => c.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(c => c.CPF).NotEmpty().NotNull().Length(11);
        }

        private bool BeValidCNHDate(DateTime validade)
        {
            
            return validade >= DateTime.Today;
        }


        public ValidadorCondutor(IRepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }
    }



}
