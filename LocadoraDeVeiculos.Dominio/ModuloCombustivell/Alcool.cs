using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCombustivell
{
    public class Alcool : Combustivel
    {
        public Alcool(decimal valor)
        {
            this.valor = valor;
            this.nome = "Alcool";
        }
    }
}
