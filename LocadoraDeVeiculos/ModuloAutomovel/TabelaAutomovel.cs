using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.ModuloAutomovel
{
    public partial class TabelaAutomovel : UserControl
    {
        public TabelaAutomovel()
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
            Name = "Modelo",
            HeaderText = "Modelo"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "Marca",
            HeaderText = "Marca"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "Cor",
            HeaderText = "Cor"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "Kilometragem",
            HeaderText = "Kilometragem"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "Placa",
            HeaderText = "Placa"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "CapacidadeEmLitros",
            HeaderText = "Capacidade Em Litros"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "GrupoAutomovel",
            HeaderText = "Grupo de Automovel"
        }};

            grid.Columns.AddRange(colunas);
        }


        public void AtualizarRegistros(List<Veiculo> listaVeiuclos)
        {
            grid.Rows.Clear();

            foreach (Veiculo f in listaVeiuclos)
            {
                grid.Rows.Add(f.Id,
                              f.Modelo,
                              f.Marca,
                              f.Cor,
                              f.Kilometragem,
                              f.Placa,
                              f.CapacidadeEmLitros,
                              f.GrupoAutomovel
                              );
            }
        }

        public Guid ObterIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
