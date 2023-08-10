using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.TestIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestIntegracao.ModuloParceiro
{
    [TestClass]
    public class TestIntegrationParceiro : IntegrationTestBase
    {
        [TestMethod]
        public void Deve_inserir_parceiro() 
        {
            var parceiro = Builder<Parceiro>.CreateNew().Build();  //arrange

            repositorioParceiro.Inserir(parceiro);  //action

            repositorioParceiro.SelecionarPorId(parceiro.Id).Should().Be(parceiro); //assert
        }

        [TestMethod]
        public void Deve_excluir_parceiro() 
        {
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            repositorioParceiro.Excluir(parceiro);

            contextoPersistencia.GravarDados();

            repositorioParceiro.SelecionarPorId(parceiro.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_parceiros() 
        {
            var matematica = Builder<Parceiro>.CreateNew().With(x => x.Nome = "Matematica").Persist();
            var historia = Builder<Parceiro>.CreateNew().With(x => x.Nome = "Historia").Persist();

            var parceiros = repositorioParceiro.SelecionarTodos();

            parceiros.Should().ContainInOrder(matematica, historia);
            parceiros.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_parceiro_por_nome() 
        {
            var cupomParceiro = Builder<Parceiro>.CreateNew().Persist();

            var parceiroEncontrado = repositorioParceiro.SelecionarPorNome(cupomParceiro.Nome);

            parceiroEncontrado.Should().Be(cupomParceiro);
        }

        [TestMethod]
        public void Deve_selecionar_parceiro_por_id() 
        {
            var cupomParceiroNome = Builder<Parceiro>.CreateNew().Persist(); 
            
            var parceiroEncontrado = repositorioParceiro.SelecionarPorId(cupomParceiroNome.Id);

            parceiroEncontrado.Should().Be(cupomParceiroNome);
        }

    }
}
