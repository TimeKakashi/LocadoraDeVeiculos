using FluentAssertions;
using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxaServico;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestUnitario.Aplicacao.ModuloTaxaServico
{
    [TestClass]
    public class ServicoTaxaServicoTest
    {
        private ServicoTaxaServico servicoTaxaServico;
        private Mock<IRepositorioTaxaServico> mockRepositorioTaxaServico;
        private Mock<IValidadorTaxaServico> mockValidadorTaxaServico;

        [TestInitialize]
        public void Inicializar()
        {
            mockRepositorioTaxaServico = new Mock<IRepositorioTaxaServico>();
            mockValidadorTaxaServico = new Mock<IValidadorTaxaServico>();
            servicoTaxaServico = new ServicoTaxaServico(mockRepositorioTaxaServico.Object, mockValidadorTaxaServico.Object);
        }
        [TestMethod]
        public void DeveInserirTaxaServicoValida()
        {
            var taxaServico = new TaxaServico("Taxa Servico Valida");
            mockRepositorioTaxaServico.Setup(r => r.Inserir(taxaServico));
            mockValidadorTaxaServico.Setup(v => v.Validate(taxaServico)).Returns(new ValidationResult());

            Result resultado = servicoTaxaServico.Inserir(taxaServico);

            resultado.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveInserirTaxaServicoInvalida()
        {
            var taxaServico = new TaxaServico("Taxa Servico Invalida");
            mockRepositorioTaxaServico.Setup(r => r.Inserir(taxaServico));
            mockValidadorTaxaServico.Setup(v => v.Validate(taxaServico)).Returns(new ValidationResult(new List<ValidationFailure>
        {
            new ValidationFailure("Nome", "Nome inválido")
        }));

            Result resultado = servicoTaxaServico.Inserir(taxaServico);

            resultado.IsSuccess.Should().BeFalse();
        }
        [TestMethod]
        public void NaoDeveInserirTaxaServicoComNomeDuplicado()
        {
            var taxaServicoExistente = new TaxaServico("Taxa Servico Existente");
            mockRepositorioTaxaServico.Setup(r => r.SelecionarPorNome(taxaServicoExistente.Nome)).Returns(taxaServicoExistente);

            var novaTaxaServico = new TaxaServico("Taxa Servico Existente");
            mockValidadorTaxaServico.Setup(v => v.Validate(novaTaxaServico)).Returns(new ValidationResult());

            Result resultado = servicoTaxaServico.Inserir(novaTaxaServico);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void NaoDeveInserirTaxaServicoComInformacoesInvalidas()
        {
            var taxaServicoInvalida = new TaxaServico("Taxa Servico Invalida");
            mockRepositorioTaxaServico.Setup(r => r.Inserir(taxaServicoInvalida));
            mockValidadorTaxaServico.Setup(v => v.Validate(taxaServicoInvalida)).Returns(new ValidationResult(new List<ValidationFailure>
        {
            new ValidationFailure("Valor", "Valor inválido")
        }));

            Result resultado = servicoTaxaServico.Inserir(taxaServicoInvalida);

            resultado.IsSuccess.Should().BeFalse();
        }
        [TestMethod]
        public void DeveEditarTaxaServicoExistente()
        {
            var taxaServico = new TaxaServico("Taxa Servico Existente");
            mockRepositorioTaxaServico.Setup(r => r.Editar(taxaServico));
            mockValidadorTaxaServico.Setup(v => v.Validate(taxaServico)).Returns(new ValidationResult());

            Result resultado = servicoTaxaServico.Editar(taxaServico);

            resultado.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveEditarTaxaServicoInexistente()
        {
            var taxaServico = new TaxaServico("Taxa Servico Inexistente");
            mockRepositorioTaxaServico.Setup(r => r.Editar(taxaServico));
            mockValidadorTaxaServico.Setup(v => v.Validate(taxaServico)).Returns(new ValidationResult());

            Result resultado = servicoTaxaServico.Editar(taxaServico);

            resultado.IsSuccess.Should().BeFalse();
        }
        [TestMethod]
       
        public void DeveEditarTaxaServicoValida()
        {
            var taxaServico = new TaxaServico("Taxa Servico", 10, "Plano A");
            mockRepositorioTaxaServico.Setup(r => r.Editar(taxaServico));
            mockValidadorTaxaServico.Setup(v => v.Validate(taxaServico)).Returns(new ValidationResult());

            Result resultado = servicoTaxaServico.Editar(taxaServico);

            resultado.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveEditarTaxaServicoComInformacoesInvalidas()
        {
            var taxaServicoInvalida = new TaxaServico("Taxa Servico", 10, "Plano B");
            mockRepositorioTaxaServico.Setup(r => r.Editar(taxaServicoInvalida));
            mockValidadorTaxaServico.Setup(v => v.Validate(taxaServicoInvalida)).Returns(new ValidationResult(new List<ValidationFailure>
        {
            new ValidationFailure("Preco", "Preço inválido")
        }));

            Result resultado = servicoTaxaServico.Editar(taxaServicoInvalida);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void NaoDeveEditarTaxaServicoComNomeDuplicado()
        {
            var taxaServicoExistente = new TaxaServico("Taxa Servico Existente", 15, "Plano C");
            mockRepositorioTaxaServico.Setup(r => r.SelecionarPorNome(taxaServicoExistente.Nome)).Returns(taxaServicoExistente);

            var taxaServico = new TaxaServico("Taxa Servico Existente", 20, "Plano D");
            mockValidadorTaxaServico.Setup(v => v.Validate(taxaServico)).Returns(new ValidationResult());

            Result resultado = servicoTaxaServico.Editar(taxaServico);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void NaoDeveEditarTaxaServicoComIdInvalido()
        {
            var taxaServico = new TaxaServico("Taxa Servico", 10, "Plano E");
            mockValidadorTaxaServico.Setup(v => v.Validate(taxaServico)).Returns(new ValidationResult());

            Result resultado = servicoTaxaServico.Editar(taxaServico);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void DeveExcluirTaxaServicoExistente()
        {
            var taxaServicoExistente = new TaxaServico("Taxa Servico Existente", 15, "Plano C");
            mockRepositorioTaxaServico.Setup(r => r.Existe(taxaServicoExistente)).Returns(true);
            mockRepositorioTaxaServico.Setup(r => r.Excluir(taxaServicoExistente));

            Result resultado = servicoTaxaServico.Excluir(taxaServicoExistente);

            resultado.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveExcluirTaxaServicoInexistente()
        {
            var taxaServicoInexistente = new TaxaServico("Taxa Servico Inexistente", 20, "Plano D");
            mockRepositorioTaxaServico.Setup(r => r.Existe(taxaServicoInexistente)).Returns(false);

            Result resultado = servicoTaxaServico.Excluir(taxaServicoInexistente);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void NaoDeveExcluirTaxaServicoRelacionadaComCliente()
        {
            var taxaServicoRelacionada = new TaxaServico("Taxa Servico Relacionada", 25, "Plano E");
            mockRepositorioTaxaServico.Setup(r => r.Existe(taxaServicoRelacionada)).Returns(true);
            mockRepositorioTaxaServico.Setup(r => r.Excluir(taxaServicoRelacionada)).Throws(new Exception("Erro no banco de dados"));

            Result resultado = servicoTaxaServico.Excluir(taxaServicoRelacionada);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void DeveTentarExcluirTaxaServicoECapturarErroBanco()
        {
            var taxaServicoParaExcluir = new TaxaServico("Taxa Servico Excluir", 30, "Plano F");
            mockRepositorioTaxaServico.Setup(r => r.Existe(taxaServicoParaExcluir)).Returns(true);
            mockRepositorioTaxaServico.Setup(r => r.Excluir(taxaServicoParaExcluir)).Throws(new DbUpdateException("Erro no banco de dados"));

            Result resultado = servicoTaxaServico.Excluir(taxaServicoParaExcluir);

            resultado.IsSuccess.Should().BeFalse();
        }





    }
}

