using AutoMapper;
using GestaoDeProjetos.Application.IAppServices;
using GestaoDeProjetos.Application.ViewModels;
using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Domain.Interfaces.IRepositories;
using GestaoDeProjetos.Domain.Interfaces.IServices;
using GestaoDeProjetos.Domain.Interfaces.IUoW;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoDeProjetos.Application.AppServices
{
    public class PessoaAppService : AppServiceBase, IPessoaAppService
    {
        private readonly IPessoaService _pessoaService;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoaAppService(IPessoaService pessoaService, IPessoaRepository pessoaRepository, IUnityOfWork unityOfWork, IMapper mapper) : base(unityOfWork)
        {
            _pessoaService = pessoaService;
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        public IEnumerable<PessoaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<PessoaViewModel>>(_pessoaRepository.ObterTodos());
        }

        public PessoaViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<PessoaViewModel>(_pessoaRepository.ObterPorId(id));
        }

        public PessoaViewModel Adicionar(PessoaViewModel pessoaViewModel)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaViewModel);
            pessoa = _pessoaService.Adicionar(pessoa);

            if (!SaveChanges())
            {
                throw new Exception();
            }

            return _mapper.Map<PessoaViewModel>(pessoa);            
        }

        public void Editar(PessoaViewModel pessoaViewModel)
        {
            var pessoaEditada = _mapper.Map<Pessoa>(pessoaViewModel);
            var pessoa = _pessoaRepository.ObterPorId(pessoaViewModel.Id);

            pessoa.AtualizarDados(pessoaEditada);

            pessoa = _pessoaService.Atualizar(pessoa);

            if (!SaveChanges())
            {
                throw new Exception();
            }
        }

        public void Deletar(Guid id)
        {
            var pessoa = _pessoaRepository.ObterPorId(id);

            pessoa = _pessoaService.Remover(pessoa);

            if (!SaveChanges())
            {
                throw new Exception();
            }
        }

        public void Dispose()
        {
            _pessoaRepository.Dispose();
        }
    }
}
