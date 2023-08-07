using FluentResults;
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
        internal Func<TaxaServico, Result> onGravarRegistro;

        private TaxaServico taxaServico;
        public TelaTaxaServicoForm()
        {
            InitializeComponent();
        }

        public  void ConfigurarTaxaServico(TaxaServico taxaServico)
        {
            this.taxaServico = taxaServico;
            txtNome.Text = taxaServico.Nome;
        }
    }
}
