using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;

namespace GestaoDeProjetos.Domain.Services
{
    public class PessoaEquipeService : IPessoaEquipeService
    {
        private readonly IPessoaEquipeRepository _pessoaEquipeRepository;

        public PessoaEquipeService(IPessoaEquipeRepository pessoaEquipeRepository)
        {
            _pessoaEquipeRepository = pessoaEquipeRepository;
        }

        public PessoaEquipe Adicionar(PessoaEquipe pessoaEquipe)
        {
            _pessoaEquipeRepository.Adicionar(pessoaEquipe);
            return pessoaEquipe;
        }

        public PessoaEquipe Atualizar(PessoaEquipe pessoaEquipe)
        {
            _pessoaEquipeRepository.Atualizar(pessoaEquipe);
            return pessoaEquipe;
        }

        public PessoaEquipe Remover(PessoaEquipe pessoaEquipe)
        {
            _pessoaEquipeRepository.Remover(pessoaEquipe);
            return pessoaEquipe;
        }

        public void Dispose()
        {
            _pessoaEquipeRepository.Dispose();
        }
    }
}
