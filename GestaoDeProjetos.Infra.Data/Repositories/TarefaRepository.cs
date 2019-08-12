using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Infra.Data.Context;

namespace GestaoDeProjetos.Infra.Data.Repositories
{
    public class TarefaRepository : RepositoryBase<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(GestaoDeProjetosContext context) : base(context)
        {

        }
    }
}
