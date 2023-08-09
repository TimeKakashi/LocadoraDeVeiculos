using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestUnitario.Dominio.ModuloGrupoAutomovel
{
   
    [TestClass]
    public class DominioGrupoAutomovelTest
    {
        private IValidator<GrupoAutomovel> validadorGrupoAutomovel;

        [TestInitialize]
        public void Inicializar()
        {
            validadorGrupoAutomovel = new ValidadorGrupoAutomovel();
        }

        [TestMethod]
        public void DeveCriarGrupoAutomovelValido()
        {
            var grupo = new GrupoAutomovel("Grupo A");

            ValidationResult resultado = validadorGrupoAutomovel.Validate(grupo);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveFalharAoCriarGrupoAutomovelComNomeNulo()
        {
            var grupo = new GrupoAutomovel(null);

            ValidationResult resultado = validadorGrupoAutomovel.Validate(grupo);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveCriarGrupoAutomovelComId()
        {
            var grupo = new GrupoAutomovel("Grupo B", Guid.NewGuid());

            ValidationResult resultado = validadorGrupoAutomovel.Validate(grupo);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveFalharAoCriarGrupoAutomovelComNomeVazio()
        {
            var grupo = new GrupoAutomovel("");

            ValidationResult resultado = validadorGrupoAutomovel.Validate(grupo);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveCompararGruposAutomovelPorIdENome()
        {
            var grupo1 = new GrupoAutomovel("Grupo A", Guid.NewGuid());
            var grupo2 = new GrupoAutomovel("Grupo A", grupo1.Id);

            Assert.IsTrue(grupo1.Equals(grupo2));
        }

        [TestMethod]
        public void DeveCompararGruposAutomovelPorIdENomeDiferentes()
        {
            var grupo1 = new GrupoAutomovel("Grupo A", Guid.NewGuid());
            var grupo2 = new GrupoAutomovel("Grupo B", Guid.NewGuid());

            Assert.IsFalse(grupo1.Equals(grupo2));
        }

        [TestMethod]
        public void DeveRetornarNomeCorretoAoChamarToString()
        {
            var grupo = new GrupoAutomovel("Grupo C");

            Assert.AreEqual("Grupo C", grupo.ToString());
        }

        [TestMethod]
        public void DeveCriarGrupoAutomovelComNomeEVeiculos()
        {
            var grupo = new GrupoAutomovel("Grupo D");
            grupo.Veiculos.Add(new Veiculo("Modelo X", grupo));
            grupo.Veiculos.Add(new Veiculo("Modelo Y", grupo));

            ValidationResult resultado = validadorGrupoAutomovel.Validate(grupo);
            resultado.IsValid.Should().BeTrue();
        }
    }

}
