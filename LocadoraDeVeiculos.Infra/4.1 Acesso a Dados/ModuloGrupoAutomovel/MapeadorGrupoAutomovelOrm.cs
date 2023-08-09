using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloGrupoAutomovel
{
    public class MapeadorGrupoAutomovelOrm : IEntityTypeConfiguration<GrupoAutomovel>
    {
        public void Configure(EntityTypeBuilder<GrupoAutomovel> grupoAutomovelBuild)
        {
            grupoAutomovelBuild.ToTable("TBGrupoAutomovel");
            grupoAutomovelBuild.Property(g => g.Nome).HasColumnType("varchar(100)").IsRequired();
            grupoAutomovelBuild.Property(g => g.Id).IsRequired().ValueGeneratedNever();
        }
    }
}
