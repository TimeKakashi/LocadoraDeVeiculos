using LocadoraDeVeiculos.Aplicacao.ModuloAluguel;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloCupom;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Aplicacao.ModuloParceiro;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxaServico;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloAluguel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloAutomovel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloCupom;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloParceiro;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloTaxaServico;
using LocadoraDeVeiculos.ModuloAluguel;
using LocadoraDeVeiculos.ModuloAutomovel;
using LocadoraDeVeiculos.ModuloCliente;
using LocadoraDeVeiculos.ModuloCondutor;
using LocadoraDeVeiculos.ModuloCupom;
using LocadoraDeVeiculos.ModuloFuncionario;
using LocadoraDeVeiculos.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.ModuloParceiro;
using LocadoraDeVeiculos.ModuloPlanoCobranca;
using LocadoraDeVeiculos.ModuloTaxaServico;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Compartilhado.Ioc.cs
{
    internal class IoC_LocadoraDeVeiculosLocator : IoC
    {
        private ServiceProvider container;

        public IoC_LocadoraDeVeiculosLocator()
        {
            var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var servicos = new ServiceCollection();

            servicos.AddDbContext<IContextoPersistencia, LocadoraDeVeiculosDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            //aluguel
            servicos.AddTransient<ControladorAluguel>();
            servicos.AddTransient<ServicoAluguel>();
            servicos.AddTransient<IValidadorAluguel, ValidadorAluguel>();
            servicos.AddTransient<IRepositorioAluguel, RepositorioAluguelOrm>();

            //Automovel
            servicos.AddTransient<ControladorAutomovel>();
            servicos.AddTransient<ServicoAutomovel>();
            servicos.AddTransient<IValidadorAutomovel, ValidadorAutomovel>();
            servicos.AddTransient<IRepositorioAutomovel, RepositorioAutomovelOrm>();

            //Cliente
            servicos.AddTransient<ControladorCliente>();
            servicos.AddTransient<ServicoCliente>();
            servicos.AddTransient<IValidadorCliente, ValidadorCliente>();
            servicos.AddTransient<IRepositorioCliente, RepositorioClienteOrm>();

            //Condutor
            servicos.AddTransient<ControladorCondutor>();
            servicos.AddTransient<ServicoCondutor>();
            servicos.AddTransient<IValidadorCondutor, ValidadorCondutor>();
            servicos.AddTransient<IRepositorioCondutor, RepositorioCondutorOrm>();

            //Cupom
            servicos.AddTransient<ControladorCupom>();
            servicos.AddTransient<ServicoCupom>();
            servicos.AddTransient<IValidadorCupom, ValidadorCupom>();
            servicos.AddTransient<IRepositorioCupom, RepositorioCupomOrm>();
            //Funcionario
            servicos.AddTransient<ControladorFuncionario>();
            servicos.AddTransient<ServicoFuncionario>();
            servicos.AddTransient<IValidadorFuncionario, ValidadorFuncionario>();
            servicos.AddTransient<IRepositorioFuncionario, RepositorioFuncionarioOrm>();
            
            //AutomovelGrupo
            servicos.AddTransient<ControladorGrupoAutomovel>();
            servicos.AddTransient<ServicoGrupoAutomovel>();
            servicos.AddTransient<IValidadorGrupoAutomovel, ValidadorGrupoAutomovel>();
            servicos.AddTransient<IReposisotiroGrupoAutomovel, RepositorioGrupoAutomovelOrm>();

            //Parceiro
            servicos.AddTransient<ControladorParceiro>();
            servicos.AddTransient<ServicoParceiro>();
            servicos.AddTransient<IValidadorParceiro, ValidadorParceiro>();
            servicos.AddTransient<IRepositorioParceiro, RepositorioParceiroOrm>();

            //PlanoCobrança
            servicos.AddTransient<ControladorPlanoCobranca>();
            servicos.AddTransient<ServicoPlanoCobranca>();
            servicos.AddTransient<IValidadorPlanoCobranca, ValidadorPlanoCobranca>();
            servicos.AddTransient<IRepositorioPlanoCobranca, RepositorioPlanoCobrancaOrm>();

            //TaxaServico
            servicos.AddTransient<ControladorTaxaServico>();
            servicos.AddTransient<ServicoTaxaServico>();
            servicos.AddTransient<IValidadorTaxaServico, ValidadorTaxaServico>();
            servicos.AddTransient<IRepositorioTaxaServico, RepositorioTaxaServicoOrm>();

            servicos.AddTransient<IRepositorioCombustivelJson, RepositorioCombustivelJson>();


            container = servicos.BuildServiceProvider();
        }

        public T Get<T>()
        {
            return container.GetService<T>();
        }
    }
}
