using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloAutomovel
{
    public class RepositorioAutomovel : RepositorioBaseEmOrm<Veiculo>, IRepositorioAutomovel
    {
        public RepositorioAutomovel(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }
    }
}
