using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.ModuloTaxaServico
{
    public partial class TelaTaxaServicoForm : Form
    {
        public event GravarRegistroDelegate<TaxaServico> onGravarRegistro;

        private TaxaServico taxaServico;
        private IRepositorioTaxaServico repositorioTaxaServico;
        public TelaTaxaServicoForm()
        {
            InitializeComponent();
            this.repositorioTaxaServico = repositorioTaxaServico;
        }

        public void ConfigurarTaxaServico(TaxaServico taxaServico)
        {
            this.taxaServico = taxaServico;
            txtNome.Text = taxaServico.Nome;
        }

        private TaxaServico ObterTaxaServico()
        {
            taxaServico.Nome = txtNome.Text;
            string plano = "";

            if (gbRadioBTN.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked) == null)
            {
                taxaServico = null;
            }
            else
            {
                plano = gbRadioBTN.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;

                if (plano == "Preço Fixo")
                    taxaServico.Plano = "Preço Fixo";
                else
                    taxaServico.Plano = "Cobrança Diaria";

            }
            taxaServico.Preco = Convert.ToDecimal(txPreco.Text);
            return taxaServico;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.taxaServico = ObterTaxaServico();

            Result resultado = onGravarRegistro(taxaServico);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
