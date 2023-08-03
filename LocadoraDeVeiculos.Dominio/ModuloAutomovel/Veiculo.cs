using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public string Modelo { get; set; }
        public GrupoAutomovel GrupoAutomovel { get; set; }

        public Veiculo(string modelo)
        {
            this.Modelo = modelo;
        }

        public Veiculo(string modelo, GrupoAutomovel grupo) : this(modelo)
        {
            this.GrupoAutomovel = grupo;
        }
        public override void Atualizar(Veiculo registro)
        {
            throw new NotImplementedException();
        }
    }
}
