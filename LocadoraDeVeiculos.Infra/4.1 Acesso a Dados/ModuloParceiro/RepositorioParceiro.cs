using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloParceiro
{
    public class RepositorioParceiroOrm : RepositorioBaseEmOrm<Parceiro>, IRepositorioParceiro
    {


        public RepositorioParceiroOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {

        }

        public override void Editar(Parceiro registro)
        {
            Parceiro parceiroEncontrado = registros.FirstOrDefault(x => x.Id == registro.Id);

            parceiroEncontrado.Nome = registro.Nome;

            dbContext.SaveChanges();

        }
        public Parceiro SelecionarPorNome(string nome)
        {

            return registros.FirstOrDefault(registros => registros.Nome == nome);
        }
    }
}
