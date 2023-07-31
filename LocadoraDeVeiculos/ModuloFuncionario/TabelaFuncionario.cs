﻿using LocadoraDeVeiculos.Dominio.ModuloFuncionario;

namespace LocadoraDeVeiculos.ModuloFuncionario
{
    public partial class TabelaFuncionario : UserControl
    {
        public TabelaFuncionario()
        {
            InitializeComponent();
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
            Name = "Data",
            HeaderText = "Data Admissão"
        },
        new DataGridViewTextBoxColumn()
        {
            Name = "Salario",
            HeaderText = "Salário"
        }
            };

            grid.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Funcionario> listaFuncionarios)
        {
            grid.Rows.Clear();

            foreach (Funcionario f in listaFuncionarios)
            {
                grid.Rows.Add(f.Id,
                              f.Nome,
                              f.DataEntrada,
                              f.Salario
                              );
            }
        }
        public int ObterIdSelecionado()
        {
            if (grid.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(grid.SelectedRows[0].Cells["id"].Value);

            return id;
        }
    }
}