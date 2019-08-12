using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;

namespace GestaoDeProjetos.Domain.Services
{
    public class EquipeService : IEquipeService
    {
        private readonly IEquipeRepository _equipeRepository;

        public EquipeService(IEquipeRepository equipeRepository)
        {
            _equipeRepository = equipeRepository;
        }

        public Equipe Adicionar(Equipe equipe)
        {
            _equipeRepository.Adicionar(equipe);
            return equipe;
        }

        public Equipe Atualizar(Equipe equipe)
        {
            _equipeRepository.Atualizar(equipe);
            return equipe;
        }

        public Equipe Remover(Equipe equipe)
        {
            _equipeRepository.Remover(equipe);
            return equipe;
        }

        public void Dispose()
        {
            _equipeRepository.Dispose();
        }
    }
}
