using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel
{
    public interface IReposisotiroGrupoAutomovel : IRepositorioBase<GrupoAutomovel>
    {
        GrupoAutomovel SelecionarPorNome(string nome);

        List<GrupoAutomovel> SelecionarTodos(bool Veiculos = false, bool Planos = false);
    }
}
