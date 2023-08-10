using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
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
        private Aluguel aluguel;
        public DominioAluguelTest()
        {
            var funcionario = new Funcionario("NomeFuncionario", 2000, DateTime.Now);
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "NomeCliente", "12345678901", "EmailCliente@gmail.com", "Bairro Cliente", "Cidade Cliente", "CE", "1", "TelefoneCliente", "12345678901");
            var grupoAutomovel = new GrupoAutomovel("Grupo A");
            var planoC = new PlanoCobranca(planoCobranca.Diaria, 10, 10);
            var veiculo = new Veiculo("Modelo X", "Marca Y", "Azul", new byte[100], 10000, "ABC1234", EnumCombusteivel.Gasolina, 50, grupoAutomovel, false);
            var Condutor = new Condutor("asdasd", "12312312323", "1231231232", DateTime.Now.AddDays(5), "12312312323", "teste@gmail.com");

            aluguel = new Aluguel(funcionario, cliente, grupoAutomovel, planoC, veiculo, null, DateTime.Now, DateTime.Now.AddDays(7), 400, false, Condutor);
        }

        [TestMethod]
        public void DeveCriarAluguelValido()
        {
            ValidationResult resultado = validadorAluguel.Validate(aluguel);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveFalharAoCriarAluguelSemFuncionario()
        {
            aluguel.Funcionario = null;

            ValidationResult resultado = validadorAluguel.Validate(aluguel);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarAluguelComDataDevolucaoMenorQueDataLocacao()
        {
            aluguel.Finalizado = true;

            aluguel.DataDevolucao = DateTime.Today;
            aluguel.DataLocacao = DateTime.Today.AddDays(1);

            ValidationResult resultado = validadorAluguel.Validate(aluguel);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarAluguelComValorNegativo()
        {
            aluguel.Preco = -10;
            aluguel.Finalizado = true;

            ValidationResult resultado = validadorAluguel.Validate(aluguel);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarAluguelComKmPercorridoNegativo()
        {
            aluguel.KmPercorrido = -50;
            aluguel.Finalizado = true;

            ValidationResult resultado = validadorAluguel.Validate(aluguel);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveCalcularValorDoAluguelPeloPlanoDiario()
        {
            aluguel.Finalizado = true;
            aluguel.DataLocacao = DateTime.Today;
            aluguel.DataDevolucao = DateTime.Today.AddDays(5);

            aluguel.KmPercorrido = 10;

            decimal valor = aluguel.CalcularValorPorPlanoDiario();

            valor.Should().Be(150);
        }

        [TestMethod]
        public void DeveCalcularValorDoAluguelPeloPlanoControlado()
        {
            var planoD = new PlanoCobranca(planoCobranca.Controlado, 10, 10, 5);

            aluguel.Finalizado = true;
            aluguel.DataLocacao = DateTime.Today;
            aluguel.DataDevolucao = DateTime.Today.AddDays(5);
            aluguel.PlanoCobranca = planoD;

            aluguel.KmPercorrido = 10;
            int kmExtrapolado = 0;

            decimal valor = 0;

            valor = aluguel.CalcularValorPorPlanoControlado();

            valor.Should().Be(100);
        }

        [TestMethod]
        public void DeveCalcularOValorDoAluguelParaPlanoLivre()
        {
            var planoD = new PlanoCobranca(planoCobranca.Controlado, 10, 10, 5);

            aluguel.Finalizado = true;
            aluguel.DataLocacao = DateTime.Today;
            aluguel.DataDevolucao = DateTime.Today.AddDays(5);
            aluguel.PlanoCobranca = planoD;

            decimal valor = aluguel.CalcularValorParaPlanoLivre();

            valor.Should().Be(50);
        }

        [TestMethod]
        public void DeveCalcularValorDeMulta()
        {
            aluguel.DataDevolucaoPrevista = DateTime.Today;
            aluguel.DataDevolucao = DateTime.Today.AddDays(5);

            decimal valorMulta = aluguel.CalcularValorMulta();

            valorMulta.Should().Be(290);
        }

        [TestMethod]
        public void DeveCalcularQuantiadedeDeCombustivelUsada()
        {
            aluguel.NivelTanque = EnumNivelTanque.Medio;

            aluguel.Veiculo.CapacidadeEmLitros = 50;

            decimal QuantidadeCombustivel = aluguel.CalcularQuanidadeLitrosUsados();

            QuantidadeCombustivel.Should().Be(25);
        }

        [TestMethod]

        public void DeveCalcularValorTotal()
        {
            aluguel.NivelTanque = EnumNivelTanque.Medio;

            aluguel.Veiculo.CapacidadeEmLitros = 50;

            aluguel.DataDevolucaoPrevista = DateTime.Today;

            aluguel.DataDevolucao = DateTime.Today.AddDays(5);

            var planoD = new PlanoCobranca(planoCobranca.Controlado, 10, 10, 5);

            aluguel.PlanoCobranca = planoD;

            var resultado = aluguel.CalcularValorTotalSemGasolina();

            resultado.Should().Be(330);
        }
    }
}
