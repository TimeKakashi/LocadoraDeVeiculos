using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloAutomovel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloCupom;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloParceiro;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloTaxaServico;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos.TestIntegracao.Compartilhado
{
    public class IntegrationTestBase
    {
        protected IRepositorioFuncionario repositorioFuncionario;
        protected IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel;
        protected IRepositorioPlanoCobranca repositorioPlanoCobranca;
        protected IRepositorioAutomovel repositorioAutomovel;
        protected IRepositorioCupom repositorioCupom;
        protected IRepositorioParceiro repositorioParceiro;
        protected IRepositorioTaxaServico repositorioTaxaServico;

        public IntegrationTestBase()
        {
            LimparTabelas();

            string connectionString = ObterConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeVeiculosDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new LocadoraDeVeiculosDbContext(optionsBuilder.Options);

            repositorioPlanoCobranca = new RepositorioPlanoCobrancaOrm(dbContext);
            reposisotiroGrupoAutomovel = new RepositorioGrupoAutomovelOrm(dbContext);
            repositorioFuncionario = new RepositorioFuncionarioOrm(dbContext);
            repositorioAutomovel = new RepositorioAutomovelOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Veiculo>(repositorioAutomovel.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>(reposisotiroGrupoAutomovel.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Funcionario>(repositorioFuncionario.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorioPlanoCobranca.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Cupom>(repositorioCupom.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Parceiro>(repositorioParceiro.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<TaxaServico>(repositorioTaxaServico.Inserir);
        }

        protected static void LimparTabelas()
        {
            string? connectionString = ObterConnectionString();

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sqlLimpezaTabela =
                @"
                DELETE FROM [DBO].[TBFUNCIONARIO];
                DELETE FROM [DBO].[TBGRUPOAUTOMOVEL];
                DELETE FROM [DBO].[TBPLANOCOBRANCA];
                DELETE FROM [DBO].[TBAutomovel];
                 ";
            SqlCommand comando = new SqlCommand(sqlLimpezaTabela, sqlConnection);

            sqlConnection.Open();

            comando.ExecuteNonQuery();

            sqlConnection.Close();
        }

        protected static string ObterConnectionString()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");
            return connectionString;
        }
    }
}
