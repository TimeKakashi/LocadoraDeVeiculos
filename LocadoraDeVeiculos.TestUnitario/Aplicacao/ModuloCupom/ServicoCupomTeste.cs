using FluentAssertions;
using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Aplicacao.ModuloCupom;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.TestUnitario.Compartilhado;
using Moq;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestUnitario.Aplicacao.ModuloCupom
{
    [TestClass]
    public class ServicoCupomTeste
    {
        private ServicoCupom servicoCupom;
        private Mock<IRepositorioCupom> mockRepositorioCupom;
        private Mock<IValidadorCupom> mockValidadorCupom;
        private Mock<IContextoPersistencia> ctx;

        [TestInitialize]
        public void Inicializar()
        {
            ctx = new Mock<IContextoPersistencia>();
            mockRepositorioCupom = new Mock<IRepositorioCupom>();
            mockValidadorCupom = new Mock<IValidadorCupom>();
            servicoCupom = new ServicoCupom(mockRepositorioCupom.Object, mockValidadorCupom.Object, ctx.Object);
        }
        private Cupom cupom;

        public ServicoCupomTeste()
        {
            this.cupom = new Cupom(Guid.NewGuid(), "Cupom", 10, DateTime.Now.AddDays(1), new Parceiro("Parceiro"));

        }

        [TestMethod]
        public void DeveEditarCupomValido()
        {
            
            mockRepositorioCupom.Setup(r => r.Editar(cupom));
            mockValidadorCupom.Setup(v => v.Validate(cupom)).Returns(new ValidationResult());

           
            Result resultado = servicoCupom.Editar(cupom);

          
            resultado.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveEditarCupomComErroDeValidacao()
        {
            
            var cupom = new Cupom(Guid.NewGuid(),"Cupom", 20, DateTime.Now.AddDays(1), new Parceiro("Parceiro"));
            mockRepositorioCupom.Setup(r => r.Editar(cupom));
            mockValidadorCupom.Setup(v => v.Validate(cupom)).Returns(new ValidationResult(new List<ValidationFailure>
        {
            new ValidationFailure("Valor", "Valor inválido")
        }));

            Result resultado = servicoCupom.Editar(cupom);

           
            resultado.IsSuccess.Should().BeFalse();
        }

       

      
        [TestMethod]
        public void DeveInserirCupomValido()
        {
            var cupom = new Cupom(Guid.NewGuid(),"Cupom", 5, DateTime.Now.AddDays(30), new Parceiro("Parceiro"));
            mockRepositorioCupom.Setup(r => r.Inserir(cupom));
            mockValidadorCupom.Setup(v => v.Validate(cupom)).Returns(new ValidationResult());

            Result resultado = servicoCupom.Inserir(cupom);

            resultado.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveInserirCupomComErroDeValidacao()
        {
            var cupom = new Cupom(Guid.NewGuid(),"Cupom", 10, DateTime.Now.AddDays(30), new Parceiro("Parceiro"));
            mockRepositorioCupom.Setup(r => r.Inserir(cupom));
            mockValidadorCupom.Setup(v => v.Validate(cupom)).Returns(new ValidationResult(new List<ValidationFailure>
        {
            new ValidationFailure("Erro", "Nome errado")
        }));

            Result resultado = servicoCupom.Inserir(cupom);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void NaoDeveInserirCupomComNomeDuplicado()
        {
            var cupom = new Cupom(Guid.NewGuid(),"Cupom", 15, DateTime.Now.AddDays(30), new Parceiro("Parceiro"));

            mockRepositorioCupom.Setup(r => r.SelecionarPorNome(cupom.Nome)).Returns(new Cupom(Guid.NewGuid(),"Cupom", 20, DateTime.Now.AddDays(30), new Parceiro("Parceiro")));

            mockValidadorCupom.Setup(v => v.Validate(cupom)).Returns(new ValidationResult());

            Result resultado = servicoCupom.Inserir(cupom);

            resultado.IsSuccess.Should().BeFalse();
        }
        [TestMethod]
        public void DeveExcluirCupomExistente()
        {
            var cupom = new Cupom(Guid.NewGuid(),"Cupom", 5, DateTime.Now.AddDays(30), new Parceiro("Parceiro"));
            mockRepositorioCupom.Setup(r => r.Existe(cupom)).Returns(true);

            Result resultado = servicoCupom.Excluir(cupom);

            resultado.IsSuccess.Should().BeTrue();
        }

        [TestMethod]
        public void NaoDeveExcluirCupomInexistente()
        {
            var cupom = new Cupom(Guid.NewGuid(),"Cupom", 10, DateTime.Now.AddDays(30), new Parceiro("Parceiro"));
            mockRepositorioCupom.Setup(r => r.Existe(cupom)).Returns(false);

            Result resultado = servicoCupom.Excluir(cupom);

            resultado.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void NaoDeveExcluirCupomComRelacionamentoComAluguel()
        {
            var cupom = new Cupom(Guid.NewGuid(),"Cupom", 15, DateTime.Now.AddDays(30), new Parceiro("Parceiro"));
            mockRepositorioCupom.Setup(r => r.Existe(cupom)).Returns(true);
            mockRepositorioCupom.Setup(r => r.Excluir(cupom)).Throws(SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBCupom_TBAluguel"));

            Result resultado = servicoCupom.Excluir(cupom);

            resultado.IsSuccess.Should().BeFalse();
        }
        [TestMethod]
        public void NaoDeveExcluirCupomNaoExistente()
        {

            var cupom = new Cupom(Guid.NewGuid(),"Cupom", 25, DateTime.Now.AddDays(1), new Parceiro("Parceiro"));
            mockRepositorioCupom.Setup(r => r.Existe(cupom)).Returns(false);


            Result resultado = servicoCupom.Excluir(cupom);


            resultado.IsSuccess.Should().BeFalse();
        }
        [TestMethod]
        public void NaoDeveEditarCupomInvalido()
        {
            var cupom = new Cupom(Guid.NewGuid(),"Cupom", -15, DateTime.Now.AddDays(1), new Parceiro("Parceiro"));
            mockValidadorCupom.Setup(v => v.Validate(cupom)).Returns(new ValidationResult(new List<ValidationFailure>
        {
            new ValidationFailure("Valor", "Valor deve ser maior que zero")
        }));

            Result resultado = servicoCupom.Editar(cupom);

            resultado.IsSuccess.Should().BeFalse();
        }
    }

}
