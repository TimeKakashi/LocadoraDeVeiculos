using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloTaxaServico
{
    public class MapeadorTaxaServicoOrm : IEntityTypeConfiguration<TaxaServico>
    {
        

        public void Configure(EntityTypeBuilder<TaxaServico> taxaServicoBuilder)
        {
            taxaServicoBuilder.ToTable("TBTaxaServico");

            taxaServicoBuilder.Property(t => t.Id).IsRequired().ValueGeneratedNever();

            taxaServicoBuilder.Property(t => t.Nome).HasColumnType("varchar(100)").IsRequired();

            taxaServicoBuilder.Property(t => t.Preco).HasColumnType("decimal(18 , 2)").IsRequired();

            taxaServicoBuilder.Property(t => t.Plano).IsRequired();
        }
    }
}
