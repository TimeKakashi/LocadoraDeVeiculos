using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.ModuloGrupoAutomovel
{
    public class ControladorGrupoAutomovel : ControladorBase
    {
        IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel;
        TabelaGrupoAutomovel tabelaGrupoAutomovel;
        ServicoGrupoAutomovel servicoGrupoAutomovel;

        public ControladorGrupoAutomovel(IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel, ServicoGrupoAutomovel servicoGrupoAutomovel)
        {
            this.reposisotiroGrupoAutomovel = reposisotiroGrupoAutomovel;
            this.servicoGrupoAutomovel = servicoGrupoAutomovel;

            if (tabelaGrupoAutomovel == null)
                tabelaGrupoAutomovel = new TabelaGrupoAutomovel();

            CarregarItens();
        }

        public override string ToolTipInserir => "Cadastrar Grupo de Automovel";

        public override string ToolTipEditar => "Editar Grupo de Automovel";

        public override string ToolTipExcluir => "Excluir Grupo de Automovel";

        public override string ToolTipFiltrar => "Filtrar Grupo de Automovel";

        public override string ToolTipPdf => "Gerar pdf do Grupo de Automovel";

        public override void CarregarItens()
        {
            tabelaGrupoAutomovel.AtualizarRegistros(reposisotiroGrupoAutomovel.SelecionarTodos());
        }

        public override void Editar()
        {
            GrupoAutomovel grupo = ObterItemSelecionado();

            if (grupo == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro!", "Edição de funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaGrupoAutomovelForm telaMateria = new TelaGrupoAutomovelForm();
            telaMateria.ArrumaTela(grupo);
            telaMateria.onGravarRegistro += servicoGrupoAutomovel.Editar;

            DialogResult result = telaMateria.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override void Excluir()
        {
            var grupo = ObterItemSelecionado();

            if (grupo == null)
            {
                MessageBox.Show("Selecione um grupo primeiro!",
                    "Exclusão de grupo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o grupo {grupo.Nome}?", "Exclusão de grupo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (opcaoEscolhida == DialogResult.OK)
            {
                Result result = servicoGrupoAutomovel.Excluir(grupo);

                if (result.IsFailed)
                {
                    MessageBox.Show(result.Errors[0].Message, "Exclusão de grupo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            CarregarItens();
        }

        public override void Inserir()
        {
            TelaGrupoAutomovelForm telaFuncionario = new TelaGrupoAutomovelForm();

            telaFuncionario.onGravarRegistro += servicoGrupoAutomovel.Inserir;

            DialogResult result = telaFuncionario.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override UserControl ObterTabela()
        {
            if (tabelaGrupoAutomovel == null)
                tabelaGrupoAutomovel = new TabelaGrupoAutomovel();

            return tabelaGrupoAutomovel;
        }

        public override string ObterTipoCadastro() => "Cadastro de Grupo de Automoveis";

        private GrupoAutomovel ObterItemSelecionado()
        {
            var id = tabelaGrupoAutomovel.ObterIdSelecionado();

            return reposisotiroGrupoAutomovel.SelecionarPorId(id);
        }
    }
}
