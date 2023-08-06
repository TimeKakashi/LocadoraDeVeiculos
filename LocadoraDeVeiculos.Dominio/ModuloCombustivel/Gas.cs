using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Combustivel
{
    public class Gas : Combustivel
    {
        public Gas(decimal valor)
        {
            this.valor = valor;
            this.nome = "Gas";
        }
    }
}
