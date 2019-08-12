using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;

namespace GestaoDeProjetos.Domain.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public Projeto Adicionar(Projeto projeto)
        {
            _projetoRepository.Adicionar(projeto);
            return projeto;
        }

        public Projeto Atualizar(Projeto projeto)
        {
            _projetoRepository.Atualizar(projeto);
            return projeto;
        }

        public Projeto Remover(Projeto projeto)
        {
            _projetoRepository.Remover(projeto);
            return projeto;
        }

        public void Dispose()
        {
            _projetoRepository.Dispose();
        }
    }
}
