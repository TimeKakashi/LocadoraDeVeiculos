using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloParceiro
{
    public class Parceiro : EntidadeBase<Parceiro>
    {
        public string Nome { get; set; }

        public override void Atualizar(Parceiro registro)
        {
            Nome = registro.Nome;
        }
        public Parceiro() { }

        public Parceiro(Guid id, string nome) : this(nome)
        {
            Id = id;
        }
        
        public Parceiro(string Nome)
        {
            this.Nome = Nome;
        }

    }
}
