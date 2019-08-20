using GestaoDeProjetos.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GestaoDeProjetos.Application.IAppServices
{
    public interface IPessoaAppService : IDisposable
    {
        IEnumerable<PessoaViewModel> ObterTodos();
        PessoaViewModel ObterPorId(string id);
        PessoaViewModel Adicionar(PessoaViewModel pessoaViewModel);
        void Editar(PessoaViewModel pessoaViewModel);
        void Deletar(string id);
    }
}
