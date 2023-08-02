using FluentResults;
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

namespace LocadoraDeVeiculos.ModuloParceiro
{
    public partial class TelaParceiroForm : Form
    {
        internal Func<Parceiro, Result> onGravarRegistro;

        public TelaParceiroForm()
        {
            InitializeComponent();
        }
    }
}
