using LocadoraDeVeiculos.Aplicacao.ModuloAluguel;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
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

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            TelaAluguelForm telaAutomovel = new TelaAluguelForm(
                repositorioFuncionario.SelecionarTodos(),
                repositorioCliente.SelecionarTodos(true),
                reposisotiroGrupoAutomovel.SelecionarTodos(true, true),
                repositorioTaxaServico.SelecionarTodos(), repositorioCupom.SelecionarTodos()
                );

            telaAutomovel.onGravarRegistro += servicoAluguel.Inserir;

            telaAutomovel.ArrumaTela(new Aluguel(), true);

            if (telaAutomovel.ShowDialog() == DialogResult.OK)
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

