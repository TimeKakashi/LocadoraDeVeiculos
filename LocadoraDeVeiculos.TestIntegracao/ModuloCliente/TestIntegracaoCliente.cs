using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.TestIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestIntegracao.ModuloCliente
{
    [TestClass]
    public class TestIntegracaoCliente : IntegrationTestBase
    {
        private Cliente cliente;
        public TestIntegracaoCliente()
        {
            cliente = Builder<Cliente>.CreateNew().Persist();
        }

        [TestMethod]
        public void DeveInserirCliente()
        {
            var cliente1 = Builder<Cliente>.CreateNew().Build();

            repositorioCliente.Inserir(cliente1);

            repositorioCliente.SelecionarPorId(cliente1.Id).Should().Be(cliente1);
        }

        [TestMethod]
        public void DeveEditarCliente()
        {
            repositorioCliente.Editar(cliente);

            repositorioCliente.SelecionarPorId(cliente.Id).Should().Be(cliente);
        }

        [TestMethod]
        public void DeveExcluirCliente()
        {
            repositorioCliente.Excluir(cliente);

            repositorioCliente.SelecionarPorId(cliente.Id).Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionarProId()
        {
            var item = repositorioCliente.SelecionarPorId(cliente.Id);

            item.Should().Be(cliente);
        }
    }
}
