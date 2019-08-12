using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;
using GestaoDeProjetos.Domain.Interfaces.IUoW;

namespace GestaoDeProjetos.Application.AppServices
{
    public class PessoaEquipeAppService : AppServiceBase, IPessoaEquipeAppService
    {
        private readonly IPessoaEquipeService _pessoaEquipeService;
        private readonly IPessoaEquipeRepository _pessoaEquipeRepository;

        public PessoaEquipeAppService(IPessoaEquipeService pessoaEquipeService, IPessoaEquipeRepository pessoaEquipeRepository, IUnityOfWork unityOfWork) : base(unityOfWork)
        {
            _pessoaEquipeService = pessoaEquipeService;
            _pessoaEquipeRepository = pessoaEquipeRepository;
        }

        public void Dispose()
        {
            _pessoaEquipeRepository.Dispose();
        }
    }
}
