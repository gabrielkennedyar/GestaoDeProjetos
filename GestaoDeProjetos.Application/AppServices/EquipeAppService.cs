using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;
using GestaoDeProjetos.Domain.Interfaces.IUoW;

namespace GestaoDeProjetos.Application.AppServices
{
    public class EquipeAppService : AppServiceBase, IEquipeAppService
    {
        private readonly IEquipeService _equipeService;
        private readonly IEquipeRepository _equipeRepository;

        public EquipeAppService(IEquipeService equipeService, IEquipeRepository equipeRepository, IUnityOfWork unityOfWork) : base(unityOfWork)
        {
            _equipeService = equipeService;
            _equipeRepository = equipeRepository;
        }

        public void Dispose()
        {
            _equipeRepository.Dispose();
        }
    }
}
