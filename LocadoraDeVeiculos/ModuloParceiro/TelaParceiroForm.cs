using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.ModuloParceiro
{
    public partial class TelaParceiroForm : Form
    {
        public event GravarRegistroDelegate<Parceiro> onGravarRegistro;

        private Parceiro parceiro;

        public TelaParceiroForm()
        {
            InitializeComponent();

        }
        public Parceiro ObterParceiro()
        {
            parceiro.Nome = txtNome.Text;

            return parceiro;
        }

        public void ConfigurarParceiro(Parceiro parceiro)
        {
            this.parceiro = parceiro;
            txtNome.Text = parceiro.Nome;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.parceiro = ObterParceiro();

            Result resultado = onGravarRegistro(parceiro);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
