using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    using FluentValidation;

    public class ValidadorCliente : AbstractValidator<Cliente>, IValidadorCliente
    {
        public ValidadorCliente()
        {
            RuleFor(c => c.Nome).NotEmpty().NotNull().MinimumLength(4);
            RuleFor(c => c.Telefone).NotEmpty().NotNull();
            RuleFor(c => c.Endereco).SetValidator(new ValidadorEndereco());

            When(c => c.Tipo == Cliente.TipoCliente.PessoaFisica, () =>
            {
                RuleFor(c => c.CPF).NotEmpty().NotNull().Length(11);
                RuleFor(c => c.RG).NotEmpty().NotNull();
                RuleFor(c => c.CNH).NotEmpty().NotNull();
            });

            When(c => c.Tipo == Cliente.TipoCliente.PessoaJuridica, () =>
            {
                RuleFor(c => c.CNPJ).NotEmpty().NotNull().Length(14);
                RuleFor(c => c.CondutorCPF).NotEmpty().NotNull().Length(11);
            });
        }
    }

    public class ValidadorEndereco : AbstractValidator<Endereco>
    {
        public ValidadorEndereco()
        {
            RuleFor(e => e.Logradouro).NotEmpty().NotNull();
            RuleFor(e => e.Numero).NotEmpty().NotNull();
            RuleFor(e => e.Bairro).NotEmpty().NotNull();
            RuleFor(e => e.Cidade).NotEmpty().NotNull();
            RuleFor(e => e.Estado).NotEmpty().NotNull();
            RuleFor(e => e.CEP).NotEmpty().NotNull().Length(8);
        }
    }

}
