using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloGrupoAutomovel
{
    public class RepositorioGrupoAutomovel : RepositorioBaseEmOrm<GrupoAutomovel>, IReposisotiroGrupoAutomovel
    {
        public RepositorioGrupoAutomovel(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public GrupoAutomovel SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
