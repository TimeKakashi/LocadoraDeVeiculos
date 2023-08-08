using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.ModuloCondutor
{
    public partial class telaCondutorForm : Form
    {
        public event GravarRegistroDelegate<Condutor> OnGravarRegistro;
        private Condutor condutor;
        private Cliente clienteRelacionado;
        private List<Cliente> listaClinte;

        public telaCondutorForm(List<Cliente> listaClientes)
        {
            InitializeComponent();
            chkClienteCondutor.Checked = true;
            chkClienteCondutor.CheckedChanged += chkClienteCondutor_CheckedChanged;
            this.listaClinte = listaClientes;

            PopularComboBox(listaClientes);
        }

        public telaCondutorForm()
        {
        }

        public void PopularComboBox(List<Cliente> clientes)
        {
            cmbClientes.Items.Clear();

            foreach(var item in clientes)
            {
                cmbClientes.Items.Add(item);
            }
        }

        public void ArrumaTela(Condutor condutor, bool inserir = false)
        {
            this.condutor = condutor;

            if (inserir)
            {
                chkClienteCondutor.Checked = true;
            }
            else
            {

                chkClienteCondutor.Checked = (clienteRelacionado?.Id == condutor.ClienteId);



                if (chkClienteCondutor.Checked)
                {
                    txtNome.Text = clienteRelacionado.Nome;
                    txtEmail.Text = clienteRelacionado.Email;
                    txtTelefone.Text = clienteRelacionado.Telefone;
                    txtCPF.Text = clienteRelacionado.CPF;
                }
                else
                {
                    txtNome.Text = "";
                    txtEmail.Text = "";
                    txtTelefone.Text = "";
                    txtCPF.Text = "";
                }
            }

            txtCNH.Text = condutor.CNH;
            dtpValidadeCNH.Value = condutor.ValidadeCNH;
        }

        private void chkClienteCondutor_CheckedChanged(object sender, EventArgs e)
        {

            if (chkClienteCondutor.Checked)
            {
                txtNome.Text = clienteRelacionado.Nome;
                txtEmail.Text = clienteRelacionado.Email;
                txtTelefone.Text = clienteRelacionado.Telefone;
                txtCPF.Text = clienteRelacionado.CPF;

                txtNome.Enabled = false;
                txtEmail.Enabled = false;
                txtTelefone.Enabled = false;
                txtCPF.Enabled = false;
            }
            else
            {
                txtNome.Text = "";
                txtEmail.Text = "";
                txtTelefone.Text = "";
                txtCPF.Text = "";

                txtNome.Enabled = true;
                txtEmail.Enabled = true;
                txtTelefone.Enabled = true;
                txtCPF.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public Condutor ObterCondutor()
        {
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string telefone = txtTelefone.Text;
            string cpf = txtCPF.Text;
            string cnh = txtCNH.Text;
            DateTime validadeCNH = dtpValidadeCNH.Value;

            if (chkClienteCondutor.Checked)
            {

                nome = clienteRelacionado.Nome;
                email = clienteRelacionado.Email;
                telefone = clienteRelacionado.Telefone;
                cpf = clienteRelacionado.CPF;
            }

            condutor.Nome = nome;
            condutor.Email = email;
            condutor.Telefone = telefone;
            condutor.CPF = cpf;
            condutor.CNH = cnh;
            condutor.ValidadeCNH = validadeCNH;

            return condutor;
        }


        public void ReceberClienteRelacionado(Cliente cliente)
        {
            clienteRelacionado = cliente;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.condutor = ObterCondutor();

            Result resultado = OnGravarRegistro(condutor);

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
