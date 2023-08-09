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
        private IRepositorioCliente repositorioCliente;

        [TestInitialize]
       

        [TestMethod]
        public void DeveInserirCliente()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123456789", "maria@example.com", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");

            repositorioCliente.Inserir(cliente);

            var clienteInserido = repositorioCliente.SelecionarPorId(cliente.Id);
            clienteInserido.Should().BeEquivalentTo(cliente);
        }

        [TestMethod]
        public void DeveEditarCliente()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123456789", "maria@example.com", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");
            repositorioCliente.Inserir(cliente);

            cliente.Nome = "Maria Oliveira";
            repositorioCliente.Editar(cliente);

            var clienteEditado = repositorioCliente.SelecionarPorId(cliente.Id);
            clienteEditado.Nome.Should().Be("Maria Oliveira");
        }

        [TestMethod]
        public void DeveExcluirCliente()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123456789", "maria@example.com", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");
            repositorioCliente.Inserir(cliente);

            repositorioCliente.Excluir(cliente);

            var clienteExcluido = repositorioCliente.SelecionarPorId(cliente.Id);
            clienteExcluido.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionarClientePorNome()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123456789", "maria@example.com", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");
            repositorioCliente.Inserir(cliente);

            var clienteSelecionado = repositorioCliente.SelecionarPorNome("Maria Silva");
            clienteSelecionado.Should().BeEquivalentTo(cliente);
        }

        [TestMethod]
        public void DeveSelecionarClientePorCPF()
        {
            var cliente = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123456789", "maria@example.com", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");
            repositorioCliente.Inserir(cliente);

            var clienteSelecionado = repositorioCliente.SelecionarPorCPF("12345678901");
            clienteSelecionado.Should().BeEquivalentTo(cliente);
        }

        [TestMethod]
        public void DeveSelecionarTodosClientes()
        {
            var cliente1 = new Cliente(Cliente.TipoCliente.PessoaFisica, "Maria Silva", "123456789", "maria@example.com", "Centro", "São Paulo", "SP", "123", "Rua A", "12345678901");
            var cliente2 = new Cliente(Cliente.TipoCliente.PessoaJuridica, "Empresa XYZ", "987654321", "contato@example.com", "Centro", "Rio de Janeiro", "RJ", "456", "Rua B", "98765432101234");
            repositorioCliente.Inserir(cliente1);
            repositorioCliente.Inserir(cliente2);

            var clientesSelecionados = repositorioCliente.SelecionarTodos();
            clientesSelecionados.Should().ContainEquivalentOf(cliente1);
            clientesSelecionados.Should().ContainEquivalentOf(cliente2);
        }

       
    }
}
