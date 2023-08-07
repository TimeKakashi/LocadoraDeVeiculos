using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

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
