using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;

namespace LocadoraDeVeiculos.ModuloPlanoCobranca
{
    public partial class TabelaPlanoCobranca : UserControl
    {
        public TabelaPlanoCobranca()
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
            Name = "plano",
            HeaderText = "Plano"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "precoKm",
            HeaderText = "Preço Km"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "kmDisponivel",
            HeaderText = "Km Dispinivel"
        }
        ,
        new DataGridViewTextBoxColumn()
        {
            Name = "valorDiaria",
            HeaderText = "Valor Diaria"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "grupoAutomovel",
            HeaderText = "Grupo Automovel"
        }
            };

            grid.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<PlanoCobranca> listaPlano)
        {
            grid.Rows.Clear();

            foreach (PlanoCobranca plano in listaPlano)
            {
                grid.Rows.Add(plano.Id, plano.Plano, plano.PrecoKm, plano.KmDisponivel, plano.ValorDiaria, plano.GrupoAutomovel);
            }
        }
        public Guid ObterIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
