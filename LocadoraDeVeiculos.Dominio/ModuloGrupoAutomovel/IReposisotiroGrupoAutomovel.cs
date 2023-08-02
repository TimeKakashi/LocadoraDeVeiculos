﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel
{
    public interface IReposisotiroGrupoAutomovel : IRepositorioBase<GrupoAutomovel>
    {
        GrupoAutomovel SelecionarPorNome(string nome);
    }
}
