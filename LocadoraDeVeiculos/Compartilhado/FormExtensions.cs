using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Compartilhado
{
    public static class FormExtensions
    {
        public static void ConfigurarDialog(this Form form)
        {
            form.ShowIcon = false;
            form.ShowInTaskbar = false;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormClosing += Form_FormClosing;
        }

        private static void Form_FormClosing(object? sender, FormClosingEventArgs e)
        {
            TelaPrincipal.Instancia.AtualizarRodape(string.Empty);
        }
    }
}
