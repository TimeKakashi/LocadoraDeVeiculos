using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloCliente
{
    public class MapeadorClienteOrm : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> clienteBuilder)
        {
            clienteBuilder.ToTable("TBCliente");
            clienteBuilder.Property(c => c.Id).IsRequired(true).ValueGeneratedNever();
            clienteBuilder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Telefone).HasColumnType("varchar(20)").IsRequired();
            clienteBuilder.Property(c => c.Email).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Bairro).HasColumnType("varchar(50)").IsRequired();
            clienteBuilder.Property(c => c.Rua).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Numero).HasColumnType("varchar(10)").IsRequired();
            clienteBuilder.Property(c => c.Cidade).HasColumnType("varchar(50)").IsRequired();
            clienteBuilder.Property(c => c.Estado).HasColumnType("varchar(2)").IsRequired();

            clienteBuilder.Property(c => c.CPF).HasColumnType("varchar(14)");


            clienteBuilder.Property(c => c.CNPJ).HasColumnType("varchar(18)");


            clienteBuilder.Property(c => c.Tipo)
                .HasConversion(
                    tipoCliente => tipoCliente.ToString(),
                    tipoString => (Dominio.ModuloCliente.Cliente.TipoCliente)Enum.Parse(typeof(Dominio.ModuloCliente.Cliente.TipoCliente), tipoString)
                )
                .HasColumnName("Tipo")
                .IsRequired();
        }
    }

}
