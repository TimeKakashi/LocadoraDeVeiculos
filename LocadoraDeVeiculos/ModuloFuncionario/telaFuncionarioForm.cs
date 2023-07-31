using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.ModuloFuncionario
{
    public partial class telaFuncionarioForm : Form
    {
        public event GravarRegistroDelegate<Funcionario> onGravarRegistro;
        private Funcionario funcionario;
        public telaFuncionarioForm()
        {
            InitializeComponent();
        }

        public void ArrumaTela(Funcionario funcionario)
        {
            txNome.Text = funcionario.Nome;
            txData.Text = funcionario.DataEntrada.ToString();
            txSalario.Text = funcionario.Salario.ToString();
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

            return new Funcionario(nome, salario, data);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            this.funcionario = ObterFuncionario();

            Result resultado = onGravarRegistro(funcionario);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                //TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
