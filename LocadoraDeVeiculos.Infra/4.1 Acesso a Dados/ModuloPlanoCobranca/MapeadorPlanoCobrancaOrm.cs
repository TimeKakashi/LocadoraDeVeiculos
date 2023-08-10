using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaOrm : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> planoBuilder)
        {
            planoBuilder.ToTable("TBPlanoCobranca");
            planoBuilder.Property(p => p.Id).IsRequired().ValueGeneratedNever();
            planoBuilder.Property(p => p.ValorDiaria).HasColumnType("decimal(8,2)").IsRequired();
            planoBuilder.Property(p => p.PrecoKm).HasColumnType("decimal(8,2)").IsRequired(false);
            planoBuilder.Property(p => p.KmDisponivel).IsRequired(false);
            planoBuilder.Property(p => p.Plano).HasConversion<int>().IsRequired();

            planoBuilder.HasOne(p => p.GrupoAutomovel).WithMany(g => g.Planos).IsRequired().HasConstraintName("FK_TBPlanoCobranca_TBGrupoAutomovel").OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
