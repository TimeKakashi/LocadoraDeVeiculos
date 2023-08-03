using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.ModuloCliente
{
    public partial class telaClienteForm : Form
    {
        public event GravarRegistroDelegate<Cliente> onGravarRegistro;
        private Cliente cliente;

        public telaClienteForm()
        {
            InitializeComponent();
            rbtnPessoaFisica.Checked = true;
            rbtnPessoaFisica.CheckedChanged += rbtnPessoaFisica_CheckedChanged;
            rbtnPessoaJuridica.CheckedChanged += rbtnPessoaJuridica_CheckedChanged;
        }


        public void ArrumaTela(Cliente cliente)
        {
            this.cliente = cliente;

            txtNome.Text = cliente.Nome;
            txtEmail.Text = cliente.Email;
            txtTelefone.Text = cliente.Telefone;
            txtEstado.Text = cliente.Estado;
            txtBairro.Text = cliente.Bairro;
            txtRua.Text = cliente.Rua;
            txtCidade.Text = cliente.Cidade;
            txtNumero.Text = cliente.Numero;

            if (cliente.Tipo == Cliente.TipoCliente.PessoaFisica)
            {
                rbtnPessoaFisica.Checked = true;
                txtCPF.Text = cliente.CPF;
                txtCNPJ.Enabled = false;
            }
            else if (cliente.Tipo == Cliente.TipoCliente.PessoaJuridica)
            {
                rbtnPessoaJuridica.Checked = true;
                txtCNPJ.Text = cliente.CNPJ;
                txtCPF.Enabled = false;
            }
        }

        public Cliente ObterCliente()
        {
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string telefone = txtTelefone.Text;
            string estado = txtEstado.Text;
            string bairro = txtBairro.Text;
            string rua = txtRua.Text;
            string cidade = txtCidade.Text;
            string numero = txtNumero.Text;

            if (rbtnPessoaFisica.Checked)
            {
                string cpf = txtCPF.Text;

                return new Cliente(Cliente.TipoCliente.PessoaFisica, nome, telefone, email, bairro, cidade, estado, numero, rua, cpf);
            }
            else
            {
                string cnpj = txtCNPJ.Text;

                return new Cliente(Cliente.TipoCliente.PessoaJuridica, nome, telefone, email, bairro, cidade, estado, numero, rua, cnpj);
            }
        }

        private void rbtnPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            txtCPF.Enabled = rbtnPessoaFisica.Checked;
            txtCNPJ.Enabled = !rbtnPessoaFisica.Checked;
        }

        private void rbtnPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            txtCNPJ.Enabled = rbtnPessoaJuridica.Checked;
            txtCPF.Enabled = !rbtnPessoaJuridica.Checked;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.cliente = ObterCliente();

            Result resultado = onGravarRegistro(cliente);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                DialogResult = DialogResult.None;

                TelaPrincipal.Instancia.AtualizarRodape(erro);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }

}
