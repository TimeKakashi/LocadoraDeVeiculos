using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public interface IRepositorioFuncionario : IRepositorioBase<Funcionario>
    {
        Funcionario SelecionarPorNome(string nome);

        void Editar(Funcionario registro);
    }
}
