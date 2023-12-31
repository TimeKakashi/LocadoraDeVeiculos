﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm._4._1_Acesso_a_Dados.Compartilhado
{
    public class RepositorioBaseEmOrm<T> : IRepositorioBase<T> where T : EntidadeBase<T>
    {
        protected readonly LocadoraDeVeiculosDbContext dbContext;
        protected DbSet<T> registros;

        public RepositorioBaseEmOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            this.dbContext = dbContext;
            registros = dbContext.Set<T>();
        }

        public virtual void Inserir(T novoRegistro)
        {
            registros.Add(novoRegistro);
        }

        public virtual void Editar(T registro)
        {
            registros.Update(registro);
        }

        public virtual void Excluir(T registro)
        {
            registros.Remove(registro);
        }

        public virtual bool Existe(T registro)
        {
            return registros.Contains(registro);
        }

        public virtual T SelecionarPorId(Guid id)
        {
            return registros.Find(id);
        }

        public virtual List<T> SelecionarTodos(bool Insercao = false, bool Insercao2 = false)
        {
            return registros.ToList();
        }
    }
}
