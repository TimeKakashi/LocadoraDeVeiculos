﻿using LocadoraDeVeiculos.Dominio.ModuloCondutor;
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
        }

        internal void AtualizarRegistros(List<Condutor> listaCondutor)
        {
            throw new NotImplementedException();
        }

        internal object ObterIdSelecionado()
        {
            throw new NotImplementedException();
        }
    }
}