using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestUnitario.Dominio.ModuloCliente
{
    [TestClass]
    public class DominioClienteTest
    {
        private IValidator<Cliente> validadorCliente;

        [TestInitialize]
        public void Inicializar()
        {
            validadorCliente = new ValidadorCliente();
        }
        [TestMethod]
        public void DeveCriarClientePessoaFisica()
        {
            var clientePF = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "12345678901", "maria@example.com", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");

            ValidationResult resultado = validadorCliente.Validate(clientePF);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveCriarClientePessoaJuridica()
        {
            var clientePJ = new Cliente(Cliente.TipoCliente.PessoaJuridica, "Empresa XYZ", "98765432101234", "contato@example.com", "Centro", "Rio de Janeiro", "RJ", "456", "Rua B", "98765432101234");

            ValidationResult resultado = validadorCliente.Validate(clientePJ);
            resultado.IsValid.Should().BeTrue();
        }
        [TestMethod]
        public void DeveFalharAoCriarClienteComNomeVazio()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "", "123456789", "maria@example.com", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");

            ValidationResult resultado = validadorCliente.Validate(cliente);
            resultado.IsValid.Should().BeFalse();
           
        }

        [TestMethod]
        public void DeveFalharAoCriarClienteComTelefoneVazio()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "", "maria@example.com", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");

            ValidationResult resultado = validadorCliente.Validate(cliente);
            resultado.IsValid.Should().BeFalse();
           
        }

        [TestMethod]
        public void DeveFalharAoCriarClienteComCPFInvalido()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123456789", "maria@example.com", "Centro", "São Paulo", "SP", "123", "Rua A", "12345");

            ValidationResult resultado = validadorCliente.Validate(cliente);
            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().ContainSingle(e => e.PropertyName == "CPF");
        }

        [TestMethod]
        public void DeveFalharAoCriarClienteComCNPJInvalido()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaJuridica, "Empresa XYZ", "987654321", "contato@example.com", "Centro", "Rio de Janeiro", "RJ", "456", "Rua B", "98765");

            ValidationResult resultado = validadorCliente.Validate(cliente);
            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().ContainSingle(e => e.PropertyName == "CNPJ");
        }
        [TestMethod]
        public void DeveFalharAoCriarClienteComNomeMenorQue3Caracteres()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "Aa", "123456789", "ana@example.com", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");

            ValidationResult resultado = validadorCliente.Validate(cliente);
            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().ContainSingle(e => e.PropertyName == "Nome");
        }
        [TestMethod]
        public void DeveFalharAoCriarClienteComTelefoneComMenosDe11Caracteres()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123", "maria@example.com", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");

            ValidationResult resultado = validadorCliente.Validate(cliente);
            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().ContainSingle(e => e.PropertyName == "Telefone");
        }

        [TestMethod]
        public void DeveFalharAoCriarClienteComEmailComMenosDe6Caracteres()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123456789", "a@b.c", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");

            ValidationResult resultado = validadorCliente.Validate(cliente);
            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().ContainSingle(e => e.PropertyName == "Email");
        }

        [TestMethod]
        public void DeveFalharAoCriarClienteComEstadoComMenosDe2Caracteres()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123456789", "maria@example.com", "Centro", "São Paulo", "S", "123", "Rua A", "12345678901");

            ValidationResult resultado = validadorCliente.Validate(cliente);
            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().ContainSingle(e => e.PropertyName == "Estado");
        }

       

        [TestMethod]
        public void DeveFalharAoCriarClienteComRuaComMenosDe4Caracteres()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123456789", "maria@example.com", "Centro", "São Paulo", "SP", "123", "R A", "12345678901");

            ValidationResult resultado = validadorCliente.Validate(cliente);
            resultado.IsValid.Should().BeFalse();
            resultado.Errors.Should().ContainSingle(e => e.PropertyName == "Rua");
        }
     
     

        [TestMethod]
        public void DeveFalharAoCriarClienteComTelefoneMenorQue11Caracteres()
        {
            var clientePF = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "12345", "maria@example.com", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");

            ValidationResult resultado = validadorCliente.Validate(clientePF);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarClienteComEmailMenorQue6Caracteres()
        {
            var clientePF = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123456789", "a@b.c", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");

            ValidationResult resultado = validadorCliente.Validate(clientePF);
            resultado.IsValid.Should().BeFalse();
        }



        [TestMethod]
        public void DeveFalharAoCriarClienteComBairroComMenosDe2Caracteres()
        {
            var clientePF = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123456789", "maria@example.com", "C", "São Paulo", "SP", "123", "Rua A", "12345678901");

            ValidationResult resultado = validadorCliente.Validate(clientePF);
            resultado.IsValid.Should().BeFalse();
        }

      

        [TestMethod]
        public void DeveFalharAoCriarClienteComCidadeComMenosDe2Caracteres()
        {
            var clientePF = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123456789", "maria@example.com", "Centro", "S", "SP", "123", "Rua A", "12345678901");

            ValidationResult resultado = validadorCliente.Validate(clientePF);
            resultado.IsValid.Should().BeFalse();
        }





    }
}
