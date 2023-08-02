using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloParceiro
{
    public interface IRepositorioParceiro : IRepositorioBase<Parceiro>
    {

        public Parceiro SelecionarPorNome(string nome);
    }
}