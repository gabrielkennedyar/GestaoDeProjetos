using GestaoDeProjetos.Domain.Entities;

namespace GestaoDeProjetos.Domain.Interfaces.IRepositories
{
    public interface IEquipeRepository : IRepositoryRead<Equipe>, IRepositoryWrite<Equipe>
    {
    }
}
