using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloAluguel
{
    public class MapeadorAluguelOrm : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> aluguelBuilder)
        {
            aluguelBuilder.ToTable("TBAluguel");
            aluguelBuilder.Property(a => a.Id).IsRequired().ValueGeneratedNever();
            aluguelBuilder.Property(a => a.DataLocacao).IsRequired();
            aluguelBuilder.Property(a => a.DataDevolucaoPrevista).IsRequired();
            aluguelBuilder.Property(a => a.DataDevolucao);
            aluguelBuilder.Property(a => a.NivelTanque);
            aluguelBuilder.Property(a => a.Preco).IsRequired();
            aluguelBuilder.Property(a => a.Finalizado);
            aluguelBuilder.Property(a => a.KmPercorrido).HasColumnType("decimal(18, 2)");
            aluguelBuilder.Property(a => a.Preco).HasColumnType("decimal(18, 2)");

            aluguelBuilder.HasOne(a => a.Funcionario)
              .WithMany()
              .IsRequired()
              .HasConstraintName("FK_TBAluguel_TBFuncionario")
              .OnDelete(DeleteBehavior.NoAction);

            aluguelBuilder.HasOne(a => a.Cliente)
               .WithMany()
               .IsRequired()
               .HasConstraintName("FK_TBAluguel_TBCliente")
               .OnDelete(DeleteBehavior.NoAction);

            aluguelBuilder.HasOne(a => a.GrupoAutomovel)
               .WithMany()
               .IsRequired()
               .HasConstraintName("FK_TBAluguel_TBGrupoAutomovel")
               .OnDelete(DeleteBehavior.NoAction);

            aluguelBuilder.HasOne(a => a.PlanoCobranca)
               .WithMany()
               .IsRequired()
               .HasConstraintName("FK_TBAluguel_TBPlanoCobranca")
               .OnDelete(DeleteBehavior.NoAction);

            aluguelBuilder.HasOne(a => a.Veiculo)
               .WithMany()
               .IsRequired()
               .HasConstraintName("FK_TBAlugueil_TBAutomovel")
               .OnDelete(DeleteBehavior.NoAction);

            aluguelBuilder.HasOne(a => a.Cupom)
               .WithMany()
               .HasConstraintName("FK_TBAluguel_TBCupom")
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
