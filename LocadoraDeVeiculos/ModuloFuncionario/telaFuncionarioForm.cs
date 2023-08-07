using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraDeVeiculos.ModuloFuncionario
{
    public partial class telaFuncionarioForm : Form
    {
        public event GravarRegistroDelegate<Funcionario> onGravarRegistro;
        private Funcionario funcionario;
        public telaFuncionarioForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();

        }

        public void ArrumaTela(Funcionario funcionario, bool inserir = false)
        {
            this.funcionario = funcionario;

            if (!inserir)
            {
                txNome.Text = funcionario.Nome;
                txData.Text = funcionario.DataEntrada.ToString();
                txSalario.Text = funcionario.Salario.ToString();
            }
        }

        public Funcionario ObterFuncionario()
        {
            string nome = txNome.Text;
            var data = txData.Value;
            decimal salario;



            if (!decimal.TryParse(txSalario.Text, out salario))
            {
                salario = 0;
            }

            funcionario.Nome = nome;
            funcionario.DataEntrada = data;
            funcionario.Salario = salario;

            return funcionario;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            this.funcionario = ObterFuncionario();

            Result resultado = onGravarRegistro(funcionario);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
