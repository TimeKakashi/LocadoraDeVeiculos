using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloParceiro
{
    public class Parceiro : EntidadeBase<Parceiro>
    {
        public string Nome { get; set; }

        public Parceiro()
        {
        }

        public Parceiro(string Nome)
        {
            this.Nome = Nome;
        }

        public Parceiro(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override string ToString()
        {
            return Nome; 
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Parceiro parceiro)
                return false;

            return Id == parceiro.Id && Nome == parceiro.Nome;
        }
    }

}
