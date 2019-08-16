using System;
using System.Collections.Generic;
using AutoMapper;
using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Application.ViewModels;
using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;
using GestaoDeProjetos.Domain.Interfaces.IUoW;

namespace GestaoDeProjetos.Application.AppServices
{
    public class EquipeAppService : AppServiceBase, IEquipeAppService
    {
        private readonly IEquipeService _equipeService;
        private readonly IEquipeRepository _equipeRepository;
        private readonly IMapper _mapper;


        public EquipeAppService(IEquipeService equipeService, IEquipeRepository equipeRepository, IUnityOfWork unityOfWork, IMapper mapper) : base(unityOfWork)
        {
            _equipeService = equipeService;
            _equipeRepository = equipeRepository;
            _mapper = mapper;
        }

        public IEnumerable<EquipeViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EquipeViewModel>>(_equipeRepository.ObterTodos());
        }

        public EquipeViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<EquipeViewModel>(_equipeRepository.ObterPorId(id));
        }

        public EquipeViewModel Adicionar(EquipeViewModel equipeViewModel)
        {
            var equipe = _mapper.Map<Equipe>(equipeViewModel);
            equipe = _equipeService.Adicionar(equipe);

            if (!SaveChanges())
            {
                throw new Exception();
            }

            return _mapper.Map<EquipeViewModel>(equipe);
        }

        public void Editar(EquipeViewModel equipeViewModel)
        {
            var equipeEditada = _mapper.Map<Equipe>(equipeViewModel);
            var equipe = _equipeRepository.ObterPorId(equipeViewModel.Id);

            equipe.AtualizarDados(equipeEditada);

            equipe = _equipeService.Atualizar(equipe);

            if (!SaveChanges())
            {
                throw new Exception();
            }
        }

        public void Deletar(Guid id)
        {
            var pessoa = _equipeRepository.ObterPorId(id);

            pessoa = _equipeService.Remover(pessoa);

            if (!SaveChanges())
            {
                throw new Exception();
            }
        }

        public void Dispose()
        {
            _equipeRepository.Dispose();
        }
       
    }
}