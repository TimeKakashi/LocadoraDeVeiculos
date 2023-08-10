using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestUnitario.Dominio.ModuloPlanoCobranca
{
    [TestClass]
    public class DominioPlanoCobrancaTest
    {
        private IValidator<PlanoCobranca> validadorPlanoCobranca;

        [TestInitialize]
        public void Inicializar()
        {
            validadorPlanoCobranca = new ValidadorPlanoCobranca();
        }

        [TestMethod]
        public void DeveCriarPlanoCobrancaDiariaValido()
        {
            var plano = new PlanoCobranca(planoCobranca.Diaria, 50, 0);

            ValidationResult resultado = validadorPlanoCobranca.Validate(plano);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveCriarPlanoCobrancaControladoValido()
        {
            var plano = new PlanoCobranca(planoCobranca.Controlado, 100, 0.5m, 100, null);

            ValidationResult resultado = validadorPlanoCobranca.Validate(plano);
            resultado.IsValid.Should().BeTrue();
        }
       



        [TestMethod]
        public void DeveFalharAoCriarPlanoCobrancaComValorDiariaNegativo()
        {
            var plano = new PlanoCobranca(planoCobranca.Diaria, -50, 0);

            ValidationResult resultado = validadorPlanoCobranca.Validate(plano);
            resultado.IsValid.Should().BeFalse();
        }

   
       
    }

}
