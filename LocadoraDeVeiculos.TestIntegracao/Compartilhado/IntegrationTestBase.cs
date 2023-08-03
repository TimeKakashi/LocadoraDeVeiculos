using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloFuncionario;
using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloPlanoCobranca;

namespace LocadoraDeVeiculos.TestIntegracao.Compartilhado
{
    public class IntegrationTestBase
    {
        protected IRepositorioFuncionario repositorioFuncionario;
        protected IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel;
        protected IRepositorioPlanoCobranca repositorioPlanoCobranca;

        public IntegrationTestBase()
        {
            LimparTabelas();

            string connectionString = ObterConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeVeiculosDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new LocadoraDeVeiculosDbContext(optionsBuilder.Options);

            repositorioPlanoCobranca = new RepositorioPlanoCobrancaOrm(dbContext);
            reposisotiroGrupoAutomovel = new RepositorioGrupoAutomovel(dbContext);
            repositorioFuncionario = new RepositorioFuncionarioOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>(reposisotiroGrupoAutomovel.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Funcionario>(repositorioFuncionario.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorioPlanoCobranca.Inserir);
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
