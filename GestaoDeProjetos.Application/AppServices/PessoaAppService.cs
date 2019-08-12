using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;
using GestaoDeProjetos.Domain.Interfaces.IUoW;

namespace GestaoDeProjetos.Application.AppServices
{
    public class PessoaAppService : AppServiceBase, IPessoaAppService
    {
        private readonly IPessoaService _pessoaService;
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaAppService(IPessoaService pessoaService, IPessoaRepository pessoaRepository, IUnityOfWork unityOfWork) : base(unityOfWork)
        {
            _pessoaService = pessoaService;
            _pessoaRepository = pessoaRepository;
        }

        public void Dispose()
        {
            _pessoaRepository.Dispose();
        }
    }
}
