using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCupom;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Aplicacao.ModuloParceiro;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloParceiro;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloPlanoCobranca;
using LocadoraDeVeiculos.ModuloCliente;
using LocadoraDeVeiculos.ModuloCupom;
using LocadoraDeVeiculos.ModuloFuncionario;
using LocadoraDeVeiculos.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.ModuloParceiro;
using LocadoraDeVeiculos.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos
{
    public partial class TelaPrincipal : Form
    {
        private static TelaPrincipal telaPrincipal;

        private IRepositorioFuncionario repositorioFuncionario;
        private IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel;
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private IRepositorioParceiro repositorioParceiro;
        private IRepositorioCliente repositorioCliente;
        private IRepositorioCupom repositorioCupom;
        private TabelaCliente TabelaCliente;


        private ControladorBase controlador;
        public TelaPrincipal()
        {
            InitializeComponent();

            telaPrincipal = this;

            var configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeVeiculosDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new LocadoraDeVeiculosDbContext(optionsBuilder.Options);

            var migracoesPendentes = dbContext.Database.GetPendingMigrations();

            if (migracoesPendentes.Count() > 0)
            {
                dbContext.Database.Migrate();
            }

            repositorioFuncionario = new RepositorioFuncionarioOrm(dbContext);
            reposisotiroGrupoAutomovel = new RepositorioGrupoAutomovel(dbContext);
            repositorioPlanoCobranca = new RepositorioPlanoCobrancaOrm(dbContext);
            repositorioCliente = new RepositorioClienteOrm(dbContext);
            repositorioParceiro = new RepositorioParceiroOrm(dbContext);
            repositorioCupom = new RepositorioCupomOrm(dbContext);
        }
        public static TelaPrincipal Instancia
        {
            get
            {
                if (telaPrincipal == null)
                    telaPrincipal = new TelaPrincipal();

                return telaPrincipal;
            }
        }

        public void ConfigurarTelaPrincipal(ControladorBase controlador)
        {
            toolStripLabel1.Text = controlador.ObterTipoCadastro();
            ConfigurarToolTips(controlador);
            ConfigurarTabela(controlador);
            ConfigurarEstados(controlador);
        }

        private void ConfigurarEstados(ControladorBase controlador)
        {
            btnInserir.Enabled = controlador.InserirHabilitado;
            btnEditar.Enabled = controlador.EditarHabilitado;
            btnExcluir.Enabled = controlador.ExcluirHabilitado;
            btnFiltrar.Enabled = controlador.VisualizarHabilitado;
        }

        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btnInserir.ToolTipText = controlador.ToolTipInserir;
            btnEditar.ToolTipText = controlador.ToolTipEditar;
            btnExcluir.ToolTipText = controlador.ToolTipExcluir;
            btnFiltrar.ToolTipText = controlador.ToolTipFiltrar;
        }

        private void ConfigurarTabela(ControladorBase controlador)
        {
            UserControl listagem = controlador.ObterTabela();
            listagem.Dock = DockStyle.Fill;
            panelRegistros.Controls.Clear();
            panelRegistros.Controls.Add(listagem);
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var validadorFuncionario = new ValidadorFuncionario();

            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, validadorFuncionario);

            controlador = new ControladorFuncionario(repositorioFuncionario, servicoFuncionario);

            ConfigurarTelaPrincipal(controlador);
        }

        private void automóveisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gruposDeAutomóveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var validadorGrupo = new ValidadorGrupoAutomovel();

            var servicoGrupo = new ServicoGrupoAutomovel(reposisotiroGrupoAutomovel, validadorGrupo);

            controlador = new ControladorGrupoAutomovel(reposisotiroGrupoAutomovel, servicoGrupo);

            ConfigurarTelaPrincipal(controlador);
        }

        private void planosDeCobrançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var validadorPlano = new ValidadorPlanoCobranca();

            var servicoPlano = new ServicoPlanoCobranca(repositorioPlanoCobranca, validadorPlano);

            controlador = new ControladorPlanoBbranca(servicoPlano, repositorioPlanoCobranca, reposisotiroGrupoAutomovel);

            ConfigurarTelaPrincipal(controlador);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var validadorCliente = new ValidadorCliente();

            var servicoCliente = new ServicoCliente(repositorioCliente, validadorCliente);

            controlador = new ControladorCliente(repositorioCliente, TabelaCliente, servicoCliente);

            ConfigurarTelaPrincipal(controlador);
        }
        private void parceiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var validadorParceiro = new ValidadorParceiro();

            var servicoParceiro = new ServicoParceiro(repositorioParceiro, validadorParceiro);

            controlador = new ControladorParceiro(repositorioParceiro, servicoParceiro);

            ConfigurarTelaPrincipal(controlador);
        }


        private void condutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aluguéisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void taxasEServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cuponsEParceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var validadorCupom = new ValidadorCupom();

            var servicoCupom = new ServicoCupom(repositorioParceiro, validadorCupom);

            controlador = new ControladorCupom(repositorioCupom, servicoCupom);

            ConfigurarTelaPrincipal(controlador);
        }

        private void preçosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma area primerio!");
                return;
            }

            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma area primerio!");
                return;
            }

            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma area primerio!");
                return;
            }

            controlador.Excluir();
        }

        public void AtualizarRodape(string erro)
        {
            toolStripLabel1.Text = erro;
        }

        
    }
}