﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.Dominio.ModuloCupom
{
    public class Cupom : EntidadeBase<Cupom>
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDeValidade { get; set; }
        public Parceiro Parceiro { get; set; }
      
        public Cupom () 
        {

        }

        public Cupom(Guid id, string nome, decimal valor, DateTime dataDeValidade, Parceiro parceiro)
        {
            this.Nome = nome;
            this.Id = id;
            this.Valor = valor;
            this.DataDeValidade = dataDeValidade;
            this.Parceiro = parceiro;
        }
        
        public override string ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cupom cupom && Id == cupom.Id;
        }
    }
}
