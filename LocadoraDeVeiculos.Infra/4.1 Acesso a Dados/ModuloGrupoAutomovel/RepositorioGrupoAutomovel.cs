using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloGrupoAutomovel
{
    public class RepositorioGrupoAutomovel : RepositorioBaseEmOrm<GrupoAutomovel>
    {
        public RepositorioGrupoAutomovel(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }
    }
}
