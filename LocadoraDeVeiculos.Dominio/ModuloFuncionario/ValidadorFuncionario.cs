using FluentValidation;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>, IValidadorFuncionario
    {
        public ValidadorFuncionario()
        {
            RuleFor(f => f.Nome).NotEmpty().NotNull().MinimumLength(4);
            RuleFor(f => f.Salario).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(f => f.DataEntrada).NotEmpty().NotNull();
        }
    }
}
