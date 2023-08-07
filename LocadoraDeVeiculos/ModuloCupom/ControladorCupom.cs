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

        public ControladorCupom(IRepositorioCupom repositorioCupom, ServicoCupom servicoCupom)
        {
            this.repositorioCupom = repositorioCupom;
            this.servicoCupom = servicoCupom;

            if (tabelaCupom == null)
                tabelaCupom = new TabelaCupom();

            CarregarItens();
        }

        public override string ToolTipInserir => "Inserir Cupom!";

        public override string ToolTipEditar => "Editar Cupom!";

        public override string ToolTipExcluir => "Excluir Cupom!";

        public override string ToolTipFiltrar => "Filtrar Cupom!";

        public override string ToolTipPdf => "Gerar Pdf";

        public override void CarregarItens()
        {
            var listaCupom = IRepositorioCupom.SelecionarTodos();

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
            TelaCupomForm telaCupomForm = new TelaCupomForm();
            telaCupomForm.onGravarRegistro += servicoCupom.Editar;
            telaCupomForm.ConfigurarCupom(new Cupom());
            telaCupomForm.ShowDialog();
            
            DialogResult result = telaCupomForm.ShowDialog();

            if (result == DialogResult.OK)
                CarregarItens();
        }

        private Cupom ObterCupomSelecionado()
        {
            Guid id = tabelaCupom.ObteridSelecionado();
            var cupom = repositorioCupom.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObterTabela()
        {
            throw new NotImplementedException();
        }

        public override string ObterTipoCadastro()
        {
            throw new NotImplementedException();
        }
    }
}
