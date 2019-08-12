using GestaoDeProjetos.Domain.Entities;

namespace GestaoDeProjetos.Domain.Interfaces.IRepositories
{
    public interface IProjetoRepository : IRepositoryRead<Projeto>, IRepositoryWrite<Projeto>
    {
    }
}
