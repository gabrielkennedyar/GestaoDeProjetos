using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GestaoDeProjetos.Infra.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryRead<TEntity>, IRepositoryWrite<TEntity> where TEntity : EntityBase, new()
    {
        protected GestaoDeProjetosContext Db;
        protected DbSet<TEntity> DbSet;

        protected RepositoryBase(GestaoDeProjetosContext Context)
        {
            Db = Context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual void Remover(Guid id)
        {
            var entity = new TEntity { Id = id };
            Remover(entity);
        }

        public virtual void Remover(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> ObterTodosSemTracking()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public virtual TEntity ObterPorId(string id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> ObterTodosPaginado(int s, int t)
        {
            return DbSet.Take(s).Skip(t);
        }

        public IEnumerable<TEntity> ObterOnde(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public TEntity ObterPrimeiroOuPadrao(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public TEntity ObterUltimoOuPadrao(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.LastOrDefault(predicate);
        }

        public bool TemAlgum(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
