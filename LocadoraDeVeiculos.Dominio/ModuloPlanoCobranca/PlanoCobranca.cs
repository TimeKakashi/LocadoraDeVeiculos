using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase<PlanoCobranca>
    {
        public planoCobranca Plano { get; set; }
        public decimal ValorDiaria { get; set; }
        public decimal? PrecoKm { get; set; }
        public int? KmDisponivel { get; set; }
        public GrupoAutomovel GrupoAutomovel { get; set; }

        public PlanoCobranca()
        {
            
        }

        public PlanoCobranca( planoCobranca plano, decimal valorDiaria, decimal precoKm)
        {
            Plano = plano;
            ValorDiaria = valorDiaria;
            PrecoKm = precoKm;
        }

        public PlanoCobranca( planoCobranca plano, decimal valorDiaria, decimal precoKm, int kmDisponivel1, GrupoAutomovel grupo) : this(plano, valorDiaria, precoKm)
        {
            KmDisponivel = kmDisponivel1;
        }

        public override void Atualizar(PlanoCobranca registro)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return obj is PlanoCobranca grupo &&
                   Id == grupo.Id;

        }
    }
}
