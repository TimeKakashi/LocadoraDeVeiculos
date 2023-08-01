using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ModuloParceiro
{
    public class Parceiro : EntidadeBase<Parceiro>
    {
        public override void Atualizar(Parceiro registro)
        {
            Nome = registro.Nome;
        }
        public Parceiro()
        {

        }

        public Parceiro(int id, string nome) : this(nome)
        {
            Id = id;
        }
        public string Nome { get; set; }

        public Parceiro(string Nome)
        {
            this.Nome = Nome;
        }
    }
}
