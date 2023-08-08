using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloCondutor
{
    public class MapeadorCondutorOrm : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> condutorBuilder)
        {
            condutorBuilder.ToTable("TBCondutor");
            condutorBuilder.Property(c => c.Id).IsRequired(true).ValueGeneratedNever();
            condutorBuilder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
            condutorBuilder.Property(c => c.CPF).HasColumnType("varchar(14)");
            condutorBuilder.Property(c => c.CNH).HasColumnType("varchar(20)").IsRequired();
            condutorBuilder.Property(c => c.ValidadeCNH).IsRequired();
            condutorBuilder.Property(c => c.Telefone).HasColumnType("varchar(20)").IsRequired();
            condutorBuilder.Property(c => c.Email).HasColumnType("varchar(100)").IsRequired();

            // Relacionamento com a entidade Cliente
            condutorBuilder.HasOne(c => c.Cliente)
                .WithMany()
                .IsRequired()
                .HasConstraintName("FK_Condutor_TBCliente")
                .OnDelete(DeleteBehavior.NoAction);

        }
    }


}
