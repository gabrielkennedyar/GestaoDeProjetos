using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;
using GestaoDeProjetos.Domain.Interfaces.IUoW;

namespace GestaoDeProjetos.Application.AppServices
{
    public class TarefaAppService : AppServiceBase, ITarefaAppService
    {
        private readonly ITarefaService _tarefaService;
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaAppService(ITarefaService tarefaService, ITarefaRepository tarefaRepository, IUnityOfWork unityOfWork) : base(unityOfWork)
        {
            _tarefaService = tarefaService;
            _tarefaRepository = tarefaRepository;
        }

        public void Dispose()
        {
            _tarefaRepository.Dispose();
        }
    }
}
