using FluentAssertions;
using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloParceiro;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxaServico;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.TestUnitario.Compartilhado;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestUnitario.Aplicacao.ModuloParceiro
{
    [TestClass]
    public class ServicoParceiroTest
    {
        private ServicoParceiro servicoParceiro;
        private Mock<IRepositorioParceiro> mockRepositorioParceiro;
        private Mock<IValidadorParceiro> mockValidadorParceiro;
        private Mock<IContextoPersistencia> ctx;


        [TestInitialize]
        public void Inicializar()
        {
            mockRepositorioParceiro = new Mock<IRepositorioParceiro>();
            mockValidadorParceiro = new Mock<IValidadorParceiro>();
            ctx = new Mock<IContextoPersistencia>();
            servicoParceiro = new ServicoParceiro(mockRepositorioParceiro.Object, mockValidadorParceiro.Object, ctx.Object);
        }
        [TestMethod]
        public void DeveInserirParceiroValido()
        {
            var parceiro = new Parceiro("Novo Parceiro");
            mockRepositorioParceiro.Setup(r => r.Inserir(parceiro));
            mockValidadorParceiro.Setup(v => v.Validate(parceiro)).Returns(new ValidationResult());

            Result resultado = servicoParceiro.Inserir(parceiro);

            resultado.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveInserirParceiroInvalido()
        {
            var parceiro = new Parceiro("Parceiro Inválido");
            mockValidadorParceiro.Setup(v => v.Validate(parceiro)).Returns(new ValidationResult(new List<ValidationFailure>
{
    new ValidationFailure("Nome", "Nome é obrigatório")
}));

            Result resultado = servicoParceiro.Inserir(parceiro);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void NaoDeveInserirParceiroComNomeDuplicado()
        {
            var parceiroExistente = new Parceiro(Guid.NewGuid(), "primeiro");
            var Inserido = new Parceiro(Guid.NewGuid(), "primeiro");

            mockRepositorioParceiro.Setup(r => r.SelecionarPorNome(Inserido.Nome)).Returns(parceiroExistente);

            Result resultado = servicoParceiro.Inserir(Inserido);

            resultado.IsSuccess.Should().BeFalse();
        }



        [TestMethod]
        public void DeveEditarParceiroValido()
        {
            var parceiro = new Parceiro("Parceiro X");
            mockRepositorioParceiro.Setup(r => r.Editar(parceiro));
            mockValidadorParceiro.Setup(v => v.Validate(parceiro)).Returns(new ValidationResult());

            Result resultado = servicoParceiro.Editar(parceiro);

            resultado.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveEditarParceiroInvalido()
        {
            var parceiro = new Parceiro("Parceiro Y");
            mockValidadorParceiro.Setup(v => v.Validate(parceiro)).Returns(new ValidationResult(new List<ValidationFailure>
        {
            new ValidationFailure("Nome", "Nome é obrigatório")
        }));

            Result resultado = servicoParceiro.Editar(parceiro);

            resultado.IsSuccess.Should().BeFalse();
        }
        [TestMethod]
        public void DeveEditarParceiroExistente()
        {
            var parceiro = new Parceiro("Parceiro Existente");
            mockRepositorioParceiro.Setup(r => r.Editar(parceiro));
            mockValidadorParceiro.Setup(v => v.Validate(parceiro)).Returns(new ValidationResult());

            Result resultado = servicoParceiro.Editar(parceiro);

            resultado.IsSuccess.Should().BeTrue();
        }
        
        [TestMethod]
        public void NaoDeveEditarParceiroComInformacoesInvalidas()
        {
            var parceiro = new Parceiro("Parceiro Invalido");
            mockRepositorioParceiro.Setup(r => r.Editar(parceiro));
            mockValidadorParceiro.Setup(v => v.Validate(parceiro)).Returns(new ValidationResult(new List<ValidationFailure> { new ValidationFailure("Nome", "Nome inválido") }));

            Result resultado = servicoParceiro.Editar(parceiro);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void NaoDeveEditarParceiroRelacionadoComOutraEntidade()
        {
            var parceiro = new Parceiro("Parceiro Relacionado");
            mockRepositorioParceiro.Setup(r => r.Editar(parceiro));
            mockValidadorParceiro.Setup(v => v.Validate(parceiro)).Returns(new ValidationResult());

            mockRepositorioParceiro.Setup(r => r.Existe(parceiro)).Returns(true);
            mockRepositorioParceiro.Setup(r => r.Editar(It.IsAny<Parceiro>())).Throws(SqlExceptionCreator.NewSqlException(errorMessage: "Mensagem de erro relacionada a chave estrangeira"));

            Result resultado = servicoParceiro.Editar(parceiro);

            resultado.IsSuccess.Should().BeFalse();
        }
        [TestMethod]
        public void DeveTentarEditarParceiroECapturarErroNoBanco()
        {
            var parceiro = new Parceiro(Guid.NewGuid(), "Parceiro Relacionado") ;

            mockRepositorioParceiro.Setup(x => x.Editar(It.IsAny<Parceiro>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = servicoParceiro.Editar(parceiro);

            resultado.IsSuccess.Should().BeFalse();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar parceiro.");
        }

        [TestMethod]
        public void DeveExcluirParceiroExistente()
        {
            var parceiro = new Parceiro("Parceiro Existente");
            mockRepositorioParceiro.Setup(r => r.Existe(parceiro)).Returns(true);
            mockRepositorioParceiro.Setup(r => r.Excluir(parceiro));

            Result resultado = servicoParceiro.Excluir(parceiro);

            resultado.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveExcluirParceiroInexistente()
        {
            var parceiro = new Parceiro("Parceiro Inexistente");
            mockRepositorioParceiro.Setup(r => r.Existe(parceiro)).Returns(false);

            Result resultado = servicoParceiro.Excluir(parceiro);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void DeveTentarExcluirParceiroECapturarErroNoBanco()
        {
            var parceiro = new Parceiro("Parceiro Com Erro");
            mockRepositorioParceiro.Setup(r => r.Existe(parceiro)).Throws(SqlExceptionCreator.NewSqlException());

            Result resultado = servicoParceiro.Excluir(parceiro);

            resultado.IsSuccess.Should().BeFalse();
        }

    }
}
