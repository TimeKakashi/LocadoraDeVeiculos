using FizzWare.NBuilder;
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
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos.TestIntegracao.Compartilhado
{
    public class IntegrationTestBase
    {
        protected IContextoPersistencia contextoPersistencia;
        protected IRepositorioFuncionario repositorioFuncionario;//
        protected IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel;//
        protected IRepositorioPlanoCobranca repositorioPlanoCobranca;//
        protected IRepositorioAutomovel repositorioAutomovel;//
        protected IRepositorioCupom repositorioCupom;//
        protected IRepositorioParceiro repositorioParceiro;//
        protected IRepositorioTaxaServico repositorioTaxaServico;//
        protected IRepositorioAluguel repositorioAluguel;//
        protected IRepositorioCliente repositorioCliente;
        protected IRepositorioCondutor repositorioCondutor;

        public IntegrationTestBase()
        {
            LimparTabelas();

            string connectionString = ObterConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeVeiculosDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new LocadoraDeVeiculosDbContext(optionsBuilder.Options);
            contextoPersistencia = dbContext;

            repositorioPlanoCobranca = new RepositorioPlanoCobrancaOrm(dbContext);
            reposisotiroGrupoAutomovel = new RepositorioGrupoAutomovelOrm(dbContext);
            repositorioFuncionario = new RepositorioFuncionarioOrm(dbContext);
            repositorioAutomovel = new RepositorioAutomovelOrm(dbContext);
            repositorioAluguel = new RepositorioAluguelOrm(dbContext);
            repositorioCupom = new RepositorioCupomOrm(dbContext);
            repositorioParceiro = new RepositorioParceiroOrm(dbContext);
            repositorioTaxaServico = new RepositorioTaxaServicoOrm(dbContext);
            repositorioCliente = new RepositorioClienteOrm(dbContext);
            repositorioCondutor = new RepositorioCondutorOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Veiculo>((Veiculo) =>
            {
                repositorioAutomovel.Inserir(Veiculo);
                contextoPersistencia.GravarDados();
            });
            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>((GrupoAutomovel) =>
            {
                reposisotiroGrupoAutomovel.Inserir(GrupoAutomovel);
                contextoPersistencia.GravarDados();
            });
            BuilderSetup.SetCreatePersistenceMethod<Funcionario>((Funcionario) =>
            {
                repositorioFuncionario.Inserir(Funcionario);
                contextoPersistencia.GravarDados();
            });
            BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>((PlanoCobranca) =>
            {
                repositorioPlanoCobranca.Inserir(PlanoCobranca);
                contextoPersistencia.GravarDados();
            });
            BuilderSetup.SetCreatePersistenceMethod<Cupom>((Cupom) =>
            {
                repositorioCupom.Inserir(Cupom);
                contextoPersistencia.GravarDados();
            });
            BuilderSetup.SetCreatePersistenceMethod<Parceiro>((Parceiro) =>
            {
                repositorioParceiro.Inserir(Parceiro);
                contextoPersistencia.GravarDados();
            });
            BuilderSetup.SetCreatePersistenceMethod<TaxaServico>((TaxaServico) =>
            {
                repositorioTaxaServico.Inserir(TaxaServico);
                contextoPersistencia.GravarDados();
            });
            BuilderSetup.SetCreatePersistenceMethod<Cliente>((Cliente) =>
            {
                repositorioCliente.Inserir(Cliente);
                contextoPersistencia.GravarDados();
            });
            BuilderSetup.SetCreatePersistenceMethod<Aluguel>((Aluguel) =>
            {
                repositorioAluguel.Inserir(Aluguel);
                contextoPersistencia.GravarDados();
            }); BuilderSetup.SetCreatePersistenceMethod<Condutor>((Condutor) =>
            {
                repositorioCondutor.Inserir(Condutor);
                contextoPersistencia.GravarDados();
            });
        }

        protected static void LimparTabelas()
        {
            string? connectionString = ObterConnectionString();

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sqlLimpezaTabela =
                @"
                DELETE FROM [DBO].[TBALUGUEL];
                DELETE FROM [DBO].[TBFUNCIONARIO];
                DELETE FROM [DBO].[TBGRUPOAUTOMOVEL];
                DELETE FROM [DBO].[TBPLANOCOBRANCA];
                DELETE FROM [DBO].[TBAutomovel];
                DELETE FROM [DBO].[TBCondutor];
                DELETE FROM [DBO].[TBCLIENTE];
                DELETE FROM [DBO].[TBTaxaServico];
                DELETE FROM [DBO].[TBCUPOM];
                DELETE FROM [DBO].[TBPARCEIRO];
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
