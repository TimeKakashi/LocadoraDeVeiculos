using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.ModuloGrupoAutomovel
{
    public partial class TelaGrupoAutomovelForm : Form
    {
        public TelaGrupoAutomovelForm()
        {
            InitializeComponent();
        }

        public event GravarRegistroDelegate<GrupoAutomovel> onGravarRegistro;
        private GrupoAutomovel grupoAutomovel;

        public void ArrumaTela(GrupoAutomovel grupo)
        {
            txNome.Text = grupo.Nome;
        }

        public GrupoAutomovel ObterGrupo()
        {
            string nome = txNome.Text;

            return new GrupoAutomovel(nome);
        }

        private void btnCadastarr_Click(object sender, EventArgs e)
        {
            this.grupoAutomovel = ObterGrupo();

            Result resultado = onGravarRegistro(grupoAutomovel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                //TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
