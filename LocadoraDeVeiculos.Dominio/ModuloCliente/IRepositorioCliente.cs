using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public interface IRepositorioCliente : IRepositorioBase<Cliente>
    {
        Cliente SelecionarPorNome(string nome);

       
        Cliente SelecionarPorCPF(string cpf);
        Cliente SelecionarPorCNPJ(string cnpj);
        Cliente SelecionarPorId(int id);
    }

}
