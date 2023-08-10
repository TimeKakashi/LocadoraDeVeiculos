using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Compartilhado.Ioc.cs;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
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

namespace LocadoraDeVeiculos
{
    public partial class TelaPrincipal : Form
    {
        private static TelaPrincipal telaPrincipal;

        private ControladorBase controlador;

        private IoC IoC;

        public TelaPrincipal()
        {
            InitializeComponent();

            IoC = new IoC_LocadoraDeVeiculosLocator();

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
            this.controlador = controlador;

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
            btnCombustivel.Enabled = controlador.AtualizarValoresCombustivel;
            brnDevolucao.Enabled = controlador.DevolucaoHabilitado;
            ToolTipPdf.Enabled = controlador.GerarPdfHabilitado;
        }

        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btnInserir.ToolTipText = controlador.ToolTipInserir;
            btnEditar.ToolTipText = controlador.ToolTipEditar;
            btnExcluir.ToolTipText = controlador.ToolTipExcluir;
            btnFiltrar.ToolTipText = controlador.ToolTipFiltrar;
            btnCombustivel.ToolTipText = controlador.ToolTipCombustivel;
            brnDevolucao.ToolTipText = controlador.TooTipDevolucao;

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
            ConfigurarTelaPrincipal(IoC.Get<ControladorFuncionario>());
        }

        private void automóveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorAutomovel>());
        }


        private void gruposDeAutomóveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorGrupoAutomovel>());
        }

        private void planosDeCobrançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorPlanoCobranca>());
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorCliente>());
        }
        private void parceiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorParceiro>());
        }


        private void condutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorCondutor>());
        }


        private void aluguéisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorAluguel>());
        }

        private void taxasEServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorTaxaServico>());
        }

        private void cuponsEParceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(IoC.Get<ControladorCupom>());
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
            labelRodaPe.Text = erro;
        }

        private void brnDevolucao_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma area primerio!");
                return;
            }

            controlador.DevolucaoAluguel();
        }

        private void btnCombustivel_Click_1(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma area primerio!");
                return;
            }

            controlador.ArrumarPrecos();
        }

        private void ToolTipPdf_Click(object sender, EventArgs e)
        {
            if (controlador == null)
            {
                MessageBox.Show("Selecione uma area primerio!");
                return;
            }

            controlador.GerarPdf();
        }
    }
}
