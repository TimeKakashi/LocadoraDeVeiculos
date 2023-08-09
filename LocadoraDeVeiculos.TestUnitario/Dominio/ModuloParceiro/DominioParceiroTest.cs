using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestUnitario.Dominio.ModuloParceiro
{
    [TestClass]
    public class DominioParceiroTest
    {
        private IValidator<Parceiro> validadorParceiro;

        [TestInitialize]
        public void Inicializar()
        {
            validadorParceiro = new ValidadorParceiro();
        }

        [TestMethod]
        public void DeveCriarParceiroValido()
        {
            var parceiro = new Parceiro("Parceiro Teste");

            ValidationResult resultado = validadorParceiro.Validate(parceiro);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveFalharAoCriarParceiroComNomeNulo()
        {
            var parceiro = new Parceiro(null);

            ValidationResult resultado = validadorParceiro.Validate(parceiro);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarParceiroComNomeVazio()
        {
            var parceiro = new Parceiro("");

            ValidationResult resultado = validadorParceiro.Validate(parceiro);
            resultado.IsValid.Should().BeFalse();
        }

      


        [TestMethod]
        public void DeveCompararParceirosPorIdENomeDiferentes()
        {
            var parceiro1 = new Parceiro(Guid.NewGuid(), "Parceiro A");
            var parceiro2 = new Parceiro(Guid.NewGuid(), "Parceiro B");

            Assert.IsFalse(parceiro1.Equals(parceiro2));
        }

        [TestMethod]
        public void DeveRetornarNomeCorretoAoChamarToString()
        {
            var parceiro = new Parceiro("Parceiro C");

            Assert.AreEqual("Parceiro C", parceiro.ToString());
        }

       

        [TestMethod]
        public void DeveCriarParceiroComIdENome()
        {
            var parceiro = new Parceiro(Guid.NewGuid(), "Parceiro E");

            ValidationResult resultado = validadorParceiro.Validate(parceiro);
            resultado.IsValid.Should().BeTrue();
        }

       

        [TestMethod]
        public void DeveFalharAoCriarParceiroComIdENomeVazio()
        {
            var parceiro = new Parceiro(Guid.NewGuid(), "");

            ValidationResult resultado = validadorParceiro.Validate(parceiro);
            resultado.IsValid.Should().BeFalse();
        }
    }


}
