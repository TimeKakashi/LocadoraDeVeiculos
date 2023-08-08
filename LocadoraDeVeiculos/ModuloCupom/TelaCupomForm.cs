using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.ModuloCupom
{
    public partial class TelaCupomForm : Form
    {
        public event GravarRegistroDelegate<Cupom> onGravarRegistro;

        public Cupom cupom;

        public TelaCupomForm()
        {
            InitializeComponent();
        }
        public void ConfigurarCupom(Cupom cupom)
        {
            this.cupom = cupom;
            txtNome.Text = cupom.Nome;
            txtDataDeValidade.Value = cupom.DataDeValidade;
            txtValor.Text = cupom.Valor.ToString();
            txtParceiro.SelectedItem = cupom.Parceiro;
        }
        private Cupom ObterCupom()
        {
            cupom.Nome = txtNome.Text;
            cupom.Valor = Convert.ToDecimal(txtValor.Text);
            cupom.DataDeValidade = txtDataDeValidade.Value;
            cupom.Parceiro = (Parceiro)txtParceiro.SelectedItem;
            return cupom;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.cupom = ObterCupom();

            Result resultado = onGravarRegistro(cupom);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }


    }
}
