using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase<PlanoCobranca>
    {
        public planoCobranca Plano { get; set; }
        public decimal ValorDiaria { get; set; }
        public decimal? PrecoKm { get; set; }
        public int? KmDisponivel { get; set; }

        public PlanoCobranca()
        {
            
        }

        public PlanoCobranca( planoCobranca plano, decimal valorDiaria, decimal precoKm)
        {
            Plano = plano;
            ValorDiaria = valorDiaria;
            PrecoKm = precoKm;
        }

        public PlanoCobranca( planoCobranca plano, decimal valorDiaria, decimal precoKm, int kmDisponivel) : this(plano, valorDiaria, precoKm)
        {
            KmDisponivel = kmDisponivel;
        }

        public PlanoCobranca( planoCobranca plano, decimal valorDiaria)
        {
            Plano = plano;
            ValorDiaria = valorDiaria;
        }

        public override void Atualizar(PlanoCobranca registro)
        {
            throw new NotImplementedException();
        }
    }
}
