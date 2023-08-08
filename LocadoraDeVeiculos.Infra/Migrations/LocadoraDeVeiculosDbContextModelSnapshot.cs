﻿// <auto-generated />
using System;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Orm.Migrations
{
    [DbContext(typeof(LocadoraDeVeiculosDbContext))]
    partial class LocadoraDeVeiculosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloAutomovel.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CapacidadeEmLitros")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("EmUso")
                        .HasColumnType("int");

                    b.Property<int>("EnumCombusteivel")
                        .HasColumnType("int");

                    b.Property<Guid>("GrupoAutomovelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Imagem")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal>("Kilometragem")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoAutomovelId");

                    b.ToTable("TBAutomovel", (string)null);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCliente.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CNPJ")
                        .HasColumnType("varchar(18)");

                    b.Property<string>("CPF")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tipo");

                    b.HasKey("Id");

                    b.ToTable("TBCliente", (string)null);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNH")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("ValidadeCNH")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("TBCondutor", (string)null);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCupom.Cupom", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDeValidade")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParceiroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ParceiroId");

                    b.ToTable("TBCupom", (string)null);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloFuncionario.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.ToTable("TBFuncionario", (string)null);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel.GrupoAutomovel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoAutomovel", (string)null);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloParceiro.Parceiro", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBParceiro", (string)null);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca.PlanoCobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GrupoAutomovelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("KmDisponivel")
                        .HasColumnType("int");

                    b.Property<int>("Plano")
                        .HasColumnType("int");

                    b.Property<decimal?>("PrecoKm")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("ValorDiaria")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoAutomovelId");

                    b.ToTable("TBPlanoCobranca", (string)null);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloTaxaServico.TaxaServico", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Plano")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18 , 2)");

                    b.HasKey("Id");

                    b.ToTable("TBTaxaServico", (string)null);
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloAutomovel.Veiculo", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel.GrupoAutomovel", "GrupoAutomovel")
                        .WithMany("Veiculos")
                        .HasForeignKey("GrupoAutomovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TBAutomovel_TBGrupoAutomovel");

                    b.Navigation("GrupoAutomovel");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloCupom.Cupom", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloParceiro.Parceiro", "Parceiro")
                        .WithMany()
                        .HasForeignKey("ParceiroId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_TBCupom_TBParceiro");

                    b.Navigation("Parceiro");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca.PlanoCobranca", b =>
                {
                    b.HasOne("LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel.GrupoAutomovel", "GrupoAutomovel")
                        .WithMany("Planos")
                        .HasForeignKey("GrupoAutomovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TBPlanoCobranca_TBGrupoAutomovel");

                    b.Navigation("GrupoAutomovel");
                });

            modelBuilder.Entity("LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel.GrupoAutomovel", b =>
                {
                    b.Navigation("Planos");

                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
