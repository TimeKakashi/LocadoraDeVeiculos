using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloGrupoAutomovel
{
    public class MapeadorGrupoAutomovel : IEntityTypeConfiguration<GrupoAutomovel>
    {
        public void Configure(EntityTypeBuilder<GrupoAutomovel> grupoAutomovelBuild)
        {
            grupoAutomovelBuild.ToTable("TBGrupoAutomovel");
            grupoAutomovelBuild.Property(g => g.Nome).HasColumnType("varchar(100)").IsRequired();
            grupoAutomovelBuild.Property(g => g.Id).IsRequired().ValueGeneratedNever();
            grupoAutomovelBuild.HasOne(g => g.PlanoCobranca).WithMany().IsRequired().HasConstraintName("FK_TBGrupoAutomovel_TBPlanoCobranca");
        }
    }
}
