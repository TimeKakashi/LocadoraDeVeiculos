using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.TestIntegracao.Compartilhado;
using System.Runtime.CompilerServices;

namespace LocadoraDeVeiculos.TestIntegracao.ModuloCupom
{
    [TestClass]
    public class TestIntegracaoCupom : IntegrationTestBase
    {
        private Parceiro parceiro;
        private Cupom cupom;
        public TestIntegracaoCupom()
        {
            this.parceiro = Builder<Parceiro>.CreateNew().Persist();
            cupom = Builder<Cupom>.CreateNew().With(x => x.Parceiro = parceiro).Persist();

        }

        [TestMethod]
        public void Deve_inserir_cupom()
        {
            var cupom = Builder<Cupom>.CreateNew().With(x => x.Parceiro = parceiro).Build();

            repositorioCupom.Inserir(cupom);

            contextoPersistencia.GravarDados();

            repositorioCupom.SelecionarPorId(cupom.Id).Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_Editar_Cupom()
        {
            repositorioCupom.Editar(cupom);

            contextoPersistencia.GravarDados();

            repositorioCupom.SelecionarPorId(cupom.Id).Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_excluir_cupom()
        {
            repositorioCupom.Excluir(cupom);

            contextoPersistencia.GravarDados();


            repositorioCupom.SelecionarPorId(cupom.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_cupons()
        {
            var desconto1 = Builder<Cupom>.CreateNew().With(x => x.Parceiro = parceiro).Persist();
            var desconto2 = Builder<Cupom>.CreateNew().With(x => x.Parceiro = parceiro).Persist();
            var desconto3 = Builder<Cupom>.CreateNew().With(x => x.Parceiro = parceiro).Persist();

            var lista = repositorioCupom.SelecionarTodos();

            lista.Should().ContainInOrder(cupom,desconto1, desconto2, desconto3);
            lista.Should().HaveCount(4);
        }


        [TestMethod]
        public void Deve_selecionar_cupom_por_nome()
        {
            var cupomsEncontrado = repositorioCupom.SelecionarPorNome(cupom.Nome);

            cupomsEncontrado.Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_selecionar_cupom_por_id()
        {
            var cupomEncotrado = repositorioCupom.SelecionarPorId(cupom.Id);

            cupomEncotrado.Should().Be(cupom);
        }

    }
}
