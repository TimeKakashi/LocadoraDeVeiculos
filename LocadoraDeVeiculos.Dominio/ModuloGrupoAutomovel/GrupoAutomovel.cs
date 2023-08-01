using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel
{
    public class GrupoAutomovel : EntidadeBase<GrupoAutomovel>
    {
        public string Nome { get; set; }
        public List<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
        public PlanoCobranca PlanoCobranca { get; set; }
        
        public override void Atualizar(GrupoAutomovel registro)
        {
            throw new NotImplementedException();
        }
    }
}
