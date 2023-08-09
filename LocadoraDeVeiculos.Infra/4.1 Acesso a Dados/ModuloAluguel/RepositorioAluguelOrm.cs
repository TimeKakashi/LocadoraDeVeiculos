using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloAluguel
{
    public class RepositorioAluguelOrm : RepositorioBaseEmOrm<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public override List<Aluguel> SelecionarTodos(bool Insercao = false, bool Insercao2 = false)
        {
            return registros.Include(x => x.PlanoCobranca)
                .Include(x => x.Funcionario)
                .Include(x => x.Cliente)
                .Include(x => x.GrupoAutomovel)
                .Include(x => x.Cupom)
                .Include(x => x.Condutor)
                .Include(x => x.Veiculo)
                .Include(x => x.TaxasServico)
                .ToList();
        }
    }
}
