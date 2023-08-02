﻿using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LocadoraDeVeiculos.ModuloPlanoCobranca
{
    public partial class TelaPlanoCobranca : Form
    {
        public event GravarRegistroDelegate<PlanoCobranca> onGravarRegistro;

        private PlanoCobranca plano;

        public TelaPlanoCobranca(List<GrupoAutomovel> grupoAutomovels)
        {
            InitializeComponent();

            EncherCbBoxGrupoAutomovel(grupoAutomovels);
            EncherCBBoxTipoPlano();
        }

        public void ArrumaTela(PlanoCobranca plano, bool Inserindo =  false)
        {
            this.plano = plano;

            if (!Inserindo)
            {
                txKmDisponiveis.Text = plano.KmDisponivel.ToString();
                txPrecoDiaria.Text = plano.ValorDiaria.ToString();
                txPrecoKm.Text = plano.PrecoKm.ToString();

                cbGrupo.SelectedItem = plano.GrupoAutomovel;

                cbTipoPlano.SelectedItem = plano.Plano;
            }
        }

        public PlanoCobranca ObterPlanoCobranca()
        {
            plano.Plano = (planoCobranca)cbTipoPlano.SelectedItem;
            plano.ValorDiaria = Convert.ToDecimal(txPrecoDiaria.Text);

            if (txPrecoKm.Text != "")
                plano.PrecoKm = Convert.ToDecimal(txPrecoKm.Text);

            if(txKmDisponiveis.Text != "")
                plano.KmDisponivel = Convert.ToInt32(txKmDisponiveis.Text);

            plano.GrupoAutomovel = (GrupoAutomovel)cbGrupo.SelectedItem;

            return plano;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            this.plano = ObterPlanoCobranca();

            Result resultado = onGravarRegistro(plano);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipal.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void EncherCbBoxGrupoAutomovel(List<GrupoAutomovel> grupoAutomovels)
        {
            cbGrupo.Items.Clear();

            foreach (var grupo in grupoAutomovels)
            {
                cbGrupo.Items.Add(grupo);
            }
        }

        private void EncherCBBoxTipoPlano()
        {
            cbTipoPlano.Items.Clear();

            foreach (var grupo in Enum.GetValues(typeof(planoCobranca)))
                cbTipoPlano.Items.Add(grupo);
        }
    }
}