using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;
using GestaoDeProjetos.Domain.Interfaces.IUoW;

namespace GestaoDeProjetos.Application.AppServices
{
    public class ProjetoAppService : AppServiceBase, IProjetoAppService
    {
        private readonly IProjetoService _projetoService;
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoAppService(IProjetoService projetoService, IProjetoRepository projetoRepository, IUnityOfWork unityOfWork) : base(unityOfWork)
        {
            _projetoService = projetoService;
            _projetoRepository = projetoRepository;
        }

        public void Dispose()
        {
            _projetoRepository.Dispose();
        }
    }
}
