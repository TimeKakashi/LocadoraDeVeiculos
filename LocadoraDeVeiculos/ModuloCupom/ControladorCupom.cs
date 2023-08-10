using LocadoraDeVeiculos.Aplicacao.ModuloCupom;
using LocadoraDeVeiculos.Aplicacao.ModuloParceiro;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxaServico;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.ModuloParceiro;
using LocadoraDeVeiculos.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ModuloCupom
{
    public class ControladorCupom : ControladorBase
    {
        private IRepositorioCupom repositorioCupom;
        private TabelaCupom tabelaCupom;
        private ServicoCupom servicoCupom;
        private IRepositorioParceiro repositorioParceiro;

        public ControladorCupom(IRepositorioCupom repositorioCupom, ServicoCupom servicoCupom,IRepositorioParceiro repositorioParceiro)
        {
            this.repositorioCupom = repositorioCupom;
            this.servicoCupom = servicoCupom;
            this.repositorioParceiro = repositorioParceiro;
        }

        public ControladorCupom(IRepositorioCupom repositorioCupom, ServicoCupom servicoCupom)
        {
            this.repositorioCupom = repositorioCupom;
            this.servicoCupom = servicoCupom;
        }

        public override string ToolTipInserir => "Inserir Cupom!";

        public override string ToolTipEditar => "Editar Cupom!";

        public override string ToolTipExcluir => "Excluir Cupom!";

        public override string ToolTipFiltrar => "Filtrar Cupom!";

        public override string ToolTipPdf => "Gerar Pdf";

        public override string ToolTipCombustivel => "Tipo de combustivel!";

        public override void CarregarItens()
        {
            var listaCupom = repositorioCupom.SelecionarTodos();

            tabelaCupom.AtualizarRegistros(listaCupom);
        }

        public override void Editar()
        {
            Cupom cupom = ObterCupomSelecionado();

            if (cupom == null) 
            {
                MessageBox.Show("Selecione um Cupom primeiro!", "Edição de Cupom", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TelaCupomForm telaCupomForm = new TelaCupomForm(repositorioParceiro.SelecionarTodos());
            telaCupomForm.onGravarRegistro += servicoCupom.Editar;
            telaCupomForm.ConfigurarCupom(new Cupom());
            telaCupomForm.ShowDialog();
            
            DialogResult result = telaCupomForm.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        private Cupom ObterCupomSelecionado()
        {
            Guid id = tabelaCupom.ObterIdSelecionado();
            var cupom = repositorioCupom.SelecionarPorId(id);
            return cupom;
        }

        public override void Excluir()
        {
            var cupom = ObterCupomSelecionado();

            if (cupom == null) 
            {
                MessageBox.Show("Selecione um cupom primeiro!",
                    "Exclusão de cupom",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult result = MessageBox.Show($"Deseja excluir o cupom {cupom.Nome}?",
                    "Exclusão de cupom",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation);

            if (result == DialogResult.OK)
            {
                servicoCupom.Excluir(cupom);
                CarregarItens();
            }

        }

        public override void Inserir()
        {
            TelaCupomForm telaCupomForm = new TelaCupomForm(repositorioParceiro.SelecionarTodos());

            telaCupomForm.onGravarRegistro += servicoCupom.Inserir;

            telaCupomForm.ConfigurarCupom(new Cupom(),true);

            DialogResult result = telaCupomForm.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        public override UserControl ObterTabela()
        {
            if(tabelaCupom == null)
                tabelaCupom = new TabelaCupom();

            CarregarItens();

            return tabelaCupom;
                    
        }

        public override string ObterTipoCadastro() => "Cadastro de cupom";


    }
}
