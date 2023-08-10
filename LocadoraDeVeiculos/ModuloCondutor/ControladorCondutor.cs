using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
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
        private IRepositorioCliente repositorioCliente;
        private ServicoCondutor servicoCondutor;
        private TabelaCondutor tabelaCondutor;
        private List<Cliente> listaClientes;

        public ControladorCondutor(IRepositorioCondutor repositorioCondutor, IRepositorioCliente repositorioCliente, ServicoCondutor servicoCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.repositorioCliente = repositorioCliente;
            this.listaClientes = listaClientes;
        }

        public override string ToolTipInserir => "Inserir Condutor";
        public override string ToolTipEditar => "Editar Condutor";
        public override string ToolTipExcluir => "Excluir Condutor";
        public override string ToolTipFiltrar => "Filtrar Condutor";
        public override string ToolTipPdf => "Gerar Pdf";
        public override string ToolTipCombustivel =>"Combustivel";

        public override void Inserir()
        {
            var telaCondutor = new telaCondutorForm(repositorioCliente.SelecionarTodos());

            telaCondutor.OnGravarRegistro += servicoCondutor.Inserir;

            telaCondutor.ArrumaTela(new Condutor(), true);

            DialogResult result = telaCondutor.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override void Editar()
        {
            var condutor = ObterItemSelecionado();

            if (condutor == null)
            {
                MessageBox.Show("Selecione um condutor primeiro!", "Edição de condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var telaCondutor = new telaCondutorForm(listaClientes);
            telaCondutor.ArrumaTela(condutor);

            telaCondutor.OnGravarRegistro += (condutorEditado) =>
            {
                Result resultado = servicoCondutor.Editar(condutorEditado);
                return resultado;
            };

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

            CarregarItens();

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
            if (repositorioCondutor != null && repositorioCliente != null)
            {
                var listaCondutor = repositorioCondutor.SelecionarTodos();
                tabelaCondutor.AtualizarRegistros(listaCondutor);
            }
        }

        private Cliente ObterClienteRelacionado()
        {
            var idClienteRelacionado = tabelaCondutor.ObterIdSelecionado();
            var clienteRelacionado = repositorioCliente.SelecionarPorId((Guid)idClienteRelacionado);
            return clienteRelacionado;
        }
    }





}
