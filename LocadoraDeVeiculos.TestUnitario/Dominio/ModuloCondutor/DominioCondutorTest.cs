using FluentAssertions;
using FluentValidation;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestUnitario.Dominio.ModuloCondutor
{
    [TestClass]
    public class DominioCondutorTest
    {
        private IValidator<Condutor> validadorCondutor;
        private Mock<IRepositorioCliente> repositorioClienteMock;

        [TestInitialize]
        public void Inicializar()
        {
            repositorioClienteMock = new Mock<IRepositorioCliente>();
            validadorCondutor = new ValidadorCondutor(repositorioClienteMock.Object);
        }

        [TestMethod]
        public void DeveValidarCondutorComDadosCorretos()
        {
            var condutor = new Condutor
            {
                Nome = "João Silva",
                CNH = "1234567890",
                ValidadeCNH = DateTime.Today.AddDays(30),
                Telefone = "61987654321",
                Email = "joao@example.com",
                CPF = "12345678901"
            };

            var resultado = validadorCondutor.Validate(condutor);

            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveInvalidarCondutorComCNHVencida()
        {
            var condutor = new Condutor
            {
                Nome = "Maria Santos",
                CNH = "98765432101",
                ValidadeCNH = DateTime.Today.AddDays(-1), // Data passada
                Telefone = "123456789",
                Email = "maria@example.com",
                CPF = "98765432101"
            };

            var resultado = validadorCondutor.Validate(condutor);

            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().Contain(e => e.ErrorMessage == "A data de validade da CNH deve ser válida.");
        }

        [TestMethod]
        public void DeveInvalidarCondutorComDadosFaltantes()
        {
            var condutor = new Condutor();

            var resultado = validadorCondutor.Validate(condutor);

            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().NotBeEmpty();
        }
        [TestMethod]
        public void DeveInvalidarCondutorComTelefoneIncorreto()
        {
            var condutor = new Condutor
            {
                Nome = "Ana Souza",
                CNH = "45678901234",
                ValidadeCNH = DateTime.Today.AddDays(60),
                Telefone = "12345", 
                Email = "ana@example.com",
                CPF = "45678901234"
            };

            var resultado = validadorCondutor.Validate(condutor);

            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().Contain(e => e.PropertyName == "Telefone");
        }

        [TestMethod]
        public void DeveInvalidarCondutorComEmailInvalido()
        {
            var condutor = new Condutor
            {
                Nome = "Carlos Oliveira",
                CNH = "56789012345",
                ValidadeCNH = DateTime.Today.AddDays(90),
                Telefone = "987654321",
                Email = "carlosexample.com", 
                CPF = "56789012345"
            };

            var resultado = validadorCondutor.Validate(condutor);

            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().Contain(e => e.PropertyName == "Email");
        }

        [TestMethod]
        public void DeveInvalidarCondutorComCPFInvalido()
        {
            var condutor = new Condutor
            {
                Nome = "Fernanda Oliveira",
                CNH = "12345678901",
                ValidadeCNH = DateTime.Today.AddDays(30),
                Telefone = "987654321",
                Email = "fernanda@example.com",
                CPF = "123456789012" // CPF inválido (mais de 11 dígitos)
            };

            var resultado = validadorCondutor.Validate(condutor);

            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().Contain(e => e.PropertyName == "CPF");
        }

        [TestMethod]
        public void DeveInvalidarCondutorComNomeCurto()
        {
            var condutor = new Condutor
            {
                Nome = "Jo",
                CNH = "56789012345",
                ValidadeCNH = DateTime.Today.AddDays(90),
                Telefone = "987654321",
                Email = "jo@example.com",
                CPF = "56789012345"
            };

            var resultado = validadorCondutor.Validate(condutor);

            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().Contain(e => e.PropertyName == "Nome");
        }

        [TestMethod]
        public void DeveInvalidarCondutorComValidadeCNHVencida()
        {
            var condutor = new Condutor
            {
                Nome = "Lucas Silva",
                CNH = "67890123456",
                ValidadeCNH = DateTime.Today.AddDays(-1), // CNH vencida
                Telefone = "987654321",
                Email = "lucas@example.com",
                CPF = "67890123456"
            };

            var resultado = validadorCondutor.Validate(condutor);

            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().Contain(e => e.PropertyName == "ValidadeCNH");
        }

        [TestMethod]
        public void DeveInvalidarCondutorComTelefoneNulo()
        {
            var condutor = new Condutor
            {
                Nome = "Mariana Santos",
                CNH = "78901234567",
                ValidadeCNH = DateTime.Today.AddDays(60),
                Telefone = null, // Telefone nulo
                Email = "mariana@example.com",
                CPF = "78901234567"
            };

            var resultado = validadorCondutor.Validate(condutor);

            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().Contain(e => e.PropertyName == "Telefone");
        }

        [TestMethod]
        public void DeveInvalidarCondutorComEmailNulo()
        {
            var condutor = new Condutor
            {
                Nome = "Paulo Lima",
                CNH = "89012345678",
                ValidadeCNH = DateTime.Today.AddDays(90),
                Telefone = "987654321",
                Email = null, // Email nulo
                CPF = "89012345678"
            };

            var resultado = validadorCondutor.Validate(condutor);

            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().Contain(e => e.PropertyName == "Email");
        }
    }
}
