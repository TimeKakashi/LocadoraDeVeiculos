﻿using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override void Inserir()
        {
            telaFuncionarioForm telaFuncionario = new telaFuncionarioForm();

            telaFuncionario.onGravarRegistro += servicoFuncionario.Inserir;

            DialogResult result = telaFuncionario.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override void Editar()
        {
            Funcionario materia = ObterItemSelecionado();

            if (materia == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro!", "Edição de funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            telaFuncionarioForm telaMateria = new telaFuncionarioForm();
            telaMateria.ArrumaTela(materia);
            telaMateria.onGravarRegistro += servicoFuncionario.Editar;

            DialogResult result = telaMateria.ShowDialog();

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
                tabelaFuncionario=  new TabelaFuncionario();

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
