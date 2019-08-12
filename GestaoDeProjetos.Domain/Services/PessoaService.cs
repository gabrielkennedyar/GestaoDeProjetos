using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;

namespace GestaoDeProjetos.Domain.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public Pessoa Adicionar(Pessoa pessoa)
        {
            _pessoaRepository.Adicionar(pessoa);
            return pessoa;
        }

        public Pessoa Atualizar(Pessoa pessoa)
        {
            _pessoaRepository.Atualizar(pessoa);
            return pessoa;
        }

        public Pessoa Remover(Pessoa pessoa)
        {
            _pessoaRepository.Remover(pessoa);
            return pessoa;
        }

        public void Dispose()
        {
            _pessoaRepository.Dispose();
        }
    }
}
