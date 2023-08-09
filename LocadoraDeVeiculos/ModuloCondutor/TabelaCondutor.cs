using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.ModuloCondutor
{
    public partial class TabelaCondutor : UserControl
    {
        public TabelaCondutor()
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
                Name = "cpf",
                HeaderText = "CPF"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = "cnh",
                HeaderText = "CNH"
            },
            new DataGridViewTextBoxColumn()
            {
                Name = "validadeCnh",
                HeaderText = "Validade CNH"
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
            }
            };

            grid.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Condutor> listaCondutor)
        {
            grid.Rows.Clear();

            foreach (Condutor c in listaCondutor)
            {
                grid.Rows.Add(c.Id,
                              c.Nome,
                              c.CPF,
                              c.CNH,
                              c.ValidadeCNH,
                              c.Telefone,
                              c.Email
                              );
            }
        }

        public Guid ObterIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }

}
