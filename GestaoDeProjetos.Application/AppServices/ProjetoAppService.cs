using AutoMapper;
using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Application.ViewModels;
using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;
using GestaoDeProjetos.Domain.Interfaces.IUoW;
using System;
using System.Collections.Generic;

namespace GestaoDeProjetos.Application.AppServices
{
    public class ProjetoAppService : AppServiceBase, IProjetoAppService
    {
        private readonly IProjetoService _projetoService;
        private readonly IProjetoRepository _projetoRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IEquipeRepository _equipeRepository;
        private readonly IMapper _mapper;

        public ProjetoAppService(IProjetoService projetoService, IProjetoRepository projetoRepository, IPessoaRepository pessoaRepository, IEquipeRepository equipeRepository, IUnityOfWork unityOfWork, IMapper mapper) : base(unityOfWork)
        {
            _projetoService = projetoService;
            _projetoRepository = projetoRepository;
            _pessoaRepository = pessoaRepository;
            _equipeRepository = equipeRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProjetoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProjetoViewModel>>(_projetoRepository.ObterTodos());
        }
        public ProjetoViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<ProjetoViewModel>(_projetoRepository.ObterPorId(id));
        }
        public ProjetoViewModel Adicionar(ProjetoViewModel projetoViewModel, string coordenadorId, string equipeId)
        {
            var projeto = _mapper.Map<Projeto>(projetoViewModel);
            var coordenador = _pessoaRepository.ObterPorId(new Guid(coordenadorId));
            var equipe = _equipeRepository.ObterPorId(new Guid(equipeId));

            projeto.Coordenador = coordenador;
            projeto.Equipe = equipe;
            projeto = _projetoService.Adicionar(projeto);

            if (!SaveChanges())
            {
                throw new Exception();
            }

            return _mapper.Map<ProjetoViewModel>(projeto);
        }
        public ProjetoViewModel Editar(ProjetoViewModel projetoViewModel, string coordenadorId, string equipeId)
        {
            var projetoEditado = _mapper.Map<Projeto>(projetoViewModel);
            var projeto = _projetoRepository.ObterPorId(projetoViewModel.Id);

            projeto.AtualizarDados(projetoEditado);

            projeto = _projetoService.Atualizar(projeto);

            if (!SaveChanges())
            {
                throw new Exception();
            }

            return _mapper.Map<ProjetoViewModel>(projeto);
        }
        public void Deletar(Guid id)
        {
            var pessoa = _projetoRepository.ObterPorId(id);

            pessoa = _projetoService.Remover(pessoa);

            if (!SaveChanges())
            {
                throw new Exception();
            }
        }

        public void Dispose()
        {
            _projetoRepository.Dispose();
        }
    }
}
