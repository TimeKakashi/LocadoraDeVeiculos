﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxaServico
{
    public class TaxaServico : EntidadeBase<TaxaServico>
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Plano { get; set; }

        public TaxaServico()
        {
        }

        public TaxaServico(string nome)
        {
            Nome = nome;
        }

        public TaxaServico(string nome, decimal preco, string plano) : this(nome)
        {
            Preco = preco;
            Plano = plano;
        }

        public TaxaServico(Guid id, string nome, decimal preco, string plano) : this(nome, preco, plano) 
        {
            Id = id;
        }

        public override string ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is TaxaServico taxa && Id == taxa.Id;
        }
    }
}
