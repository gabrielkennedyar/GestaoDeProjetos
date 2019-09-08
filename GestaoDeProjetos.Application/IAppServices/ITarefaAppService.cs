using GestaoDeProjetos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoDeProjetos.Application.IAppServices
{
    public interface ITarefaAppService : IDisposable
    {
        IEnumerable<TarefaViewModel> ObterTodos();
        TarefaViewModel ObterPorId(string id);
        TarefaViewModel Adicionar(TarefaViewModel tarefaViewModel);
        TarefaViewModel Editar(TarefaViewModel tarefaViewModel);
        void Deletar(string id);
    }
}
