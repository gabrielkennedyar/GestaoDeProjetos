using GestaoDeProjetos.Domain.Entities;
using System;

namespace GestaoDeProjetos.Domain.Interfaces.IServices
{
    public interface ITarefaService : IDisposable
    {
        Tarefa Adicionar(Tarefa tarefa);
        Tarefa Atualizar(Tarefa tarefa);
        Tarefa Remover(Tarefa tarefa);
    }
}
