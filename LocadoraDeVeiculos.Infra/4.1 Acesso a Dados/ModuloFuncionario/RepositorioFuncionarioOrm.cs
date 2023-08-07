using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm : RepositorioBaseEmOrm<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionarioOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public Funcionario SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }

        public override void Editar(Funcionario registro)
        {
            Funcionario funcionarioRegistrado = registros.FirstOrDefault(x => x.Id == registro.Id);

            funcionarioRegistrado.Salario = registro.Salario;
            funcionarioRegistrado.DataEntrada = registro.DataEntrada;
            funcionarioRegistrado.Nome = registro.Nome;

            dbContext.SaveChanges();
        }

    }
}
