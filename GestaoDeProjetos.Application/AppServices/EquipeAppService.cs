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
        private readonly IPessoaEquipeService _pessoaEquipeService;
        private readonly IPessoaEquipeRepository _pessoaEquipeRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;


        public EquipeAppService(IEquipeService equipeService, IEquipeRepository equipeRepository, IPessoaEquipeService pessoaEquipeService, IPessoaEquipeRepository pessoaEquipeRepository, IPessoaRepository pessoaRepository, IUnityOfWork unityOfWork, IMapper mapper) : base(unityOfWork)
        {
            _equipeService = equipeService;
            _equipeRepository = equipeRepository;
            _pessoaEquipeService = pessoaEquipeService;
            _pessoaEquipeRepository = pessoaEquipeRepository;
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        public IEnumerable<EquipeViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EquipeViewModel>>(_equipeRepository.ObterTodos());
        }

        public EquipeViewModel ObterPorId(string id)
        {
            return _mapper.Map<EquipeViewModel>(_equipeRepository.ObterPorId(id));
        }

        public EquipeViewModel Adicionar(EquipeViewModel equipeViewModel, string coordenadorId, string[] integrantesId)
        {
            var equipe = _mapper.Map<Equipe>(equipeViewModel);
            var coordenador = _pessoaRepository.ObterPorId(coordenadorId);
            var integrantes = new List<Pessoa>();
            foreach (var integranteId in integrantesId)
            {
                integrantes.Add(_pessoaRepository.ObterPrimeiroOuPadrao(x => x.Id == integranteId));
            }
            equipe.Coordenador = coordenador;

            // Associa os integrantes na classe PessoaEquipe
            foreach (var integrante in integrantes)
            {
                equipe.PessoasEquipes.Add(new PessoaEquipe()
                {
                    DataAlocacao = DateTime.Now,
                    Pessoa = integrante,
                    Equipe = equipe
                });
            }

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

        public void Deletar(string id)
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