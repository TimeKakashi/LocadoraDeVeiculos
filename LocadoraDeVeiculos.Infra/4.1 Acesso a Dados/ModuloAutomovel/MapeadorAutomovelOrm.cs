using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloAutomovel
{
    public class MapeadorAutomovelOrm : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> veiculoBuilder)
        {
            veiculoBuilder.ToTable("TBAutomovel");
            veiculoBuilder.Property(g => g.Modelo).HasColumnType("varchar(100)").IsRequired();
            veiculoBuilder.Property(g => g.Marca).IsRequired().HasColumnType("varchar(100)");
            veiculoBuilder.Property(g => g.Id).IsRequired().ValueGeneratedNever();
            veiculoBuilder.Property(g => g.Placa).IsRequired().HasColumnType("varchar(10)");
            veiculoBuilder.Property(g => g.Cor).IsRequired().HasColumnType("varchar(50)");
            veiculoBuilder.Property(g => g.CapacidadeEmLitros).IsRequired();
            veiculoBuilder.Property(g => g.Kilometragem).HasColumnType("decimal(8,2)").IsRequired(true);
            veiculoBuilder.Property(g => g.EnumCombusteivel).HasConversion<int>().IsRequired();
            veiculoBuilder.Property(g => g.EmUso).HasConversion<int>().IsRequired();
            veiculoBuilder.Property(g => g.Imagem).IsRequired();

            veiculoBuilder.HasOne(g => g.GrupoAutomovel).WithMany(g => g.Veiculos).HasConstraintName("FK_TBAutomovel_TBGrupoAutomovel");
        }
    }
}
