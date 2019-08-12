using GestaoDeProjetos.Domain.Entities;

namespace GestaoDeProjetos.Domain.Interfaces.IRepositories
{
    public interface ITarefaRepository : IRepositoryRead<Tarefa>, IRepositoryWrite<Tarefa>
    {
    }
}
