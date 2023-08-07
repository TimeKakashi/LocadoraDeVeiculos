using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private IRepositorioCondutor repositorioCondutor;
        private ServicoCondutor servicoCondutor;
        private TabelaCondutor tabelaCondutor;

        public ControladorCondutor(IRepositorioCondutor repositorioCondutor, ServicoCondutor servicoCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.servicoCondutor = servicoCondutor;

            if (tabelaCondutor == null)
                tabelaCondutor = new TabelaCondutor();

            CarregarItens();
        }

        public override string ToolTipInserir => "Inserir Condutor";

        public override string ToolTipEditar => "Editar Condutor";

        public override string ToolTipExcluir => "Excluir Condutor";

        public override string ToolTipFiltrar => "Filtrar Condutor";

        public override string ToolTipPdf => "Gerar Pdf";

        public override void Inserir()
        {
            telaCondutorForm telaCondutor = new telaCondutorForm();

            telaCondutor.onGravarRegistro += servicoCondutor.Inserir;

            DialogResult result = telaCondutor.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override void Editar()
        {
            Condutor condutor = ObterItemSelecionado();

            if (condutor == null)
            {
                MessageBox.Show("Selecione um condutor primeiro!", "Edição de condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            telaCondutorForm telaCondutor = new telaCondutorForm();
            telaCondutor.ArrumaTela(condutor);
            telaCondutor.onGravarRegistro += servicoCondutor.Editar;

            DialogResult result = telaCondutor.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override void Excluir()
        {
            var condutor = ObterItemSelecionado();

            if (condutor == null)
            {
                MessageBox.Show("Selecione um condutor primeiro!",
                    "Exclusão de condutor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o condutor {condutor.Nome}?", "Exclusão de condutor",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result result = servicoCondutor.Excluir(condutor);

                if (result.IsFailed)
                {
                    MessageBox.Show(result.Errors[0].Message, "Exclusão de condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            CarregarItens();
        }

        public override UserControl ObterTabela()
        {
            if (tabelaCondutor == null)
                tabelaCondutor = new TabelaCondutor();

            return tabelaCondutor;
        }

        public override string ObterTipoCadastro() => "Cadastro de Condutor";

        private Condutor ObterItemSelecionado()
        {
            var id = tabelaCondutor.ObterIdSelecionado();

            return repositorioCondutor.SelecionarPorId(id);
        }

        public override void CarregarItens()
        {
            var listaCondutor = repositorioCondutor.SelecionarTodos();

            tabelaCondutor.AtualizarRegistros(listaCondutor);
        }
    }

}
