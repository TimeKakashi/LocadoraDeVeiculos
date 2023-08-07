using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public DateTime ValidadeCNH { get; set; }
        public Cliente Cliente { get; set; }

        public Condutor()
        {
            Id = Guid.NewGuid();
        }

        public Condutor(string nome, string cpf, string cnh, DateTime validadeCNH, Cliente cliente)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
            CNH = cnh;
            ValidadeCNH = validadeCNH;
            Cliente = cliente;
        }

        public override void Atualizar(Condutor registro)
        {
            throw new NotImplementedException();
        }
    }


}
