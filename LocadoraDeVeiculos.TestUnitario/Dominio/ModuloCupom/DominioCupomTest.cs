using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestUnitario.Dominio.ModuloCupom
{
    [TestClass]
    public class DominioCupomTest
    {
        private IValidator<Cupom> validadorCupom;

        [TestInitialize]
        public void Inicializar()
        {
            validadorCupom = new ValidadorCupom();
        }

        [TestMethod]
        public void DeveCriarCupomValido()
        {
            var parceiro = new Parceiro("Parceiro A");
            var cupom = new Cupom(Guid.NewGuid(),"Cupom X", 10, DateTime.Now.AddDays(7), parceiro);

            ValidationResult resultado = validadorCupom.Validate(cupom);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveFalharAoCriarCupomComNomeMenorQue4Caracteres()
        {
            var parceiro = new Parceiro("Parceiro A");
            var cupom = new Cupom(Guid.NewGuid(),"ABC", 10, DateTime.Now.AddDays(7), parceiro);

            ValidationResult resultado = validadorCupom.Validate(cupom);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarCupomComValorZero()
        {
            var parceiro = new Parceiro("Parceiro A");
            var cupom = new Cupom(Guid.NewGuid(),"Cupom X", 0, DateTime.Now.AddDays(7), parceiro);

            ValidationResult resultado = validadorCupom.Validate(cupom);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarCupomComDataDeValidadeNula()
        {
            var parceiro = new Parceiro("Parceiro A");
            var cupom = new Cupom(Guid.NewGuid(),"Cupom X", 10, DateTime.MinValue, parceiro);

            ValidationResult resultado = validadorCupom.Validate(cupom);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarCupomComParceiroNulo()
        {
            var cupom = new Cupom(Guid.NewGuid(),"Cupom X", 10, DateTime.Now.AddDays(7), null);

            ValidationResult resultado = validadorCupom.Validate(cupom);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void DeveFalharAoCriarCupomComValorNegativo()
        {
            var parceiro = new Parceiro("Parceiro A");
            var cupom = new Cupom(Guid.NewGuid(),"Cupom X", -10, DateTime.Now.AddDays(7), parceiro);

            ValidationResult resultado = validadorCupom.Validate(cupom);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveCriarCupomComNomeValido()
        {
            var parceiro = new Parceiro("Parceiro A");
            var cupom = new Cupom(Guid.NewGuid(),"Cupom XYZ", 10, DateTime.Now.AddDays(7), parceiro);

            ValidationResult resultado = validadorCupom.Validate(cupom);
            resultado.IsValid.Should().BeTrue();
        }
        [TestMethod]
        public void DeveFalharAoCriarCupomComDataDeValidadeNoPassado()
        {
            var parceiro = new Parceiro("Parceiro A");
            var dataPassada = DateTime.Now.AddDays(-1);
            var cupom = new Cupom(Guid.NewGuid(),"Cupom X", 10, dataPassada, parceiro);

            ValidationResult resultado = validadorCupom.Validate(cupom);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveCriarCupomComValorMaximo()
        {
            var parceiro = new Parceiro("Parceiro A");
            var cupom = new Cupom(Guid.NewGuid(),"Cupom X", decimal.MaxValue, DateTime.Now.AddDays(7), parceiro);

            ValidationResult resultado = validadorCupom.Validate(cupom);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveFalharAoCriarCupomComNomeNulo()
        {
            var parceiro = new Parceiro("Parceiro A");
            var cupom = new Cupom(Guid.NewGuid(),null, 10, DateTime.Now.AddDays(7), parceiro);

            ValidationResult resultado = validadorCupom.Validate(cupom);
            resultado.IsValid.Should().BeFalse();
        }

    }

}
