using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestUnitario.Dominio.ModuloFuncionario
{
    [TestClass]
    public class DominioFuncionarioTest
    {
        public DominioFuncionarioTest()
        {
            var funcionario = new Funcionario("Joao", 1000, DateTime.Now);
        }
    }
}
