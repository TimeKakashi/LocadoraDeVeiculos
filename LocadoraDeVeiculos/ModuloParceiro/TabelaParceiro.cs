using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.ModuloParceiro
{
    public partial class TabelaParceiro : UserControl
    {
        public TabelaParceiro()
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
        },

            };

            grid.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Parceiro> listaParceiro)
        {
            grid.Rows.Clear();

            foreach (Parceiro f in listaParceiro)
            {
                grid.Rows.Add(f.Id,
                              f.Nome
                              );
            }
        }
        public Guid ObterIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
