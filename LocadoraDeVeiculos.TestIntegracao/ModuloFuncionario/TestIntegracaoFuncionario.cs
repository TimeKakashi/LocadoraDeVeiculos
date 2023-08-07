using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.TestIntegracao.Compartilhado;

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
            var funcionario = Builder<Funcionario>.CreateNew().Persist();

            var funcEncontrado = repositorioFuncionario.SelecionarPorId(funcionario.Id);

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
