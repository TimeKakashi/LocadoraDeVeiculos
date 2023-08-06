using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.Combustivel
{
    public class Combustivel : EntidadeBase<Combustivel>
    {
        public string nome;
        public decimal valor { get; set; }

        public override void Atualizar(Combustivel registro)
        {
            throw new NotImplementedException();
        }
    }
}
