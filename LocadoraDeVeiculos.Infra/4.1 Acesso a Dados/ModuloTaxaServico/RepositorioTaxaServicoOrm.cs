using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloTaxaServico;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloTaxaServico
{
    public class RepositorioTaxaServico : RepositorioBaseEmOrm<TaxaServico> , IRepositorioTaxaServico
    {
        public RepositorioTaxaServico(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {

        }

        TaxaServico IRepositorioTaxaServico.SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
