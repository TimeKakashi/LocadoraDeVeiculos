using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloParceiro
{
    public class MapeadorParceiro : IEntityTypeConfiguration<Parceiro>
    {
        public void Configure(EntityTypeBuilder<Parceiro> parceiroBuilder)
        {
            parceiroBuilder.ToTable("TBParceiro");

            parceiroBuilder.Property(p => p.Id).IsRequired().ValueGeneratedNever();

            parceiroBuilder.Property(p => p.Nome).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
