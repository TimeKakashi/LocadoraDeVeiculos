using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;

namespace LocadoraDeVeiculos.ModuloAluguel
{
    public partial class TabelaAluguel : UserControl
    {
        public TabelaAluguel()
        {
            InitializeComponent();
            ConfigurarColunas();
            ConfiguracaoGrid.ConfigurarGridSomenteLeitura(grid);
            ConfiguracaoGrid.ConfigurarGridZebrado(grid);
        }

        private void ConfigurarColunas()
        {
            DataGridViewColumn[] colunas = new DataGridViewColumn[]
            {
        new DataGridViewTextBoxColumn()
        {
            Name = "id",
            HeaderText = "Id"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "NomoCondutor",
            HeaderText = "Cliente"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "Veiculo",
            HeaderText = "Veiculo"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "PlanoSelecionado",
            HeaderText = "Plano Selecionado"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "DataDeSaida",
            HeaderText = "Data De Saida"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "DataPrevista",
            HeaderText = "Data Prevista"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "DataDeDevolucao",
            HeaderText = "Data de Devolucao"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "ValorTotal",
            HeaderText = "Valor Total"
        }};

            grid.Columns.AddRange(colunas);
        }


        public void AtualizarRegistros(List<Aluguel> listaAluguel)
        {
            grid.Rows.Clear();

            foreach (Aluguel a in listaAluguel)
            {
                grid.Rows.Add(a.Id,
                              a.Cliente.Nome,
                              a.Veiculo.Modelo,
                              a.PlanoCobranca.Plano,
                              a.DataLocacao,
                              a.DataDevolucaoPrevista,
                              a.DataDevolucao,
                              a.Preco
                              );
            }
        }

        public Guid ObterIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
