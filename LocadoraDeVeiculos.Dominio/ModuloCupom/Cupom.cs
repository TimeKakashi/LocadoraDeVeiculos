using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCupom
{
    public class Cupom : EntidadeBase<Cupom>
    {
        private object registro;

        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataDeValidade { get; set; }
        public Parceiro parceiro { get; set; }
        public override void Atualizar(Cupom registro)
        {
            Nome = registro.Nome;
        }
        public Cupom () 
        {

        }

        public Cupom(Guid id, string nome, decimal valor, DateTime dataDeValidade, Parceiro parceiro)
        {
            this.Nome = nome;
        }
        
        public Cupom(string Nome)
        {
            this.Nome = Nome;
        }
    }
}
