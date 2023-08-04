﻿using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public interface IValidadorAutomovel : IValidador<Veiculo>
    {
        
    }
}
