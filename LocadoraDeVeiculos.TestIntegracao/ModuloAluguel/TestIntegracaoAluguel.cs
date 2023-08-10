using Azure.Core.GeoJson;
using FizzWare.NBuilder;
using FizzWare.NBuilder.Extensions;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.TestIntegracao.Compartilhado;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestIntegracao.ModuloAluguel
{
    [TestClass]
    public class TestIntegracaoAluguel : IntegrationTestBase
    {
        private Aluguel aluguel;
        private Funcionario funcionario;
        private Cliente cliente;
        private GrupoAutomovel grupoAutomovel;
        private PlanoCobranca planoCobranca;
        private Cupom cupom;
        private Condutor condutor;
        private Parceiro parceiro;
        private Veiculo veiuclo;

        public TestIntegracaoAluguel()
        {
            funcionario = Builder<Funcionario>.CreateNew().Persist();
            cliente = Builder<Cliente>.CreateNew().Persist();
            grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            planoCobranca = Builder<PlanoCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupoAutomovel).Persist();
            parceiro = Builder<Parceiro>.CreateNew().Persist();
            cupom = Builder<Cupom>.CreateNew().With(x => x.Parceiro = parceiro).Persist();
            veiuclo = Builder<Veiculo>.CreateNew().With(x => x.EnumCombusteivel = EnumCombusteivel.Gasolina).With(x => x.GrupoAutomovel = grupoAutomovel).With(x => x.Imagem = new byte[10]).Persist();
            condutor = Builder<Condutor>.CreateNew().With(x => x.Cliente = cliente).Persist();
            aluguel = Builder<Aluguel>.CreateNew().With(x => x.Funcionario = funcionario).With(x => x.Cliente = cliente).With(x => x.GrupoAutomovel = grupoAutomovel).With(x => x.PlanoCobranca = planoCobranca)
                .With(x => x.Cupom = cupom).With(x => x.Condutor = condutor).With(x => x.Veiculo = veiuclo).Persist();
        }

        [TestMethod]
        public void Deve_Inserir_Aluguel()
        {
            var aluguel2 = Builder<Aluguel>.CreateNew().With(x => x.Funcionario = funcionario).With(x => x.Cliente = cliente).With(x => x.GrupoAutomovel = grupoAutomovel).With(x => x.PlanoCobranca = planoCobranca)
                .With(x => x.Cupom = cupom).With(x => x.Condutor = condutor).With(x => x.Veiculo = veiuclo).Build();

            repositorioAluguel.Inserir(aluguel2);

            repositorioAluguel.SelecionarPorId(aluguel2.Id).Should().Be(aluguel2);
        }

        [TestMethod]
        public void Deve_Editar_Alguel()
        {
            repositorioAluguel.Editar(this.aluguel);

            repositorioAluguel.SelecionarPorId(aluguel.Id).Should().Be(aluguel);
        }

        [TestMethod]
        public void Deve_Excluir_Alguel()
        {
            repositorioAluguel.Excluir(this.aluguel);

            repositorioAluguel.SelecionarPorId(aluguel.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_Selecionar_Todos()
        {
            var aluguel1 = Builder<Aluguel>.CreateNew().With(x => x.Funcionario = funcionario).With(x => x.Cliente = cliente).With(x => x.GrupoAutomovel = grupoAutomovel).With(x => x.PlanoCobranca = planoCobranca)
                .With(x => x.Cupom = cupom).With(x => x.Condutor = condutor).With(x => x.Veiculo = veiuclo).Persist();

            var aluguel2 = Builder<Aluguel>.CreateNew().With(x => x.Funcionario = funcionario).With(x => x.Cliente = cliente).With(x => x.GrupoAutomovel = grupoAutomovel).With(x => x.PlanoCobranca = planoCobranca)
                .With(x => x.Cupom = cupom).With(x => x.Condutor = condutor).With(x => x.Veiculo = veiuclo).Persist();

            var lista = repositorioAluguel.SelecionarTodos();

            lista[0].Should().Be(aluguel);
            lista[1].Should().Be(aluguel1);
            lista[2].Should().Be(aluguel2);
        }

        [TestMethod]
        public void DeveSelecionarPorId()
        {
            var aluguelEn = repositorioAluguel.SelecionarPorId(aluguel.Id);

            aluguelEn.Should().Be(aluguel);
        }

        [TestMethod]
        public void DeveVerificarSeExiste()
        {
            var resultado = repositorioAluguel.Existe(aluguel);

            resultado.Should().BeTrue();
        }
    }
}
