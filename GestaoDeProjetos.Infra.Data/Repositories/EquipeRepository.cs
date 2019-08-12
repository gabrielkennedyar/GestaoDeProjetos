using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Infra.Data.Context;

namespace GestaoDeProjetos.Infra.Data.Repositories
{
    public class EquipeRepository : RepositoryBase<Equipe>, IEquipeRepository
    {
        public EquipeRepository(GestaoDeProjetosContext context) : base(context)
        {

        }
    }
}
