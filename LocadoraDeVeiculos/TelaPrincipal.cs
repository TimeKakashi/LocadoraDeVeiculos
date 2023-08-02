using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloParceiro;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloParceiro;
using LocadoraDeVeiculos.ModuloFuncionario;
using LocadoraDeVeiculos.ModuloParceiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos
{
    public partial class TelaPrincipal : Form
    {
        private static TelaPrincipal telaPrincipal;
        private IRepositorioFuncionario repositorioFuncionario;
        private IRepositorioParceiro repositorioParceiro;
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

            repositorioParceiro = new RepositorioParceiroOrm(dbContext);


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

        private void funcion�riosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var validadorFuncionario = new ValidadorFuncionario();

            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, validadorFuncionario);

            controlador = new ControladorFuncionario(repositorioFuncionario, servicoFuncionario);

            ConfigurarTelaPrincipal(controlador);
        }

        private void autom�veisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gruposDeAutom�veisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void planosDeCobran�aToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void condutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void alugu�isToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void taxasEServi�osToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cuponsEParceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pre�osToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void parceiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var validadorParceiro = new ValidadorParceiro();

            var servicoParceiro = new ServicoParceiro(repositorioParceiro, validadorParceiro);

            controlador = new ControladorParceiro(repositorioParceiro, servicoParceiro);

            ConfigurarTelaPrincipal(controlador);
        }
    }
}