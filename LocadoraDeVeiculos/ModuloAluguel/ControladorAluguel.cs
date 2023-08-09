using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloAluguel;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;

namespace LocadoraDeVeiculos.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase
    {
        public override string ToolTipInserir => "Inserir Alguel";
        public override string ToolTipEditar => "Editar Alguel";
        public override string ToolTipExcluir => "Excluir Alguel";
        public override string ToolTipFiltrar => "Filtrar Alguel";
        public override string ToolTipPdf => "Gerar e Encaminhar Pdf por Email";
        public override string ToolTipCombustivel => "Atualizar Valores Combustível";
        public override bool DevolucaoHabilitado => true;

        private TabelaAluguel tabelaAluguel;
        private ServicoAluguel servicoAluguel;
        private IRepositorioAluguel repositorioAluguel;
        private IRepositorioFuncionario repositorioFuncionario;
        private IRepositorioCliente repositorioCliente;
        private IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel;
        private IRepositorioCupom repositorioCupom;
        private IRepositorioTaxaServico repositorioTaxaServico;


        public ControladorAluguel(ServicoAluguel servicoAluguel, IRepositorioAluguel repositorioAluguel)
        {
            this.servicoAluguel = servicoAluguel;
            this.repositorioAluguel = repositorioAluguel;
        }

        public ControladorAluguel(ServicoAluguel servicoAluguel, IRepositorioAluguel repositorioAluguel,
            IRepositorioFuncionario repositorioFuncionario, IRepositorioCliente repositorioCliente,
            IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel,IRepositorioCupom repositorioCupom,
            IRepositorioTaxaServico repositorioTaxaServico
)
            : this(servicoAluguel, repositorioAluguel)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioCliente = repositorioCliente;
            this.reposisotiroGrupoAutomovel = reposisotiroGrupoAutomovel;
            this.repositorioCupom = repositorioCupom;
            this.repositorioTaxaServico = repositorioTaxaServico;

            if (tabelaAluguel == null)
                tabelaAluguel = new TabelaAluguel();

            CarregarItens();
        }

        public override void CarregarItens()
        {
            var listaAutomovel = repositorioAluguel.SelecionarTodos();

            tabelaAluguel.AtualizarRegistros(listaAutomovel);
        }

        public override void Inserir()
        {
            TelaAluguelForm talaAluguel = new TelaAluguelForm(
                repositorioFuncionario.SelecionarTodos(),
                repositorioCliente.SelecionarTodos(true),
                reposisotiroGrupoAutomovel.SelecionarTodos(true, true),
                repositorioTaxaServico.SelecionarTodos(), repositorioCupom.SelecionarTodos()
                );

            talaAluguel.onGravarRegistro += servicoAluguel.Inserir;

            talaAluguel.onProcurarCupom += servicoAluguel.ProcurarCupom;

            talaAluguel.ArrumaTela(new Aluguel(), true);

            if (talaAluguel.ShowDialog() == DialogResult.OK)
                CarregarItens();
        }

        public override void Editar()
        {
            Aluguel aluguel = ObterAluguelSelecionado();

            if (aluguel == null)
            {
                MessageBox.Show("Selecione um alguel primeiro!", "Edição de alguel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaAluguelForm talaAluguel = new TelaAluguelForm(
               repositorioFuncionario.SelecionarTodos(),
               repositorioCliente.SelecionarTodos(true),
               reposisotiroGrupoAutomovel.SelecionarTodos(true, true),
               repositorioTaxaServico.SelecionarTodos(), repositorioCupom.SelecionarTodos()
               );

            talaAluguel.ArrumaTela(aluguel, false);

            talaAluguel.onGravarRegistro += servicoAluguel.Editar;

            talaAluguel.onProcurarCupom += servicoAluguel.ProcurarCupom;

            if (talaAluguel.ShowDialog() == DialogResult.OK)
                CarregarItens();
        }

        private Aluguel ObterAluguelSelecionado()
        {
            var id = tabelaAluguel.ObterIdSelecionado();

            return repositorioAluguel.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            var aluguel = ObterAluguelSelecionado();

            if (aluguel == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro!",
                    "Exclusão de veiculo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o aluguel do cliente: {aluguel.Cliente} com o veiculo: {aluguel.Veiculo.Modelo}?", "Exclusão de aluguel",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result result = servicoAluguel.Excluir(aluguel);

                if (result.IsFailed)
                {
                    MessageBox.Show(result.Errors[0].Message, "Exclusão de aluguel", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            CarregarItens();
        }

        


        public override UserControl ObterTabela()
        {
            if (tabelaAluguel == null)
                tabelaAluguel = new TabelaAluguel();

            return tabelaAluguel;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Alugueis";
        }
    }
}

