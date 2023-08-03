using FizzWare.NBuilder;
using FizzWare.NBuilder.Dates;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.TestIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestIntegracao.ModuloFuncionario
{
    [TestClass]

    public class TestIntegracaoFuncionario : IntegrationTestBase
    {
        [TestMethod]
        public void DeveInserirFuncionario()
        {
            var funcionario = Builder<Funcionario>.CreateNew().Build();

            repositorioFuncionario.Inserir(funcionario);

            repositorioFuncionario.SelecionarPorId(funcionario.Id).Should().Be(funcionario);
        }

        [TestMethod]
        public void DeveEditarFuncionario()
        {
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            repositorioFuncionario.Editar(funcionario);

            repositorioFuncionario.SelecionarPorId(funcionario.Id).Should().Be(funcionario);
        }
        [TestMethod]
        public void DeveExcluirFuncionario()
        {
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            repositorioFuncionario.Excluir(funcionario);

            repositorioFuncionario.SelecionarPorId(funcionario.Id).Should().BeNull();
        }

        [TestMethod]

        public void DeveSelecionarTodos()
        {
            var funcionario = Builder<Funcionario>.CreateNew().With(x => x.Nome == "Pedro").Persist();
            var funcionario2 = Builder<Funcionario>.CreateNew().With(x => x.Nome == "Joao").Persist();

            var lista = repositorioFuncionario.SelecionarTodos();

            lista[0].Should().Be(funcionario);
            lista[1].Should().Be(funcionario2);
        }
        [TestMethod]
        public void DeveSelecionarPorId()
        {
            var giud = new Guid();

            var funcionario = Builder<Funcionario>.CreateNew().With(x => x.Nome == "Pedro" && x.Id == giud).Persist();

            var funcEncontrado = repositorioFuncionario.SelecionarPorId(giud);

            funcEncontrado.Should().Be(funcionario);
        }

        [TestMethod]
        public void DeveSelecionarPorNome()
        {
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            var funcEncontrado = repositorioFuncionario.SelecionarPorNome(funcionario.Nome);

            funcEncontrado.Should().Be(funcionario);
        }
    }
}
