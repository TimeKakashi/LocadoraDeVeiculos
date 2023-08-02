using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloCliente
{
    public class RepositorioClienteOrm : RepositorioBaseEmOrm<Cliente>, IRepositorioCliente
    {
        public RepositorioClienteOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public Cliente SelecionarPorCPF(string cpf)
        {
            return registros.FirstOrDefault(x => x.CPF == cpf);
        }

        public Cliente SelecionarPorCNPJ(string cnpj)
        {
            return registros.FirstOrDefault(x => x.CNPJ == cnpj);
        }


        public Cliente SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }
    }

}
