using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCombustivel
{
    public class Gasolina : Combustivel
    {
        public Gasolina(decimal valor)
        {
            this.valor = valor;
            this.nome = "Gasolina";
        }
    }
}
