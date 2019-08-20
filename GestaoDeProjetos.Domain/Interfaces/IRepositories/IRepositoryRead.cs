using GestaoDeProjetos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GestaoDeProjetos.Domain.Interfaces.IRepositories
{
    public interface IRepositoryRead<TEntity> : IDisposable where TEntity : EntityBase
    {
        TEntity ObterPorId(string id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> ObterTodosSemTracking();
        IEnumerable<TEntity> ObterTodosPaginado(int s, int t);
        IEnumerable<TEntity> ObterOnde(Expression<Func<TEntity, bool>> predicate);
        TEntity ObterPrimeiroOuPadrao(Expression<Func<TEntity, bool>> predicate);
        TEntity ObterUltimoOuPadrao(Expression<Func<TEntity, bool>> predicate);
        bool TemAlgum(Expression<Func<TEntity, bool>> predicate);
    }
}
