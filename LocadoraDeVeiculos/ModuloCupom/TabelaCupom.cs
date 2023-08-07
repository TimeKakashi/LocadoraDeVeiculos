using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.ModuloCupom
{
    public partial class TabelaCupom : UserControl
    {
        
        public TabelaCupom()
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
            Name = "Valor",
            HeaderText = "Valor"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "Data de Validade",
            HeaderText = "Data de Validade"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "Parceiro",
            HeaderText = "Parceiro"
        }
            };

            grid.Columns.AddRange(colunas);
        }
        public void AtualizarRegistros(List<Cupom> listaCupom)
        {
            grid.Rows.Clear();

            foreach (Cupom f in listaCupom)
            {
                grid.Rows.Add(f.Nome,
                              f.Valor,
                              f.DataDeValidade,
                              f.parceiro
                              );
            }
        }

        public Guid ObterNomeSelecionado()
        {
            return grid.SelecionarId();
        }

        internal object ObteridSelecionado()
        {
            throw new NotImplementedException();
        }
    }
}
