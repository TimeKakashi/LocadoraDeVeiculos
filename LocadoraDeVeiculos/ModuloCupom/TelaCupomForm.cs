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
        public IRepositorioParceiro repositorioParceiro;

        public TelaCupomForm(List<Parceiro>parceiros)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarParceiros(parceiros);
        }


        public void ConfigurarCupom(Cupom cupom,bool inserindo = false)
        {
            this.cupom = cupom;
            if(!inserindo ) 
            {
                txtNome.Text = cupom.Nome;
                txtDataDeValidade.Value = cupom.DataDeValidade;
                txtValor.Text = cupom.Valor.ToString();
                comboBoxListaParceiro.SelectedItem = cupom.Parceiro;
            }
        }
        private Cupom ObterCupom(Cupom cupom)
        {
            cupom.Nome = txtNome.Text;
            cupom.Valor = Convert.ToDecimal(txtValor.Text);
            cupom.DataDeValidade = Convert.ToDateTime(txtDataDeValidade.Value);
            cupom.Parceiro = (Parceiro)comboBoxListaParceiro.SelectedItem;
            return cupom;
        }

        private void CarregarParceiros(List<Parceiro> parceiro)
        {
            comboBoxListaParceiro.Items.Clear();

            foreach (var item in parceiro)
            {
                comboBoxListaParceiro.Items.Add(item);
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            this.cupom = ObterCupom(cupom);

            Result resultado = onGravarRegistro(cupom);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
