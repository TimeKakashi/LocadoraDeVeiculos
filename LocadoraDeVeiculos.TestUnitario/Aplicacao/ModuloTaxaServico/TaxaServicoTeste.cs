using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxaServico;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.TestUnitario.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;

namespace LocadoraDeVeiculos.TestUnitario.Aplicacao.ModuloTaxaServico
{
    [TestClass]
    public class ServicoTaxaServicoTest
    {
        private ServicoTaxaServico servicoTaxaServico;
        private Mock<IRepositorioTaxaServico> mockRepositorioTaxaServico;
        private Mock<IValidadorTaxaServico> mockValidadorTaxaServico;
        private Mock<IContextoPersistencia> ctx;

        [TestInitialize]
        public void Inicializar()
        {
            mockRepositorioTaxaServico = new Mock<IRepositorioTaxaServico>();
            mockValidadorTaxaServico = new Mock<IValidadorTaxaServico>();
            ctx = new Mock<IContextoPersistencia>();
            servicoTaxaServico = new ServicoTaxaServico(mockRepositorioTaxaServico.Object, mockValidadorTaxaServico.Object, ctx.Object);
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
            var taxaServicoExistente = new TaxaServico(Guid.NewGuid(), "Taxa Servico Existente", 100, "primeiro");
            var Inserido = new TaxaServico(Guid.NewGuid(), "Taxa Servico Existente", 100, "primeiro");

            mockRepositorioTaxaServico.Setup(r => r.SelecionarPorNome(taxaServicoExistente.Nome)).Returns(Inserido);

            //var novaTaxaServico = new TaxaServico("Taxa Servico Existente");
            //mockValidadorTaxaServico.Setup(v => v.Validate(novaTaxaServico)).Returns(new ValidationResult());

            Result resultado = servicoTaxaServico.Inserir(taxaServicoExistente);

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
            var taxaServicoExistente = new TaxaServico(Guid.NewGuid(), "Taxa Servico Existente", 15, "Plano C");
            var taxanova = new TaxaServico(Guid.NewGuid(), "Taxa Servico Existente", 15, "Plano C");

            mockRepositorioTaxaServico.Setup(r => r.SelecionarPorNome(taxanova.Nome)).Returns(taxaServicoExistente);

            Result resultado = servicoTaxaServico.Editar(taxanova);

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
            var taxaServicoRelacionada = new TaxaServico(Guid.NewGuid(), "Taxa Servico Relacionada", 25, "Plano E");

            mockRepositorioTaxaServico.Setup(x => x.Existe(taxaServicoRelacionada))
              .Returns(() =>
              {
                  return true;
              });

            mockRepositorioTaxaServico.Setup(x => x.Excluir(It.IsAny<TaxaServico>()))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TaxaServico_TBAluguel");
                });


            Result resultado = servicoTaxaServico.Excluir(taxaServicoRelacionada);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void DeveTentarExcluirTaxaServicoECapturarErroBanco()
        {
            var taxaServicoRelacionada = new TaxaServico(Guid.NewGuid(), "Taxa Servico Relacionada", 25, "Plano E");

            mockRepositorioTaxaServico.Setup(x => x.Existe(taxaServicoRelacionada))
              .Returns(() =>
              {
                  return true;
              });

            mockRepositorioTaxaServico.Setup(x => x.Excluir(It.IsAny<TaxaServico>()))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TaxaServico_TBAluguel");
                });


            Result resultado = servicoTaxaServico.Excluir(taxaServicoRelacionada);

            resultado.Errors[0].Message.Should().Contain("Esta TaxaServico está relacionada com um cliente e não pode ser excluída");
        }
    }
}

