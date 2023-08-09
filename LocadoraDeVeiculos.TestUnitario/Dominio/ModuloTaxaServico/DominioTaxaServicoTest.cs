using FluentAssertions;
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
        TaxaServico taxaServico;

        public DominioTaxaServicoTest()
        {
            //taxaServico = new("Limpeza", 20, TipoPlanoCalculoEnum.precoFixo);
        }

        [TestMethod]
        public void Nome_deve_ser_diferente_de_null()
        {
            taxaServico.Nome.Should().NotBeNull();
        }
    }
}
