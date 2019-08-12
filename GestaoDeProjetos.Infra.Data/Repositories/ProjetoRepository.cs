using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Infra.Data.Context;

namespace GestaoDeProjetos.Infra.Data.Repositories
{
    public class ProjetoRepository : RepositoryBase<Projeto>, IProjetoRepository
    {
        public ProjetoRepository(GestaoDeProjetosContext context) : base(context)
        {

        }
    }
}
