using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestUnitario.Dominio.ModuloAutomovel
{
    [TestClass]
   
    public class DominioAutomovelTest
    {
        private IValidator<Veiculo> validadorAutomovel;

        [TestInitialize]
        public void Inicializar()
        {
            validadorAutomovel = new ValidadorAutomovel();
        }
        [TestMethod]
        public void DeveCriarAutomovelValido()
        {
            var grupoAutomovel = new GrupoAutomovel("Grupo A");
            var automovel = new Veiculo("Modelo X", "Marca Y", "Azul", new byte[0], 10000, "ABC1234", EnumCombusteivel.Gasolina, 50, grupoAutomovel, false);

            ValidationResult resultado = validadorAutomovel.Validate(automovel);
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void DeveFalharAoCriarAutomovelSemGrupo()
        {
            var automovel = new Veiculo("Modelo X", "Marca Y", "Azul", new byte[0], 10000, "ABC1234", EnumCombusteivel.Gasolina, 50, null, false);

            ValidationResult resultado = validadorAutomovel.Validate(automovel);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void DeveFalharAoCriarAutomovelComKilometragemNegativa()
        {
            var grupoAutomovel = new GrupoAutomovel("Grupo A");
            var automovel = new Veiculo("Modelo X", "Marca Y", "ABC1234", new byte[0], -100, "Azul", EnumCombusteivel.Gasolina, 50, grupoAutomovel, false);

            ValidationResult resultado = validadorAutomovel.Validate(automovel);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarAutomovelComPlacaInvalida()
        {
            var grupoAutomovel = new GrupoAutomovel("Grupo A");
            var automovel = new Veiculo("Modelo X", "Marca Y", "12345", new byte[0], 10000, "Azul", EnumCombusteivel.Gasolina, 50, grupoAutomovel, false);

            ValidationResult resultado = validadorAutomovel.Validate(automovel);
            resultado.IsValid.Should().BeFalse();
        }
        [TestMethod]
        public void DeveFalharAoCriarAutomovelComModeloNulo()
        {
            var grupoAutomovel = new GrupoAutomovel("Grupo A");
            var automovel = new Veiculo(null, "Marca Y", "Azul", new byte[0], 10000, "ABC1234", EnumCombusteivel.Gasolina, 50, grupoAutomovel, false);

            ValidationResult resultado = validadorAutomovel.Validate(automovel);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarAutomovelComMarcaNula()
        {
            var grupoAutomovel = new GrupoAutomovel("Grupo A");
            var automovel = new Veiculo("Modelo X", null, "Azul", new byte[0], 10000, "ABC1234", EnumCombusteivel.Gasolina, 50, grupoAutomovel, false);

            ValidationResult resultado = validadorAutomovel.Validate(automovel);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarAutomovelComCorNula()
        {
            var grupoAutomovel = new GrupoAutomovel("Grupo A");
            var automovel = new Veiculo("Modelo X", "Marca Y", null, new byte[0], 10000, "ABC1234", EnumCombusteivel.Gasolina, 50, grupoAutomovel, false);

            ValidationResult resultado = validadorAutomovel.Validate(automovel);
            resultado.IsValid.Should().BeFalse();
        }

     
        [TestMethod]
        public void DeveFalharAoCriarAutomovelComCapacidadeEmLitrosMenorQue30()
        {
            var grupoAutomovel = new GrupoAutomovel("Grupo A");
            var automovel = new Veiculo("Modelo X", "Marca Y", "Azul", new byte[0], 10000, "ABC1234", EnumCombusteivel.Gasolina, 20, grupoAutomovel, false);

            ValidationResult resultado = validadorAutomovel.Validate(automovel);
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void DeveFalharAoCriarAutomovelComImagemMaiorQue2Mb()
        {
            var grupoAutomovel = new GrupoAutomovel("Grupo A");
            var imagemGrande = new byte[3 * 1024 * 1024]; // 3Mb
            var automovel = new Veiculo("Modelo X", "Marca Y", "Azul", imagemGrande, 10000, "ABC1234", EnumCombusteivel.Gasolina, 50, grupoAutomovel, false);

            ValidationResult resultado = validadorAutomovel.Validate(automovel);
            resultado.IsValid.Should().BeFalse();
        }





    }

}
