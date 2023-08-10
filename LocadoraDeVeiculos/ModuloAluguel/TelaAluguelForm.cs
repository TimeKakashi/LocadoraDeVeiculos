using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using Microsoft.Identity.Client.Extensibility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {

        public delegate Cupom progurarCupom(string txt);

        public event GravarRegistroDelegate<Aluguel> onGravarRegistro;
        public event progurarCupom onProcurarCupom;

        private Aluguel aluguel;
        private List<Cupom> listaCupom;

        public TelaAluguelForm(List<Funcionario> listFuncionario, List<Cliente> ListaCliente,
            List<GrupoAutomovel> ListagrupoAutomovels, List<TaxaServico> Listtaxas, List<Cupom> listCupom)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.listaCupom = listaCupom;

            EncherComboBox(listFuncionario, ListaCliente, ListagrupoAutomovels, listCupom);

            PopularContainerTaxas(Listtaxas);
        }

        private void PopularContainerTaxas(List<TaxaServico> listtaxas)
        {
            ContainerTaxas.Items.Clear();

            foreach (var item in listtaxas)
            {
                ContainerTaxas.Items.Add(item);
            }
        }

        private void EncherComboBox
            (
            List<Funcionario> listFuncionario, List<Cliente> listaCliente,
            List<GrupoAutomovel> listagrupoAutomovels, List<Cupom> listCupom
            )
        {

            EcherComboBoxFuncionario(listFuncionario);

            EncherComboBoxCliente(listaCliente);

            EncherComboBoxGrupoAutomovel(listagrupoAutomovels);
        }

        private void EncherComboBoxCondutor(List<Dominio.ModuloCondutor.Condutor> listCondutor)
        {
            cbCondutor.Items.Clear();

            foreach (var item in listCondutor)
            {
                cbCondutor.Items.Add(item);
            }
        }

        private void EncherComboBoxPlanoCobranca(List<PlanoCobranca> listPlanoCobranca)
        {
            cbPlanoCobranca.Items.Clear();

            foreach (var item in listPlanoCobranca)
            {
                cbPlanoCobranca.Items.Add(item);
            }
        }

        private void EncherComboBoxGrupoAutomovel(List<GrupoAutomovel> listagrupoAutomovels)
        {
            cbGrupoAutomoveis.Items.Clear();

            foreach (var item in listagrupoAutomovels)
            {
                cbGrupoAutomoveis.Items.Add(item);
            }
        }

        private void EncherComboBoxCliente(List<Cliente> listaCliente)
        {
            cbCliente.Items.Clear();

            foreach (var item in listaCliente)
            {
                cbCliente.Items.Add(item);
            }
        }

        private void EcherComboBoxFuncionario(List<Funcionario> listFuncionario)
        {
            cbFuncionario.Items.Clear();

            foreach (var item in listFuncionario)
            {
                cbFuncionario.Items.Add(item);
            }
        }

        private void EncherComboBoxVeiculo(List<Veiculo> listVeiculo)
        {
            cbAutomovel.Items.Clear();

            foreach (var item in listVeiculo)
            {
                cbAutomovel.Items.Add(item);
            }
        }

        public void ArrumaTela(Aluguel aluguel, bool insercao = false)
        {
            this.aluguel = aluguel;

            if (!insercao)
            {
                if (aluguel.Cupom != null)
                    txCupom.Text = aluguel.Cupom.Valor.ToString();

                txDataLocacao.Value = aluguel.DataLocacao;

                txDataPrevista.Value = aluguel.DataDevolucaoPrevista;

                txKmAutomovel.Text = aluguel.Veiculo.Kilometragem.ToString();

                cbFuncionario.SelectedItem = aluguel.Funcionario;

                cbCliente.SelectedItem = aluguel.Cliente;

                cbGrupoAutomoveis.SelectedItem = aluguel.GrupoAutomovel;

                cbPlanoCobranca.SelectedItem = aluguel.PlanoCobranca;

                cbCondutor.SelectedItem = aluguel.Condutor;

                cbAutomovel.SelectedItem = aluguel.Veiculo;

                for (int i = 0; i < ContainerTaxas.Items.Count; i++)
                {
                    TaxaServico taxa = (TaxaServico)ContainerTaxas.Items[i];

                    if (aluguel.TaxasServico.Contains(taxa))
                        ContainerTaxas.SetItemChecked(i, true);
                }
            }
        }

        private Aluguel ObterAluguel()
        {
            aluguel.Funcionario = (Funcionario)cbFuncionario.SelectedItem;
            aluguel.Cliente = (Cliente)cbCliente.SelectedItem;
            aluguel.GrupoAutomovel = (GrupoAutomovel)cbGrupoAutomoveis.SelectedItem;
            aluguel.PlanoCobranca = (PlanoCobranca)cbPlanoCobranca.SelectedItem;
            aluguel.Cupom = ObterCupom(txCupom.Text);
            aluguel.Condutor = (Condutor)cbCondutor.SelectedItem;
            aluguel.Veiculo = (Veiculo)cbAutomovel.SelectedItem;

            aluguel.DataLocacao = txDataLocacao.Value;

            aluguel.DataDevolucaoPrevista = txDataPrevista.Value;

            if (ContainerTaxas.CheckedItems.Count > 0)
            {
                foreach (TaxaServico item in ContainerTaxas.CheckedItems)
                    aluguel.TaxasServico.Add(item);
            }
            else
            {
                aluguel.TaxasServico.Clear();
            }


            aluguel.Preco = ObterPreco(aluguel.PlanoCobranca, aluguel.Cupom, aluguel.DataLocacao, aluguel.DataDevolucaoPrevista, aluguel.TaxasServico);

            labelValorTotal.Text = aluguel.Preco.ToString();

            DesmarcarItens();

            return aluguel;
        }

        private Cupom? ObterCupom(string text)
        {
            Cupom cupom = onProcurarCupom(text);

            return cupom;
        }

        private void btnCupom_Click(object sender, EventArgs e)
        {
            string cupomtxt = txCupom.Text;

            if (string.IsNullOrEmpty(cupomtxt))
                return;

            aluguel.Cupom = ObterCupom(cupomtxt);
        }

        private void DesmarcarItens()
        {
            for (int i = 0; i < ContainerTaxas.Items.Count; i++)
            {
                TaxaServico taxa = (TaxaServico)ContainerTaxas.Items[i];

                if (!aluguel.TaxasServico.Contains(taxa))
                    ContainerTaxas.SetItemChecked(i, false);
            }
        }

        private decimal ObterPreco(PlanoCobranca plano, Cupom cupom, DateTime dataLocacao, DateTime dataDevolucaoPrevista, List<TaxaServico> taxasServico)
        {
            var quantiadeDias = dataDevolucaoPrevista.Day - dataLocacao.Day;

            decimal valor = plano.ValorDiaria * quantiadeDias;

            if (cupom != null)
                valor -= cupom.Valor;

            if (aluguel.TaxasServico.Count > 0)
            {
                foreach (var item in aluguel.TaxasServico)
                {
                    if (item.Plano == "Plano Diário")
                        valor += item.Preco * quantiadeDias;
                    else
                        valor += item.Preco;
                }
            }

            return valor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.aluguel = ObterAluguel();

            Result resultado = onGravarRegistro(aluguel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void cbCliente_SelectedValueChanged(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)cbCliente.SelectedItem;

            cbCondutor.Enabled = true;

            cbCondutor.SelectedItem = null;

            EncherComboBoxCondutor(cliente.Condutores);
        }

        private void cbGrupoAutomoveis_SelectedValueChanged(object sender, EventArgs e)
        {
            GrupoAutomovel grupoAutomovel = (GrupoAutomovel)cbGrupoAutomoveis.SelectedItem;

            cbAutomovel.Enabled = true;

            cbAutomovel.SelectedItem = null;

            cbPlanoCobranca.Enabled = true;

            cbPlanoCobranca.SelectedItem = null;

            EncherComboBoxVeiculo(grupoAutomovel.Veiculos);

            EncherComboBoxPlanoCobranca(grupoAutomovel.Planos);
        }

        private void cbAutomovel_SelectedValueChanged(object sender, EventArgs e)
        {
            Veiculo veiculo = (Veiculo)cbAutomovel.SelectedItem;

            txKmAutomovel.Text = veiculo.Kilometragem.ToString();
        }


    }
}
