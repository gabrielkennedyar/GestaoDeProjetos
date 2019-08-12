using GestaoDeProjetos.Domain.Entities;

namespace GestaoDeProjetos.Domain.Interfaces.IRepositories
{
    public interface IPessoaRepository : IRepositoryRead<Pessoa>, IRepositoryWrite<Pessoa>
    {
    }
}
