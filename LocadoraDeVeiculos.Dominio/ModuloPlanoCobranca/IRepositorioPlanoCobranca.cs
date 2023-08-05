using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorioBase<PlanoCobranca>
    {
        void Editar(PlanoCobranca registro);
    }
}
