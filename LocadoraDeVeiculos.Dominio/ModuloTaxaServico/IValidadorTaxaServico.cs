using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxaServico
{
    public class IValidadorTaxaServico : IValidador<TaxaServico>
    {
        public ValidationResult Validate(TaxaServico registro)
        {
            throw new NotImplementedException();
        }
    }
}
