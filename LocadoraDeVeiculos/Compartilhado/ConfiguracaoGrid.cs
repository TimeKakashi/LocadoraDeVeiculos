namespace LocadoraDeVeiculos.Compartilhado
{
    public static class ConfiguracaoGrid
    {
        public static void ConfigurarGridSomenteLeitura(DataGridView grid)
        {
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;

            grid.BorderStyle = BorderStyle.None;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            grid.MultiSelect = false;
            grid.ReadOnly = true;

            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoGenerateColumns = false;
        }

        public static void ConfigurarGridZebrado(DataGridView grid)
        {
            Font font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

            DataGridViewCellStyle linhaEscura = new DataGridViewCellStyle
            {
                BackColor = Color.LightGray,
                Font = font,
                ForeColor = Color.Black,
                SelectionBackColor = Color.LightYellow,
                SelectionForeColor = Color.Black
            };

            grid.AlternatingRowsDefaultCellStyle = linhaEscura;

            DataGridViewCellStyle linhaClara = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                Font = font,
                SelectionBackColor = Color.LightYellow,
                SelectionForeColor = Color.Black
            };

            grid.RowsDefaultCellStyle = linhaClara;
        }

        public static Guid SelecionarId(this DataGridView grid)
        {
            const int firstLine = 0, firstColumn = 0;
            if (grid.SelectedRows.Count == 0)
                return default;

            object value = grid.SelectedRows[firstLine].Cells[firstColumn].Value;

            if (value == null)
                return default;

            return Guid.Parse(value.ToString());
        }
    }
}
