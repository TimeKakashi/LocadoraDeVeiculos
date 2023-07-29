using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public interface IRepositorioFuncionario : IRepositorioBase<Funcionario>
    {
        Funcionario SelecionarPorNome(string nome);
    }
}
