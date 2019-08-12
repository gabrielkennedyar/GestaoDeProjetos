using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Infra.Data.Context;

namespace GestaoDeProjetos.Infra.Data.Repositories
{
    public class PessoaEquipeRepository : RepositoryBase<PessoaEquipe>, IPessoaEquipeRepository
    {
        public PessoaEquipeRepository(GestaoDeProjetosContext context) : base(context)
        {

        }
    }
}
