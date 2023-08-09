using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraDeVeiculos.TestUnitario.Dominio.ModuloFuncionario
{
    [TestClass]
    public class DominioFuncionarioTest
    {
        private IValidator<Funcionario> validadorFuncionario;

        [TestInitialize]
        public void Inicializar()
        {
            validadorFuncionario = new ValidadorFuncionario();
        }

        [TestMethod]
        public void DeveCriarFuncionarioValido()
        {
            var funcionario = new Funcionario("João Silva", 2500, new DateTime(2023, 8, 7));

            ValidationResult resultado = validadorFuncionario.Validate(funcionario);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveFalharAoCriarFuncionarioComNomeMenorQue4Caracteres()
        {
            var funcionario = new Funcionario("Ana", 2000, new DateTime(2023, 8, 10));

            ValidationResult resultado = validadorFuncionario.Validate(funcionario);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarFuncionarioComSalarioMenorOuIgualAZero()
        {
            var funcionario = new Funcionario("Pedro Oliveira", 0, new DateTime(2023, 8, 10));

            ValidationResult resultado = validadorFuncionario.Validate(funcionario);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void DeveFalharAoCriarFuncionarioComNomeNulo()
        {
            var funcionario = new Funcionario(null, 2500, new DateTime(2023, 8, 10));

            ValidationResult resultado = validadorFuncionario.Validate(funcionario);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarFuncionarioComSalarioNegativo()
        {
            var funcionario = new Funcionario("Carlos Rocha", -1500, new DateTime(2023, 8, 10));

            ValidationResult resultado = validadorFuncionario.Validate(funcionario);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarFuncionarioComDataEntradaNoFuturo()
        {
            var dataFutura = DateTime.Now.AddDays(1);
            var funcionario = new Funcionario("Laura Alves", 2800, dataFutura);

            ValidationResult resultado = validadorFuncionario.Validate(funcionario);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void DeveFalharAoCriarFuncionarioComNomeEmBranco()
        {
            var funcionario = new Funcionario("   ", 2200, new DateTime(2023, 8, 10));

            ValidationResult resultado = validadorFuncionario.Validate(funcionario);
            resultado.IsValid.Should().BeFalse();
        }


    }
}
