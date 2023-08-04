﻿using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.ModuloFuncionario;

namespace LocadoraDeVeiculos.ModuloAutomovel
{
    public class ControladorAutomovel : ControladorBase
    {
        private IRepositorioAutomovel repositorioAutomovel;
        IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel;
        private TabelaAutomovel tabelaAutomovel;
        private ServicoAutomovel servicoAutomovel;

        public ControladorAutomovel(IRepositorioAutomovel repositorioAutomovel,IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel ,ServicoAutomovel servicoAutomovel)
        {
            this.repositorioAutomovel = repositorioAutomovel;
            this.reposisotiroGrupoAutomovel = reposisotiroGrupoAutomovel;
            this.servicoAutomovel = servicoAutomovel;

            if (tabelaAutomovel == null)
                tabelaAutomovel = new TabelaAutomovel();
        }

        public override string ToolTipInserir => "Inserir Veiculo";
        public override string ToolTipEditar => "Editar Veiculo";
        public override string ToolTipExcluir => "Excluir Veiculo";
        public override string ToolTipFiltrar => "Filtrar Veiculo";
        public override string ToolTipPdf => "Gerar PDF";
        public override string ToolTipCombustivel => "Atualizar Valores Combustível";

        public override bool AtualizarValoresCombustivel => true;

        public override void CarregarItens()
        {
            var listaAutomovel = repositorioAutomovel.SelecionarTodos();

            tabelaAutomovel.AtualizarRegistros(listaAutomovel);
        }

        public override void Editar()
        {
            Veiculo veiculo = ObterItemSelecionado();

            if (veiculo == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro!", "Edição de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaAutomovelForm telaFuncionario = new TelaAutomovelForm(reposisotiroGrupoAutomovel.SelecionarTodos());

            telaFuncionario.ArrumaTela(veiculo);

            telaFuncionario.onGravarRegistro += servicoAutomovel.Editar;

            DialogResult result = telaFuncionario.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override void Excluir()
        {
            var veiculo = ObterItemSelecionado();

            if (veiculo == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro!",
                    "Exclusão de veiculo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o veiculo {veiculo.Modelo}, Marca: {veiculo.Marca}?", "Exclusão de veiculo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (opcaoEscolhida == DialogResult.OK)
            {
                Result result = servicoAutomovel.Excluir(veiculo);

                if (result.IsFailed)
                {
                    MessageBox.Show(result.Errors[0].Message, "Exclusão de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            CarregarItens();
        }

        public override void Inserir()
        {
            TelaAutomovelForm telaAutomovel = new TelaAutomovelForm(reposisotiroGrupoAutomovel.SelecionarTodos());

            telaAutomovel.onGravarRegistro += servicoAutomovel.Inserir;

            telaAutomovel.ArrumaTela(new Veiculo(), true);

            if (telaAutomovel.ShowDialog() == DialogResult.OK)
                CarregarItens();
        }

        public override UserControl ObterTabela()
        {
            if (tabelaAutomovel == null)
                tabelaAutomovel = new TabelaAutomovel();

            return tabelaAutomovel;
        }

        public override string ObterTipoCadastro() => "Cadastro de Veículos";

        private Veiculo ObterItemSelecionado()
        {
            var id = tabelaAutomovel.ObterIdSelecionado();

            return repositorioAutomovel.SelecionarPorId(id);
        }
    }
}
