using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
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
        public Cliente Cliente { get; set; }


        public override void Atualizar(Cupom registro)
        {
           

        }
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
    }
}
