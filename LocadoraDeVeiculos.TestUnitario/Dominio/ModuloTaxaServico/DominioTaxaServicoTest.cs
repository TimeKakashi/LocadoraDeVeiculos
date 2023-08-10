using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestUnitario.Dominio.ModuloTaxaServico
{
    [TestClass]
    public class DominioTaxaServicoTest
    {
        private IValidator<TaxaServico> validadorTaxaServico;

        [TestInitialize]
        public void Inicializar()
        {
            validadorTaxaServico = new ValidadorTaxaServico();
        }

        [TestMethod]
        public void DeveCriarTaxaServicoValida()
        {
            var taxaServico = new TaxaServico("Taxa A", 50, "Plano X");

            ValidationResult resultado = validadorTaxaServico.Validate(taxaServico);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveFalharAoCriarTaxaServicoComNomeNulo()
        {
            var taxaServico = new TaxaServico(null, 50, "Plano X");

            ValidationResult resultado = validadorTaxaServico.Validate(taxaServico);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarTaxaServicoComPrecoZero()
        {
            var taxaServico = new TaxaServico("Taxa B", 0, "Plano Y");

            ValidationResult resultado = validadorTaxaServico.Validate(taxaServico);
            resultado.IsValid.Should().BeFalse();
        }

       

        [TestMethod]
        public void DeveFalharAoCriarTaxaServicoComNomeVazio()
        {
            var taxaServico = new TaxaServico("", 50, "Plano Z");

            ValidationResult resultado = validadorTaxaServico.Validate(taxaServico);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarTaxaServicoComPrecoNegativo()
        {
            var taxaServico = new TaxaServico("Taxa C", -50, "Plano X");

            ValidationResult resultado = validadorTaxaServico.Validate(taxaServico);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void DeveFalharAoCriarTaxaServicoComPlanoNulo()
        {
            var taxaServico = new TaxaServico("Taxa D", 75, null);

            ValidationResult resultado = validadorTaxaServico.Validate(taxaServico);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveCriarTaxaServicoComNomeMaximoPermitido()
        {
            var nomeMaximo = new string('A', 100); 
            var taxaServico = new TaxaServico(nomeMaximo, 100, "Plano Y");

            ValidationResult resultado = validadorTaxaServico.Validate(taxaServico);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveFalharAoCriarTaxaServicoComNomeMuitoLongo()
        {
            var nomeMuitoLongo = new string('A', 101); 
            var taxaServico = new TaxaServico(nomeMuitoLongo, 100, "Plano Z");

            ValidationResult resultado = validadorTaxaServico.Validate(taxaServico);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveCriarTaxaServicoComPrecoDecimalMaximo()
        {
            var taxaServico = new TaxaServico("Taxa E", decimal.MaxValue, "Plano X");

            ValidationResult resultado = validadorTaxaServico.Validate(taxaServico);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveFalharAoCriarTaxaServicoComPrecoDecimalNegativo()
        {
            var taxaServico = new TaxaServico("Taxa F", -10, "Plano Y");

            ValidationResult resultado = validadorTaxaServico.Validate(taxaServico);
            resultado.IsValid.Should().BeFalse();
        }

    }

}
