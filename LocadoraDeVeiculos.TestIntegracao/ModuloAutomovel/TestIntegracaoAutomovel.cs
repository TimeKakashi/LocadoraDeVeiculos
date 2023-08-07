using FizzWare.NBuilder;
using FizzWare.NBuilder.Dates;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.TestIntegracao.Compartilhado;

namespace LocadoraDeVeiculos.TestIntegracao.ModuloAutomovel
{
    [TestClass]
    public class TestIntegracaoAutomovel : IntegrationTestBase
    {
        private GrupoAutomovel grupoAutomovel;
        private Veiculo veiculo;
        public TestIntegracaoAutomovel()
        {
            grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            veiculo = Builder<Veiculo>.CreateNew().With(x => x.Imagem = new byte[100]).With(x => x.GrupoAutomovel = grupoAutomovel).Persist();
        }

        [TestMethod]
        public void DeveInserirAutomovel()
        {
            var veiculoBuilde = Builder<Veiculo>.CreateNew().With(x => x.Imagem = new byte[100]).With(x => x.GrupoAutomovel = grupoAutomovel).Build();


            repositorioAutomovel.Inserir(veiculoBuilde);

            repositorioAutomovel.SelecionarPorId(veiculo.Id).Should().Be(veiculoBuilde);
        }

        [TestMethod]
        public void DeveEditarAutomovel()
        {
            repositorioAutomovel.Editar(veiculo);

            repositorioAutomovel.SelecionarPorId(veiculo.Id).Should().Be(veiculo);
        }

        [TestMethod]
        public void DeveExcluirAutomovel()
        {
            repositorioAutomovel.Excluir(veiculo);

            repositorioAutomovel.SelecionarPorId(veiculo.Id).Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionarTodos()
        {
            var veiculo2 = Builder<Veiculo>.CreateNew().With(x => x.Imagem = new byte[100]).With(x => x.GrupoAutomovel = grupoAutomovel).Persist();

            var lista = repositorioAutomovel.SelecionarTodos();

            lista[0].Should().Be(veiculo);
            lista[1].Should().Be(veiculo2);
            lista.Should().HaveCount(2);
        }

        [TestMethod]
        public void DeveSerPossivelSelecionarPorId()
        {
            repositorioAutomovel.SelecionarPorId(veiculo.Id).Should().Be(veiculo);

        }

        [TestMethod]
        public void DeveSerPossivelVerificarSeExisteAutomovel()
        {
            repositorioAutomovel.Existe(veiculo).Should().BeTrue();
        }
    }
}
