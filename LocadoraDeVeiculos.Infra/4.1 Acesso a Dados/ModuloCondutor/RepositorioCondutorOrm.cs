using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.ModuloCondutor
{
    public class RepositorioCondutorOrm : RepositorioBaseEmOrm<Condutor>, IRepositorioCondutor
    {
        public RepositorioCondutorOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public Condutor SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }

        public Condutor SelecionarPorId(object id)
        {
            if (id is Guid condutorId)
            {
                return registros.FirstOrDefault(x => x.Id == condutorId);
            }
            return null;
        }

        public override void Editar(Condutor registro)
        {
            Condutor condutorRegistrado = registros.FirstOrDefault(x => x.Id == registro.Id);

            condutorRegistrado.Nome = registro.Nome;
            condutorRegistrado.CPF = registro.CPF;
            condutorRegistrado.CNH = registro.CNH;
            condutorRegistrado.ValidadeCNH = registro.ValidadeCNH;
            condutorRegistrado.Telefone = registro.Telefone;
            condutorRegistrado.Email = registro.Email;

            dbContext.SaveChanges();
        }

    }


}
