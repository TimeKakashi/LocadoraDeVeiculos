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
        public void Configure(EntityTypeBuilder<Cupom> cupomBuilderr)
        {
            cupomBuilderr.ToTable("TBCupom");

            cupomBuilderr.Property(p => p.Id).IsRequired().ValueGeneratedNever();

            cupomBuilderr.Property(p => p.Nome).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
