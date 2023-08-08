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
        public decimal Preço { get; set; }

        public override void Atualizar(TaxaServico registro)
        {
            Nome = registro.Nome;
        }

        public TaxaServico(Guid id, string nome) : this(nome)
        {
            Id = id;
        }

        public TaxaServico(string nome)
        {
            Nome = nome;
        }

        public TaxaServico()
        {
        }
    }
}
