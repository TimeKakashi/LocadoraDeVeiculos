using FluentAssertions;
using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
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

        [TestInitialize]
        public void Inicializar()
        {
            mockRepositorioParceiro = new Mock<IRepositorioParceiro>();
            mockValidadorParceiro = new Mock<IValidadorParceiro>();
            servicoParceiro = new ServicoParceiro(mockRepositorioParceiro.Object, mockValidadorParceiro.Object);
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
            var parceiro = new Parceiro("Parceiro Duplicado");
            mockValidadorParceiro.Setup(v => v.Validate(parceiro)).Returns(new ValidationResult());
            mockRepositorioParceiro.Setup(r => r.SelecionarPorNome(parceiro.Nome)).Returns((string nome) =>
            {
                if (nome == parceiro.Nome)
                {
                    return new Parceiro("Outro Parceiro");
                }
                return null;
            });

            Result resultado = servicoParceiro.Inserir(parceiro);

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
        public void NaoDeveEditarParceiroInexistente()
        {
            var parceiro = new Parceiro("Parceiro Inexistente");
            mockRepositorioParceiro.Setup(r => r.Editar(parceiro));
            mockValidadorParceiro.Setup(v => v.Validate(parceiro)).Returns(new ValidationResult());

            Result resultado = servicoParceiro.Editar(parceiro);

            resultado.IsSuccess.Should().BeFalse();
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
            var parceiro = new Parceiro("Parceiro Com Erro");
            mockRepositorioParceiro.Setup(r => r.Editar(parceiro));
            mockValidadorParceiro.Setup(v => v.Validate(parceiro)).Returns(new ValidationResult());

            
            mockRepositorioParceiro.Setup(r => r.Existe(parceiro)).Returns(false);

            Result resultado = servicoParceiro.Editar(parceiro);

            resultado.IsSuccess.Should().BeFalse();
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
