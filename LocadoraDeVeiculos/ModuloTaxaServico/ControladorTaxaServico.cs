using LocadoraDeVeiculos.Aplicacao.ModuloParceiro;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxaServico;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ModuloTaxaServico
{
    public class ControladorTaxaServico : ControladorBase
    {
        private IRepositorioTaxaServico repositorioTaxaServico;
        private TabelaTaxaServico tabelaTaxaServico;
        private ServicoTaxaServico servicoTaxaServico;
        private object telaTaxaServicoForm;

        public ControladorTaxaServico(IRepositorioTaxaServico repositorioTaxaServico, ServicoTaxaServico servicoTaxaServico) 
        {
            this.repositorioTaxaServico = repositorioTaxaServico;
            this.servicoTaxaServico = servicoTaxaServico;

            if (tabelaTaxaServico == null)
                tabelaTaxaServico = new TabelaTaxaServico();

            CarregarItens();
        }
        public override string ToolTipInserir => "Inserir TaxaServico";

        public override string ToolTipEditar => "Editar TaxaServico";

        public override string ToolTipExcluir => "Excluir TaxaServico";

        public override string ToolTipFiltrar => "Filtar TaxaServico";

        public override string ToolTipPdf => "Gerar Pdf";

        public override void CarregarItens()
        {
            var listaTaxaServico = repositorioTaxaServico.SelecionarTodos();

            tabelaTaxaServico.AtualizarRegistros(listaTaxaServico);
        }

        public override void Editar()
        {
            TaxaServico taxaServico = ObterTaxaServicoSelecionado();

            if (taxaServico == null)
            {
                MessageBox.Show("Selecione uma Taxa e Servico primeiro!", "Edição de Taxa e Servico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TelaTaxaServicoForm telaTaxaServicoForm = new TelaTaxaServicoForm();
            telaTaxaServicoForm.ShowDialog();
            telaTaxaServicoForm.onGravarRegistro += servicoTaxaServico.Editar;

            DialogResult result = telaTaxaServicoForm.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        private TaxaServico ObterTaxaServicoSelecionado()
        {
            var id = tabelaTaxaServico.ObterIdSelecionado();

            return repositorioTaxaServico.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            var taxaServico = ObterTaxaServicoSelecionado();

            if ( taxaServico == null) 
            {
                MessageBox.Show("Selecione uma Taxa e Servico primeiro!",
                    "Exclusão de Taxa e Servico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
        }

        public override void Inserir()
        {
            TelaParceiroForm telaParceiroForm = new TelaParceiroForm();

            telaTaxaServicoForm.onGravarRegistro += servicoTaxaServico.Inserir;

            telaTaxaServicoForm.ConfigurarTaxaServico(new Parceiro());

            DialogResult result = telaTaxaServicoForm.ShowDialog();

            if (result == DialogResult.OK) 
                CarregarItens();
        }

        public override UserControl ObterTabela()
        {
            return ObterTabela(tabelaTaxaServico);
        }

        public override UserControl ObterTabela(UserControl tabelaTaxaServico)
        {
            if (tabelaTaxaServico == null)
                tabelaTaxaServico = new TabelaTaxaServico();

            return tabelaTaxaServico;
        }

        public override string ObterTipoCadastro() => "Cadastro de Taxa e Servico";

    }
}
