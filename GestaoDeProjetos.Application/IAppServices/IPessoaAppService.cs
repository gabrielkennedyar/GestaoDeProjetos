using GestaoDeProjetos.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GestaoDeProjetos.Application.IAppServices
{
    public interface IPessoaAppService : IDisposable
    {
        IEnumerable<PessoaViewModel> ObterTodos();
        PessoaViewModel ObterPorId(Guid id);
        PessoaViewModel Adicionar(PessoaViewModel pessoaViewModel);
        void Editar(Guid id);
        void Deletar(Guid id);
    }
}
