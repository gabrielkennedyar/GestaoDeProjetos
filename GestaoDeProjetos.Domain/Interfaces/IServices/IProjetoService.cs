using GestaoDeProjetos.Domain.Entities;
using System;

namespace GestaoDeProjetos.Domain.Interfaces.IServices
{
    public interface IProjetoService : IDisposable
    {
        Projeto Adicionar(Projeto projeto);
        Projeto Atualizar(Projeto projeto);
        Projeto Remover(Projeto projeto);
    }
}
