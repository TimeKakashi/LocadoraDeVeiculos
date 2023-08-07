using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.TestIntegracao.Compartilhado;

namespace LocadoraDeVeiculos.TestIntegracao.ModuloPlanoCobranca
{
    [TestClass]
    public class TestIntergrationPlanoCobranca : IntegrationTestBase
    {
        [TestMethod]
        public void DeveInserirPlanoCobranca()
        {
            var grupo = Builder<GrupoAutomovel>.CreateNew().Build();
            var plano = Builder<PlanoCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupo).Build();

            repositorioPlanoCobranca.Inserir(plano);

            repositorioPlanoCobranca.SelecionarPorId(plano.Id).Should().Be(plano);
        }

        [TestMethod]
        public void DeveEditarPlanoCobranca()
        {
            var grupo = Builder<GrupoAutomovel>.CreateNew().Persist();
            var plano = Builder<PlanoCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupo).Persist();

            repositorioPlanoCobranca.Editar(plano);

            repositorioPlanoCobranca.SelecionarPorId(plano.Id).Should().Be(plano);
        }

        [TestMethod]
        public void DeveExcluirPlanoCobranca()
        {
            var grupo = Builder<GrupoAutomovel>.CreateNew().Persist();
            var plano = Builder<PlanoCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupo).Persist();

            repositorioPlanoCobranca.Excluir(plano);

            repositorioPlanoCobranca.SelecionarPorId(plano.Id).Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionarTodos()
        {
            var grupo = Builder<GrupoAutomovel>.CreateNew().Persist();
            var plano = Builder<PlanoCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupo).Persist();
            var plano2 = Builder<PlanoCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupo).Persist();

            var list = repositorioPlanoCobranca.SelecionarTodos();

            list[0].Should().Be(plano);
            list[1].Should().Be(plano2);
            list.Should().HaveCount(2);
        }

        [TestMethod]
        public void DeveSelecionarPorId()
        {
            var grupo = Builder<GrupoAutomovel>.CreateNew().Persist();
            var plano = Builder<PlanoCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupo).Persist();

            var planoSelecionado = repositorioPlanoCobranca.SelecionarPorId(plano.Id);

            planoSelecionado.Should().Be(plano);
        }
    }
}
