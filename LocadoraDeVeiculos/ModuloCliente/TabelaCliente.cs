using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.ModuloCliente
{
    public partial class TabelaCliente : UserControl
    {
        public TabelaCliente()
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
            new DataGridViewTextBoxColumn()
            {
                Name = "telefone",
                HeaderText = "Telefone"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = "email",
                HeaderText = "Email"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = "tipo",
                HeaderText = "Tipo"
            }
            };

            grid.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Cliente> listaClientes)
        {
            grid.Rows.Clear();

            foreach (Cliente cliente in listaClientes)
            {
                grid.Rows.Add(cliente.Id,
                              cliente.Nome,
                              cliente.Telefone,
                              cliente.Email,
                              cliente.Tipo.ToString()
                              );
            }
        }
        public Guid ObterIdSelecionado()
        {
            return grid.SelecionarId();
        }

        internal Cliente ObterClienteSelecionado()
        {
            throw new NotImplementedException();
        }
    }

}
