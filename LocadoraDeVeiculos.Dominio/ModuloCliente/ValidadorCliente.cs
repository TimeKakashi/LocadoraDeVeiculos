namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    using FluentValidation;

    public class ValidadorCliente : AbstractValidator<Cliente>, IValidadorCliente
    {
        public ValidadorCliente()
        {
            RuleFor(c => c.Nome).NotEmpty().NotNull().MinimumLength(4);
            RuleFor(c => c.Telefone).NotEmpty().NotNull();


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
