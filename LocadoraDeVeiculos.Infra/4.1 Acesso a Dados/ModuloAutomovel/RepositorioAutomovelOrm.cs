using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloAutomovel
{
    public class RepositorioAutomovelOrm : RepositorioBaseEmOrm<Veiculo>, IRepositorioAutomovel
    {
        public RepositorioAutomovelOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }
    }
}
