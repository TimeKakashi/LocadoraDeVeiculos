using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloGrupoAutomovel
{
    public class RepositorioGrupoAutomovelOrm : RepositorioBaseEmOrm<GrupoAutomovel>, IReposisotiroGrupoAutomovel
    {
        public RepositorioGrupoAutomovelOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public GrupoAutomovel SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }

        public override List<GrupoAutomovel> SelecionarTodos(bool InserirVeiculos = false, bool InserirPlanos = false)
        {
            if (InserirVeiculos && InserirPlanos)
                return registros.Include(x => x.Veiculos).Include(x => x.Planos).ToList();

            else if (InserirVeiculos)
                return registros.Include(x => x.Veiculos).ToList();

            else if (InserirPlanos)
                return registros.Include(x => x.Planos).ToList();

            else
                return registros.ToList();
        }

        public override void Editar(GrupoAutomovel registro)
        {
            GrupoAutomovel grupoEncontrado = registros.FirstOrDefault(x => x.Id == registro.Id);

            grupoEncontrado.Veiculos = registro.Veiculos;
            grupoEncontrado.Nome = registro.Nome;

            dbContext.SaveChanges();
        }


    }
}
