using LocadoraDeVeiculos.Dominio.ModuloCupom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloCupom
{
    public class MapeadorCupomOrm : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> cupomBuilder)
        {
            cupomBuilder.ToTable("TBCupom");
            cupomBuilder.Property(f => f.Id).IsRequired().ValueGeneratedNever();
            cupomBuilder.Property(f => f.Nome).IsRequired(true).ValueGeneratedNever();
            cupomBuilder.Property(f => f.Valor).HasColumnType("varchar(100)").IsRequired();
            cupomBuilder.Property(f => f.DataDeValidade).IsRequired();

            cupomBuilder.HasOne(c => c.Parceiro).WithMany().IsRequired().HasConstraintName("FK_TBCupom_TBParceiro").OnDelete(DeleteBehavior.NoAction);
        }
    }
}
