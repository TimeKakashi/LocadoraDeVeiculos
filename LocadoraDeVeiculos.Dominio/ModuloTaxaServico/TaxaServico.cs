using LocadoraDeVeiculos.Dominio.Compartilhado;
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
        

        public TaxaServico(Guid id, string nome) : this(nome)
        {
            Id = id;
        }


    }
}
