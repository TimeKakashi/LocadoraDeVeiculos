using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public interface IRepositorioCombustivelJson
    {
        void EditarValores(List<Combustivel> listaValores);
        List<Combustivel> SelecionarTodos();
    }
}
