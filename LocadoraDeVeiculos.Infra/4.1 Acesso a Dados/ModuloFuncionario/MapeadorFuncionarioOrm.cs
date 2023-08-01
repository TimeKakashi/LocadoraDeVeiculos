using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloFuncionario
{
    public class MapeadorFuncionarioOrm : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> funcionarioBuilder)
        {
            funcionarioBuilder.ToTable("TBFuncionario");
            funcionarioBuilder.Property(f => f.Id).IsRequired(true).ValueGeneratedNever();
            funcionarioBuilder.Property(f => f.Nome).HasColumnType("varchar(100)").IsRequired();
            funcionarioBuilder.Property(f => f.Salario).HasColumnType("decimal(8,2)").IsRequired();
            funcionarioBuilder.Property(f => f.DataEntrada).IsRequired();
        }
    }
}
