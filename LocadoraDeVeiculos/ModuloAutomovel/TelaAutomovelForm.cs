using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using Serilog;

namespace LocadoraDeVeiculos.ModuloAutomovel
{
    public partial class TelaAutomovelForm : Form
    {
        public event GravarRegistroDelegate<Veiculo> onGravarRegistro;
        private Veiculo veiculo;

        public TelaAutomovelForm(List<GrupoAutomovel> listGrupoAutomovel)
        {
            InitializeComponent();
            EncherComboBox(listGrupoAutomovel);
        }


        public void ArrumaTela(Veiculo veiculo, bool insercao = false)
        {
            this.veiculo = veiculo;

            if (!insercao)
            {
                txModelo.Text = veiculo.Modelo;

                txKilometragem.Text = veiculo.Kilometragem.ToString();

                txPlaca.Text = veiculo.Placa;

                txCapacidade.Value = veiculo.CapacidadeEmLitros;

                txMarca.Text = veiculo.Marca;

                txCor.Text = veiculo.Cor;

                cbCombustivel.SelectedItem = veiculo.EnumCombusteivel;

                cbGrupo.SelectedItem = veiculo.GrupoAutomovel;

                txtFoto.Image = veiculo.ConverterArrBytesParaImagem();
            }
        }

        public Veiculo ObterVeiculo()
        {
            veiculo.Modelo = txModelo.Text;

            if (txKilometragem.Text != "" && txKilometragem.Text != null)
                veiculo.Kilometragem = Convert.ToDecimal(txKilometragem.Text);
            else
                veiculo.Kilometragem = -1;

            veiculo.Placa = txPlaca.Text.ToUpper();

            veiculo.CapacidadeEmLitros = Convert.ToInt32(txCapacidade.Value);

            veiculo.Cor = txCor.Text;

            if (cbCombustivel.SelectedItem != null)
                veiculo.EnumCombusteivel = (EnumCombusteivel)cbCombustivel.SelectedItem;

            veiculo.Marca = txMarca.Text;

            veiculo.GrupoAutomovel = (GrupoAutomovel)cbGrupo.SelectedItem;

            veiculo.EmUso = false;

            if (txtFoto.Image != null)
                veiculo.Imagem = veiculo.ConverterImagemParaArrayByte(txtFoto.Image);

            return veiculo;
        }

        private void btnCadastarr_Click(object sender, EventArgs e)
        {
            this.veiculo = ObterVeiculo();

            Result resultado = onGravarRegistro(veiculo);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void brnCadastrar_Click(object sender, EventArgs e)
        {
            this.veiculo = ObterVeiculo();

            Result resultado = onGravarRegistro(veiculo);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                try
                {
                    txtFoto.Image = Image.FromFile(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Esse modelo de arquivo eh invalido, selecione em um formato PNG", "Inserção de Imagem",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    Log.Warning("Erro de formato de imagem, ao tentar inserir");
                }
            }
        }

        private void EncherComboBox(List<GrupoAutomovel> listGrupoAutomovel)
        {
            cbGrupo.Items.Clear();
            cbCombustivel.Items.Clear();

            foreach (var grupo in listGrupoAutomovel)
            {
                cbGrupo.Items.Add(grupo);
            }

            foreach (Enum item in Enum.GetValues(typeof(EnumCombusteivel)))
            {
                cbCombustivel.Items.Add(item);
            }
        }
    }
}
