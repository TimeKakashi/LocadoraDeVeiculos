using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.ModuloAluguel
{
    public partial class TelaDevolucaoForm : Form
    {
        Aluguel aluguel;

        public delegate Cupom procurarCombustivel(string txt);
        public delegate decimal pegarValorCombustivel(string txt);

        public event GravarRegistroDelegate<Aluguel> onGravarRegistro;
        public event procurarCombustivel onProcurarCupomNome;
        public event pegarValorCombustivel onPegarValorCombustivelNome;

        public TelaDevolucaoForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Aluguel obterAluguel()
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

            aluguel.DataDevolucao = txDataDevolucao.Value;

            aluguel.NivelTanque = (EnumNivelTanque?)cbNivelTanque.SelectedItem;

            aluguel.KmPercorrido = Convert.ToInt32(txKmPercorrido);

            if (ContainerTaxas.CheckedItems.Count > 0)
            {
                foreach (TaxaServico item in ContainerTaxas.CheckedItems)
                    aluguel.TaxasServico.Add(item);
            }

            if (ContainerTaxasAdicionais.CheckedItems.Count > 0)
            {
                foreach (TaxaServico item in ContainerTaxasAdicionais.CheckedItems)
                    aluguel.TaxasServico.Add(item);
            }

            if (ContainerTaxasAdicionais.CheckedItems.Count <= 0 && ContainerTaxas.CheckedItems.Count <= 0)
                aluguel.TaxasServico.Clear();


            aluguel.Preco = ObterPrecoFinal(aluguel.PlanoCobranca, aluguel.DataLocacao, aluguel.DataDevolucao, aluguel.DataDevolucaoPrevista, aluguel.Cupom, aluguel.TaxasServico, aluguel.KmPercorrido);

            labelValorTotal.Text = aluguel.Preco.ToString();

            return aluguel;
        }

        private decimal ObterPrecoFinal(PlanoCobranca plano, DateTime dataLocacao, DateTime? dataDevolucao, DateTime dataDevolucaoPrevista, Cupom? cupom, List<TaxaServico> taxasServico, int? kmPercorrido)
        {
            var quantidadeDiasAlugados = (int)(dataDevolucao - dataLocacao)?.TotalDays;

            bool multa = false;

            int valorDiariaMulta = 0;

            decimal valorTotal = 0;

            decimal valorCombustivel = 0;

            decimal quantidadeLitrosUsados = 0;

            if (dataDevolucao > dataDevolucaoPrevista)
            {
                var qtdDiasAtrasados = (int)(dataDevolucao - dataDevolucaoPrevista)?.TotalDays;
                valorDiariaMulta = qtdDiasAtrasados * 50;

                multa = true;
            }

            valorCombustivel = PegarValorCombustivel();

            quantidadeLitrosUsados = PegarQuantidadeDeLitrosUsados(quantidadeLitrosUsados);

            valorTotal += CalcularValorPorPlano(plano, quantidadeDiasAlugados, valorTotal);

            valorTotal += quantidadeLitrosUsados * valorCombustivel;

            valorTotal += valorDiariaMulta;

            return valorTotal;
        }

        private decimal PegarQuantidadeDeLitrosUsados(decimal quantidadeLitrosUsados)
        {
            if (aluguel.NivelTanque == EnumNivelTanque.Vazio)
            {
                quantidadeLitrosUsados = aluguel.Veiculo.CapacidadeEmLitros * 1;
            }

            else if (aluguel.NivelTanque == EnumNivelTanque.Baixo)
            {
                quantidadeLitrosUsados = aluguel.Veiculo.CapacidadeEmLitros * 0.25m;
            }

            else if (aluguel.NivelTanque == EnumNivelTanque.Medio)
            {
                quantidadeLitrosUsados = aluguel.Veiculo.CapacidadeEmLitros * 0.5m;
            }

            else if (aluguel.NivelTanque == EnumNivelTanque.Alto)
            {
                quantidadeLitrosUsados = aluguel.Veiculo.CapacidadeEmLitros * 0.75m;
            }

            else if (aluguel.NivelTanque == EnumNivelTanque.Cheio)
            {
                quantidadeLitrosUsados = 0;
            }

            return quantidadeLitrosUsados;
        }

        private decimal PegarValorCombustivel()
        {
            decimal valorCombustivel = 0;

            if (aluguel.Veiculo.EnumCombusteivel == EnumCombusteivel.Gasolina)
                valorCombustivel = onPegarValorCombustivelNome("Gasolina");

            else if (aluguel.Veiculo.EnumCombusteivel == EnumCombusteivel.Alcool)
                valorCombustivel = onPegarValorCombustivelNome("Alcool");

            else if (aluguel.Veiculo.EnumCombusteivel == EnumCombusteivel.Gas)
                valorCombustivel = onPegarValorCombustivelNome("Gás");

            else if (aluguel.Veiculo.EnumCombusteivel == EnumCombusteivel.Disel)
                valorCombustivel = onPegarValorCombustivelNome("Disel");

            return valorCombustivel;
        }

        private decimal CalcularValorPorPlano(PlanoCobranca plano, int quantidadeDiasAlugados, decimal valorTotal)
        {
            if (aluguel.PlanoCobranca.Plano == planoCobranca.Diaria)
            {
                valorTotal += plano.ValorDiaria * quantidadeDiasAlugados;

                valorTotal += (decimal)(plano.PrecoKm * aluguel.KmPercorrido);
            }

            else if (aluguel.PlanoCobranca.Plano == planoCobranca.Controlado)
            {
                valorTotal += plano.ValorDiaria * quantidadeDiasAlugados;

                int kmExtrapolados = (int)(aluguel.KmPercorrido - plano.KmDisponivel);

                if (kmExtrapolados > 0)
                    valorTotal += (decimal)(kmExtrapolados * plano.PrecoKm);

                valorTotal += (decimal)(plano.PrecoKm * aluguel.KmPercorrido);
            }

            else if (aluguel.PlanoCobranca.Plano == planoCobranca.Km_Livre)
            {
                valorTotal += plano.ValorDiaria * quantidadeDiasAlugados;
            }

            return valorTotal;
        }

        private Cupom? ObterCupom(string text)
        {
            Cupom cupom = onProcurarCupomNome(text);

            return cupom;
        }

        public void ArrumarTela(Aluguel aluguel)
        {
            this.aluguel = aluguel;

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
}
