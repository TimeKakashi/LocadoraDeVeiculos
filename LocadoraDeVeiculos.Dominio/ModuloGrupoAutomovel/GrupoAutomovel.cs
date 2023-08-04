﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel
{
    public class GrupoAutomovel : EntidadeBase<GrupoAutomovel>
    {
        public string Nome { get; set; }
        public List<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
        public List<PlanoCobranca> Planos { get; set; } = new List<PlanoCobranca>();

        public GrupoAutomovel(string nome)
        {
            Nome = nome;
        }

        public GrupoAutomovel(string nome, Guid id) : this(nome)
        {
            this.Id = id;
        }
        public GrupoAutomovel()
        {
            
        }
        public override void Atualizar(GrupoAutomovel registro)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.Nome;
        }

        public override bool Equals(object obj)
        {
            return obj is GrupoAutomovel grupo &&
                   Id == grupo.Id &&
                   Nome == grupo.Nome;
                   
        }
    }
}
