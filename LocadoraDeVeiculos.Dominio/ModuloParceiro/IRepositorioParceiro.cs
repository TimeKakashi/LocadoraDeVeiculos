using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraDeVeiculos.Dominio.ModuloParceiro
{
    public interface IRepositorioParceiro : IRepositorioBase<Parceiro>
    {

        Parceiro SelecionarPorNome(string nome);

        void Editar(Parceiro registro);
    }
}