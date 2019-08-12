using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;

namespace GestaoDeProjetos.Domain.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public Tarefa Adicionar(Tarefa tarefa)
        {
            _tarefaRepository.Adicionar(tarefa);
            return tarefa;
        }

        public Tarefa Atualizar(Tarefa tarefa)
        {
            _tarefaRepository.Atualizar(tarefa);
            return tarefa;
        }

        public Tarefa Remover(Tarefa tarefa)
        {
            _tarefaRepository.Remover(tarefa);
            return tarefa;
        }

        public void Dispose()
        {
            _tarefaRepository.Dispose();
        }
    }
}
