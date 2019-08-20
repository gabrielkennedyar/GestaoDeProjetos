using GestaoDeProjetos.Domain.Entities;
using System;

namespace GestaoDeProjetos.Domain.Interfaces.IRepositories
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : EntityBase
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Remover(TEntity obj);
        void Remover(string id);
        int SaveChanges();
    }
}
