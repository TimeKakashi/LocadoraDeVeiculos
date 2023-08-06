using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using System.Globalization;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.ModuloAutomovel
{
    public partial class TelaCombustivelForm : Form
    {
        List<Combustivel> combustivels;
        public TelaCombustivelForm(List<Combustivel> combustivels)
        {
            InitializeComponent();
            this.combustivels = combustivels;
        }

        public event GravarRegistroDelegateLista<Combustivel> onGravarRegistro;


        public void ArrumaTela()
        {
            txGasolina.Text = combustivels[0].valor.ToString();
            txAlcool.Text = combustivels[1].valor.ToString();
            txGas.Text = combustivels[2].valor.ToString();
            txDisel.Text = combustivels[3].valor.ToString();
        }

        public List<Combustivel> ObterValoresEditados()
        {

            if (decimal.TryParse(txGasolina.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal gasolina))
            {
                this.combustivels[0].valor = gasolina;
            }
            else
            {
                this.combustivels[0].valor = 0;
            }

            if (decimal.TryParse(txAlcool.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal alcool))
            {
                this.combustivels[1].valor = alcool;
            }
            else
            {
                this.combustivels[1].valor = 0;
            }

            if (decimal.TryParse(txGas.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal gas))
            {
                this.combustivels[2].valor = gas;
            }
            else
            {
                this.combustivels[2].valor = 0;
            }

            if (decimal.TryParse(txDisel.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal disel))
            {
                this.combustivels[3].valor = disel;
            }
            else
            {
                this.combustivels[3].valor = 0;
            }

            return this.combustivels;

            //decimal gasolina = decimal.Parse(txGasolina.Text);
            //decimal alcool = decimal.Parse(txAlcool.Text);
            //decimal gas = decimal.Parse(txGas.Text);
            //decimal disel = decimal.Parse(txDisel.Text);

            //this.combustivels[0].valor = gasolina;
            //this.combustivels[1].valor = alcool;
            //this.combustivels[2].valor = gas;
            //this.combustivels[3].valor = disel;

            //return combustivels;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Combustivel> combustivels = ObterValoresEditados();

            Result resultado = onGravarRegistro(combustivels);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
