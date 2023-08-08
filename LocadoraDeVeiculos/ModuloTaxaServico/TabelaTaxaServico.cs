using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
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

namespace LocadoraDeVeiculos.ModuloTaxaServico
{
    public partial class TabelaTaxaServico : UserControl
    {
        public TabelaTaxaServico()
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
            Name = "Nome",
            HeaderText = "Nome"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "Preço",
            HeaderText = "Preço"
        }   
            };


            grid.Columns.AddRange(colunas);
        }
        public void AtualizarRegistros(List<TaxaServico> listaTaxaServico)
        {
            grid.Rows.Clear();

            foreach (TaxaServico f in listaTaxaServico)
            {
                grid.Rows.Add(f.Nome,
                              f.Preco
                              );
            }
        }
        public Guid ObterIdSelecionado()
        {
            return grid.SelecionarId();
        }

    }

    
}
