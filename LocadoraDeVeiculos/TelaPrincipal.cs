using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.ModuloFuncionario;
using LocadoraDeVeiculos.ModuloGrupoAutomovel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos
{
    public partial class TelaPrincipal : Form
    {
        private static TelaPrincipal telaPrincipal;

        private IRepositorioFuncionario repositorioFuncionario;
        private IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel;

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

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
    }
}