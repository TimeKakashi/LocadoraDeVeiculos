﻿using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraDeVeiculos.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase
    {
        private IRepositorioFuncionario repositorioFuncionario;
        private ServicoFuncionario servicoFuncionario;
        private TabelaFuncionario tabelaFuncionario;


        public ControladorFuncionario(IRepositorioFuncionario repositorioFuncionario, ServicoFuncionario servicoFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.servicoFuncionario = servicoFuncionario;
        }

        public override string ToolTipInserir => "Inserir Funcionario";

        public override string ToolTipEditar => "Editar Funcionario";

        public override string ToolTipExcluir => "Excluir Funcionario";

        public override string ToolTipFiltrar => "Filtrar Funcionario";

        public override string ToolTipPdf => "Gerar Pdf";

        public override string ToolTipCombustivel => "Atualizar Valores Combustível";


        public override void Inserir()
        {
            telaFuncionarioForm telaFuncionario = new telaFuncionarioForm();

            telaFuncionario.onGravarRegistro += servicoFuncionario.Inserir;

            telaFuncionario.ArrumaTela(new Funcionario(), true);

            DialogResult result = telaFuncionario.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override void Editar()
        {
            Funcionario funcionario = ObterItemSelecionado();

            if (funcionario == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro!", "Edição de funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            telaFuncionarioForm telaFuncionario = new telaFuncionarioForm();
            telaFuncionario.ArrumaTela(funcionario);
            telaFuncionario.onGravarRegistro += servicoFuncionario.Editar;

            DialogResult result = telaFuncionario.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override void Excluir()
        {
            var funcionario = ObterItemSelecionado();

            if (funcionario == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro!",
                    "Exclusão de funcionario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o funcionario {funcionario.Nome}?", "Exclusão de funcionario",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (opcaoEscolhida == DialogResult.OK)
            {
                Result result = servicoFuncionario.Excluir(funcionario);

                if (result.IsFailed)
                {
                    MessageBox.Show(result.Errors[0].Message, "Exclusão de funcionario", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            CarregarItens();
        }

        public override UserControl ObterTabela()
        {
            if (tabelaFuncionario == null)
                tabelaFuncionario = new TabelaFuncionario();

            CarregarItens();

            return tabelaFuncionario;
        }

        public override string ObterTipoCadastro() => "Cadastro de Funcionário";

        private Funcionario ObterItemSelecionado()
        {
            var id = tabelaFuncionario.ObterIdSelecionado();

            return repositorioFuncionario.SelecionarPorId(id);
        }

        public override void CarregarItens()
        {
            var listaFuncionario = repositorioFuncionario.SelecionarTodos();

            tabelaFuncionario.AtualizarRegistros(listaFuncionario);
        }
    }
}
