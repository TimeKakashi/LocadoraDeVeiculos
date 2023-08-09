namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    using FluentValidation;

    public class ValidadorCliente : AbstractValidator<Cliente>, IValidadorCliente
    {
        public ValidadorCliente()
        {
            RuleFor(c => c.Nome).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(c => c.Telefone).NotEmpty().NotNull().MinimumLength(11);
            RuleFor(c => c.Email).NotEmpty().NotNull().EmailAddress().MinimumLength(6);
            RuleFor(c => c.Estado).NotEmpty().NotNull().Length(2);
            RuleFor(c => c.Bairro).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(c => c.Rua).NotEmpty().NotNull().MinimumLength(4);
            RuleFor(c => c.Cidade).NotEmpty().NotNull().MinimumLength(2);   


            When(c => c.Tipo == Cliente.TipoCliente.PessoaFisica, () =>
            {
                RuleFor(c => c.CPF).NotEmpty().NotNull().Length(11);

            });

            When(c => c.Tipo == Cliente.TipoCliente.PessoaJuridica, () =>
            {
                RuleFor(c => c.CNPJ).NotEmpty().NotNull().Length(14);

            });
        }
    }



}
