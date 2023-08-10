using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.TestIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestIntegracao.ModuloTaxaServico
{
    [TestClass]
    public class TestIntegrationTaxaServico : IntegrationTestBase
    {
        [TestMethod]
        public void DeveInserirTaxaServico()
        {
            var taxaServico = Builder<TaxaServico>.CreateNew().Build();

            repositorioTaxaServico.Inserir(taxaServico);

            repositorioTaxaServico.SelecionarPorId(taxaServico.Id).Should().Be(taxaServico);
        }

        [TestMethod]
        public void DeveEditarTaxaServico()
        {
            var taxaServico = Builder<TaxaServico>.CreateNew().Persist();

            repositorioTaxaServico.Editar(taxaServico);

            repositorioTaxaServico.SelecionarPorId(taxaServico.Id).Should().Be(taxaServico);
        }
        [TestMethod]
        public void DeveExcluirTaxaServico()
        {
            var taxaServico = Builder<TaxaServico>.CreateNew().Persist();

            repositorioTaxaServico.Excluir(taxaServico);

            contextoPersistencia.GravarDados();

            repositorioTaxaServico.SelecionarPorId(taxaServico.Id).Should().BeNull();
        }

        [TestMethod]

        public void DeveSelecionarTodos()
        {
            var taxaServico = Builder<TaxaServico>.CreateNew().With(x => x.Nome == "Preco Fixo").Persist();
            var taxaServico2 = Builder<TaxaServico>.CreateNew().With(x => x.Nome == "Cobranca Diaria").Persist();

            var lista = repositorioTaxaServico.SelecionarTodos();

            lista[0].Should().Be(taxaServico);
            lista[1].Should().Be(taxaServico2);
        }
        [TestMethod]
        public void DeveSerPossivelSelecionarPorId()
        {
            var giud = new Guid();

            var taxaServico = Builder<TaxaServico>.CreateNew().Persist();

            var taxaServicoEncontrado = repositorioFuncionario.SelecionarPorId(taxaServico.Id);

        }
    }
}
