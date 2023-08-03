using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.TestIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestIntegracao.ModuloGrupoAutomovel
{
    [TestClass]
    public class TestIntegracaoGrupoAutomovel : IntegrationTestBase
    {
        [TestMethod]
        public void DeveSerPossivelInserirGrupo()
        {
            var grupo = Builder<GrupoAutomovel>.CreateNew().Build();

            reposisotiroGrupoAutomovel.Inserir(grupo);

            reposisotiroGrupoAutomovel.SelecionarPorId(grupo.Id).Should().Be(grupo);
        }

        [TestMethod]
        public void DeveSerPossivelEditarGrupo()
        {
            var grupo = Builder<GrupoAutomovel>.CreateNew().Persist();

            reposisotiroGrupoAutomovel.Editar(grupo);

            reposisotiroGrupoAutomovel.SelecionarPorId(grupo.Id).Should().Be(grupo);
        }

        [TestMethod]
        public void DeveSerPossivelExcluirGrupo()
        {
            var grupo = Builder<GrupoAutomovel>.CreateNew().Persist();

            reposisotiroGrupoAutomovel.Excluir(grupo);

            reposisotiroGrupoAutomovel.SelecionarPorId(grupo.Id).Should().BeNull();
        }

        [TestMethod]
        public void DeveSerPossivelSelecionarPorId()
        {
            var giud = new Guid();

            var novoGrupo = Builder<GrupoAutomovel>.CreateNew().Persist();

            var grupoEncontrado = reposisotiroGrupoAutomovel.SelecionarPorId(novoGrupo.Id);

            grupoEncontrado.Should().Be(novoGrupo);
        }

        [TestMethod]
        public void DeveSerPossivelSelecionarPorNome()
        {
            var giud = new Guid();

            var novoGrupo = Builder<GrupoAutomovel>.CreateNew().With(x => x.Nome == "Suvs").Persist();

            var grupoEncontrado = reposisotiroGrupoAutomovel.SelecionarPorNome(novoGrupo.Nome);

            grupoEncontrado.Should().Be(novoGrupo);
        }

        [TestMethod]
        public void DeveSerPossivelSelecionarTodos()
        {
            var novoGrupo = Builder<GrupoAutomovel>.CreateNew().With(x => x.Nome == "Suvs").Persist();
            var novoGrupo2 = Builder<GrupoAutomovel>.CreateNew().With(x => x.Nome == "Suvs").Persist();

            var lista = reposisotiroGrupoAutomovel.SelecionarTodos();

            lista[0].Should().Be(novoGrupo);
            lista[1].Should().Be(novoGrupo2);
            lista.Should().HaveCount(2);
        }

        // To do Modulo de veiculso primeiro para poder pegar os veiculos vinculados ao grupo de automoveis

        //[TestMethod]
        //public void DeveSerPossivelSelecionarTodosComVeiculos()
        //{
        //    var suv = Builder<GrupoAutomovel>.CreateNew().With(x => x.Nome == "Suvs").Persist();

        //    suv.Veiculos.Add(new Dominio.ModuloAutomovel.Veiculo("RV", suv));


        //}

        [TestMethod]
        public void DeveSerPossivelSelecionarPlanosRelacionados()
        {
            GrupoAutomovel suv = Builder<GrupoAutomovel>.CreateNew().Persist();

            var planoUnitario = Builder<PlanoCobranca>.CreateNew().With(x => x.GrupoAutomovel = suv).Persist();
            var planoControle = Builder<PlanoCobranca>.CreateNew().With(x => x.GrupoAutomovel = suv).Persist();

            var grupos = reposisotiroGrupoAutomovel.SelecionarTodos(false, true);

            grupos[0].Planos.Should().HaveCount(2);
            grupos[0].Planos.Should().ContainInOrder(planoUnitario, planoControle);

        }
    }
}
