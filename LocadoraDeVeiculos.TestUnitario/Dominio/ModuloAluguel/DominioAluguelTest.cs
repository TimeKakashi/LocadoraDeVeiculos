using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestUnitario.Dominio.ModuloAluguel
{
    [TestClass]
    public class DominioAluguelTest
    {
        private IValidator<Aluguel> validadorAluguel;

        [TestInitialize]
        public void Inicializar()
        {
            validadorAluguel = new ValidadorAluguel();
        }


        [TestMethod]
        public void DeveCriarAluguelValido()
        {
            var funcionario = new Funcionario("NomeFuncionario", 2000, DateTime.Now);
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "NomeCliente", "12345678901", "EmailCliente@gmail.com", "Bairro Cliente", "Cidade Cliente", "CE", "1", "TelefoneCliente", "12345678901");
            var grupoAutomovel = new GrupoAutomovel("Grupo A");
            var planoCobranca = new PlanoCobranca(0, 10, 10);
            var veiculo = new Veiculo("Modelo X", "Marca Y", "Azul", new byte[0], 10000, "ABC1234", EnumCombusteivel.Gasolina, 50, grupoAutomovel, false);

            var aluguel = new Aluguel(funcionario, cliente, grupoAutomovel, planoCobranca, veiculo, null, DateTime.Now, DateTime.Now.AddDays(7));

            ValidationResult resultado = validadorAluguel.Validate(aluguel);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveFalharAoCriarAluguelSemFuncionario()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "NomeCliente", "12345678901", "Rua Cliente", "123", "Bairro Cliente", "Cidade Cliente", "Estado Cliente", "TelefoneCliente", "EmailCliente@gmail.com");
            var grupoAutomovel = new GrupoAutomovel("Grupo A");
            var planoCobranca = new PlanoCobranca(0, 10, 10);
            var veiculo = new Veiculo("Modelo X", "Marca Y", "Azul", new byte[0], 10000, "ABC1234", EnumCombusteivel.Gasolina, 50, grupoAutomovel, false);

            var aluguel = new Aluguel(null, cliente, grupoAutomovel, planoCobranca, veiculo, null, DateTime.Now, DateTime.Now.AddDays(7));

            ValidationResult resultado = validadorAluguel.Validate(aluguel);
            resultado.IsValid.Should().BeFalse();
        }

       

        [TestMethod]
        public void DeveFalharAoCriarAluguelComKmPercorridoNegativo()
        {
            var funcionario = new Funcionario("NomeFuncionario", 2000, DateTime.Now);
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "NomeCliente", "12345678901", "Rua Cliente", "123", "Bairro Cliente", "Cidade Cliente", "Estado Cliente", "TelefoneCliente", "EmailCliente@gmail.com");
            var grupoAutomovel = new GrupoAutomovel("Grupo A");
            var planoCobranca = new PlanoCobranca(0, 10, 10);
            var veiculo = new Veiculo("Modelo X", "Marca Y", "Azul", new byte[0], 10000, "ABC1234", EnumCombusteivel.Gasolina, 50, grupoAutomovel, false);

            var aluguel = new Aluguel(funcionario, cliente, grupoAutomovel, planoCobranca, veiculo, null, DateTime.Now, DateTime.Now.AddDays(7));
            aluguel.KmPercorrido = -50;

            ValidationResult resultado = validadorAluguel.Validate(aluguel);
            resultado.IsValid.Should().BeFalse();
        }

    }
}
