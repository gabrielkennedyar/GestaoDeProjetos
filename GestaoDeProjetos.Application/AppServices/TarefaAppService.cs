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
    public class TarefaAppService : AppServiceBase, ITarefaAppService
    {
        private readonly ITarefaService _tarefaService;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IProjetoRepository _projetoRepository;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public TarefaAppService(ITarefaService tarefaService, ITarefaRepository tarefaRepository, IProjetoRepository projetoRepository, IPessoaRepository pessoaRepository,
                                IUnityOfWork unityOfWork, IMapper mapper) : base(unityOfWork)
        {
            _tarefaService = tarefaService;
            _tarefaRepository = tarefaRepository;
            _projetoRepository = projetoRepository;
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        public IEnumerable<TarefaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TarefaViewModel>>(_tarefaRepository.ObterTodos());
        }
        public TarefaViewModel ObterPorId(string id)
        {
            return _mapper.Map<TarefaViewModel>(_tarefaRepository.ObterPorId(id));
        }
        public TarefaViewModel Adicionar(TarefaViewModel tarefaViewModel)
        {
            var tarefa = _mapper.Map<Tarefa>(tarefaViewModel);
            var projeto = _projetoRepository.ObterPorId(tarefaViewModel.ProjetoId);
            var responsavel = _pessoaRepository.ObterPorId(tarefaViewModel.ResponsavelId);

            tarefa.Projeto = projeto;
            tarefa.Responsavel = responsavel;
            tarefa = _tarefaService.Adicionar(tarefa);

            if (!SaveChanges())
            {
                throw new Exception();
            }

            return _mapper.Map<TarefaViewModel>(tarefa);
        }
        public TarefaViewModel Editar(TarefaViewModel tarefaViewModel)
        {
            var tarefaEditado = _mapper.Map<Tarefa>(tarefaViewModel);
            var tarefa = _tarefaRepository.ObterPorId(tarefaViewModel.Id);
            var projeto = _projetoRepository.ObterPorId(tarefaViewModel.ProjetoId);
            var responsavel = _pessoaRepository.ObterPorId(tarefaViewModel.ResponsavelId);

            tarefa.Projeto = projeto;
            tarefa.Responsavel = responsavel;
            tarefa.AtualizarDados(tarefaEditado);

            tarefa = _tarefaService.Atualizar(tarefa);

            if (!SaveChanges())
            {
                throw new Exception();
            }

            return _mapper.Map<TarefaViewModel>(tarefa);
        }
        public void Deletar(string id)
        {
            var tarefa = _tarefaRepository.ObterPorId(id);

            tarefa = _tarefaService.Remover(tarefa);

            if (!SaveChanges())
            {
                throw new Exception();
            }
        }

        public void Dispose()
        {
            _tarefaRepository.Dispose();
        }
    }
}
