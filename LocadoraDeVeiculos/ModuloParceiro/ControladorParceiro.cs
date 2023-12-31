﻿using LocadoraDeVeiculos.Aplicacao.ModuloParceiro;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.ModuloParceiro
{
    public class ControladorParceiro : ControladorBase
    {
        private IRepositorioParceiro repositorioParceiro;
        private TabelaParceiro tabelaParceiro;
        private ServicoParceiro servicoParceiro;

        public ControladorParceiro(IRepositorioParceiro repositorioParceiro, ServicoParceiro servicoParceiro)
        {
            this.repositorioParceiro = repositorioParceiro;
            this.servicoParceiro = servicoParceiro;
        }

        public override string ToolTipInserir => "Inserir Parceiro";

        public override string ToolTipEditar => "Editar Parceiro";

        public override string ToolTipExcluir => "Excluir Parceiro";

        public override string ToolTipFiltrar => "Filtar Parceiro";

        public override string ToolTipPdf => "Gerar Pdf";

        public override string ToolTipCombustivel => "Atualizar Valores Combustível";


        public override void CarregarItens()
        {
            var listaParceiro = repositorioParceiro.SelecionarTodos();

            tabelaParceiro.AtualizarRegistros(listaParceiro);
        }

        public override void Editar()
        {
           Parceiro parceiro = ObterParceiroSelecionado();

            if (parceiro == null)
            {
                MessageBox.Show("Selecione um parceiro primeiro!", "Edição de parceiro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TelaParceiroForm telaParceiroForm = new TelaParceiroForm();

            telaParceiroForm.ConfigurarParceiro(parceiro);

            telaParceiroForm.onGravarRegistro += servicoParceiro.Editar;

            DialogResult result = telaParceiroForm.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();

        }

        private Parceiro ObterParceiroSelecionado()
        {
            var id = tabelaParceiro.ObterIdSelecionado();

            return repositorioParceiro.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            var parceiro = ObterParceiroSelecionado();

            if (parceiro == null)
            {
                MessageBox.Show("Selecione um parceiro primeiro!",
                    "Exclusão de parceiro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult result = MessageBox.Show($"Deseja excluir o parceiro {parceiro.Nome}?",
                    "Exclusão de parceiro",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation);

            if (result == DialogResult.OK)
            {
                servicoParceiro.Excluir(parceiro);
                CarregarItens();
            }
        }



        public override void Inserir()
        {
            TelaParceiroForm telaParceiroForm = new TelaParceiroForm();

            telaParceiroForm.onGravarRegistro += servicoParceiro.Inserir;

            telaParceiroForm.ConfigurarParceiro(new Parceiro());

            DialogResult result = telaParceiroForm.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override UserControl ObterTabela()
        {
            if (tabelaParceiro == null)
                tabelaParceiro = new TabelaParceiro();

            CarregarItens();

            return tabelaParceiro;
        }

        public override string ObterTipoCadastro() => "Cadastro de Parceiro";

    }
}
