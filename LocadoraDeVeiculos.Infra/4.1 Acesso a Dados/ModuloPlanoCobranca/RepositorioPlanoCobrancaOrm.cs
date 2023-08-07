using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaOrm : RepositorioBaseEmOrm<PlanoCobranca>, IRepositorioPlanoCobranca
    {
        public RepositorioPlanoCobrancaOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public override void Editar(PlanoCobranca registro)
        {
            PlanoCobranca planoCobrancaEncontrado = registros.FirstOrDefault(x => x.Id == registro.Id);

            planoCobrancaEncontrado.PrecoKm = registro.PrecoKm;
            planoCobrancaEncontrado.KmDisponivel = registro.KmDisponivel;
            planoCobrancaEncontrado.ValorDiaria = registro.ValorDiaria;
            planoCobrancaEncontrado.Plano = registro.Plano;
            planoCobrancaEncontrado.GrupoAutomovel = registro.GrupoAutomovel;

            dbContext.SaveChanges();
        }
    }
}
