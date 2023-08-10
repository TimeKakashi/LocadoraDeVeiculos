using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.TestIntegracao.Compartilhado;
using FluentAssertions;
using System.Collections.Immutable;

namespace LocadoraDeVeiculos.TestIntegracao.ModuloCondutor
{
    public class TestIntegracaoCondutor : IntegrationTestBase
    {
        [TestMethod]
        public void Deve_inserir_condutor()
        {
            var condutor = Builder<Condutor>.CreateNew().Build();

            repositorioCondutor.Inserir(condutor);
            contextoPersistencia.GravarDados();

            repositorioCondutor.SelecionarPorId(condutor.Id).Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_Editar_condutor()
        {
            var condutorId = Builder<Condutor>.CreateNew().Persist().Id;

            var condutor = repositorioCondutor.SelecionarPorId(condutorId);
            condutor.Nome = "Joao";

            repositorioCondutor.Editar(condutor);
            contextoPersistencia.GravarDados();

            repositorioCondutor.SelecionarPorId(condutor.Id).Should().Be(condutor);
            condutor.Nome.Should().Be("Joao");
        }

        [TestMethod]
        public void Deve_Excluir_condutor()
        {
            var condutor = Builder<Condutor>.CreateNew().Persist();

            repositorioCondutor.Excluir(condutor);
            contextoPersistencia.GravarDados();

            repositorioCondutor.SelecionarPorId(condutor.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_condutores()
        {
            //arrange
            var condutor = Builder<Condutor>.CreateNew().Persist();
            var condutor2 = Builder<Condutor>.CreateNew().Persist();

            //action
            var condutores = repositorioCondutor.SelecionarTodos();

            //assert
            condutores.Should().ContainInOrder(condutor, condutor2);
            condutores.Should().HaveCount(2);
        }


        [TestMethod]
        public void Deve_selecionar_cupom_por_nome()
        {
            //arrange
            var condutor = Builder<Condutor>.CreateNew().Persist();

            //action
            var condutorEncontrado = repositorioCondutor.SelecionarPorNome(condutor.Nome);

            //assert
            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_selecionar_cupom_por_id()
        {
            //arrange
            var condutor = Builder<Condutor>.CreateNew().Persist();

            //action
            var condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            //assert            
            condutorEncontrado.Should().Be(condutor);
        }
    }
}
