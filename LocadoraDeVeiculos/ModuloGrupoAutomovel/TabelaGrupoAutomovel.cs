using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.ModuloGrupoAutomovel
{
    public partial class TabelaGrupoAutomovel : UserControl
    {
        public TabelaGrupoAutomovel()
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
            Name = "nome",
            HeaderText = "Nome"
        }};

            grid.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<GrupoAutomovel> listaGrupoAutomoveis)
        {
            grid.Rows.Clear();

            foreach (var f in listaGrupoAutomoveis)
                grid.Rows.Add(f.Id, f.Nome);
        }
        public Guid ObterIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
