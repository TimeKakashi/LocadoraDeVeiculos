using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private IRepositorioCliente repositorioCliente;
        private TabelaCliente listagemClienteControl;
        private ServicoCliente servicoCliente;

        public ControladorCliente(IRepositorioCliente repositorioCliente, TabelaCliente listagemClienteControl, ServicoCliente servicoCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.servicoCliente = servicoCliente;

            
            if (listagemClienteControl == null)
            {
                listagemClienteControl = new TabelaCliente();
            }

            this.listagemClienteControl = listagemClienteControl;

            CarregarItens();
        }



        public override string ToolTipInserir => "Inserir Cliente";
        public override string ToolTipEditar => "Editar Cliente";
        public override string ToolTipExcluir => "Excluir Cliente";
        public override string ToolTipFiltrar => "Filtrar Cliente";
        public override string ToolTipPdf => "Gerar PDF";

        public override void Inserir()
        {
            telaClienteForm telaCliente = new telaClienteForm();

            telaCliente.onGravarRegistro += servicoCliente.Inserir;

            DialogResult result = telaCliente.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override void Editar()
        {
            Cliente cliente = ObterItemSelecionado();

            if (cliente == null)
            {
                MessageBox.Show("Selecione um cliente primeiro!", "Edição de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            telaClienteForm telaCliente = new telaClienteForm();
            telaCliente.ArrumaTela(cliente);
            telaCliente.onGravarRegistro += servicoCliente.Editar;

            DialogResult result = telaCliente.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override void Excluir()
        {
            var cliente = ObterItemSelecionado();

            if (cliente == null)
            {
                MessageBox.Show("Selecione um cliente primeiro!",
                    "Exclusão de cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o cliente {cliente.Nome}?", "Exclusão de cliente",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result result = servicoCliente.Excluir(cliente);

                if (result.IsFailed)
                {
                    MessageBox.Show(result.Errors[0].Message, "Exclusão de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            CarregarItens();
        }

        public override UserControl ObterTabela()
        {
            if (listagemClienteControl == null)
                listagemClienteControl = new TabelaCliente();
            
            return listagemClienteControl;
        }

        public override string ObterTipoCadastro() => "Tela Cliente";

        private Cliente ObterItemSelecionado()
        {
            var id = listagemClienteControl.ObterIdSelecionado();

            return repositorioCliente.SelecionarPorId(id);
        }


        public override void CarregarItens()
        {
            var listaClientes = repositorioCliente.SelecionarTodos();

            listagemClienteControl.AtualizarRegistros(listaClientes);
        }
    }
}
