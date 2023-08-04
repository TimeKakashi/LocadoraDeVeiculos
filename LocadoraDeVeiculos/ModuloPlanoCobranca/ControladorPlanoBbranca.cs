﻿using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ModuloPlanoCobranca
{
    public class ControladorPlanoBbranca : ControladorBase
    {
        private ServicoPlanoCobranca servicoPlanoCobranca;
        private TabelaPlanoCobranca tabelaPlanoCobranca;
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel;
        public ControladorPlanoBbranca(ServicoPlanoCobranca servicoPlanoCobranca, IRepositorioPlanoCobranca repositorioPlanoCobranca, IReposisotiroGrupoAutomovel reposisotiroGrupoAutomovel)
        {
            this.servicoPlanoCobranca = servicoPlanoCobranca;
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.reposisotiroGrupoAutomovel = reposisotiroGrupoAutomovel;

            if (tabelaPlanoCobranca == null)
                tabelaPlanoCobranca = new TabelaPlanoCobranca();

            CarregarItens();
        }


        public override string ToolTipInserir => "Inserir Plano de Cobranca";

        public override string ToolTipEditar => "Editar Plano de Cobranca";

        public override string ToolTipExcluir => "Excluir Plano de Cobranca";

        public override string ToolTipFiltrar => "Filtrar Plano de Cobranca";

        public override string ToolTipPdf => "Gerar Pdf Plano de Cobranca";

        public override string ToolTipCombustivel => "Atualizar Valores Combustível";


        public override void Inserir()
        {
            TelaPlanoCobranca telaPlano = new TelaPlanoCobranca(reposisotiroGrupoAutomovel.SelecionarTodos()) ;

            telaPlano.onGravarRegistro += servicoPlanoCobranca.Inserir;

            telaPlano.ArrumaTela(new PlanoCobranca(), true);

            DialogResult result = telaPlano.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override void Editar()
        {
            PlanoCobranca plano = ObterItemSelecionado();

            if (plano == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro!", "Edição de funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaPlanoCobranca telaPlano = new TelaPlanoCobranca(reposisotiroGrupoAutomovel.SelecionarTodos());
            telaPlano.ArrumaTela(plano);
            telaPlano.onGravarRegistro += servicoPlanoCobranca.Editar;

            DialogResult result = telaPlano.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override void Excluir()
        {
            var plano = ObterItemSelecionado();

            if (plano == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro!",
                    "Exclusão de funcionario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o plano de cobranca?", "Exclusão de funcionario",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (opcaoEscolhida == DialogResult.OK)
            {
                Result result = servicoPlanoCobranca.Excluir(plano);

                if (result.IsFailed)
                {
                    MessageBox.Show(result.Errors[0].Message, "Exclusão de plano", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            CarregarItens();
        }

        public override UserControl ObterTabela()
        {
            if (tabelaPlanoCobranca == null)
                tabelaPlanoCobranca = new TabelaPlanoCobranca();

            return tabelaPlanoCobranca;
        }

        public override string ObterTipoCadastro() => "Cadastro de Planos de Cobranças";

        private PlanoCobranca ObterItemSelecionado()
        {
            var id = tabelaPlanoCobranca.ObterIdSelecionado();

            return repositorioPlanoCobranca.SelecionarPorId(id);
        }

        public override void CarregarItens()
        {
            var listaFuncionario = repositorioPlanoCobranca.SelecionarTodos();

            tabelaPlanoCobranca.AtualizarRegistros(listaFuncionario);
        }
    }
}
