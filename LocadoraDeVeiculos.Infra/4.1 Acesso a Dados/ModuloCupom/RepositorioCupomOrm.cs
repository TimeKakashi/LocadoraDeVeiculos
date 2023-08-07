using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloCupom
{
    public interface IRepositorioCupom : IRepositorioBase<Cupom>
    {
        public RepositorioCupomOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {

        }
        public override void Editar(Cupom registro)
        {
            Cupom parceiroEncontrado = registros.FirstOrDefault(x => x.Nome == registro.Nome);

            parceiroEncontrado.Nome = registro.Nome;

            dbContext.SaveChanges();

        }
        public Cupom SelecionarPorNome(string nome)
        {

            return registros.FirstOrDefault(registros => registros.Nome == nome);
        }
    }
}
