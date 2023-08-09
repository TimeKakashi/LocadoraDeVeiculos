using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        
        public Cupom(string nome,decimal valor, DateTime dataDeValidade, Parceiro parceiro)
        {
            this.Nome = nome;
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
            return obj is ModuloCondutor.Condutor cupom && Id == cupom.Id;
        }
    }
}
