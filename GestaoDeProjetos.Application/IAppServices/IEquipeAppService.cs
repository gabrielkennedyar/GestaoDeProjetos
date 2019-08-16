using GestaoDeProjetos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoDeProjetos.Application.IAppServices
{
    public interface IEquipeAppService : IDisposable
    {
        IEnumerable<EquipeViewModel> ObterTodos();
        EquipeViewModel ObterPorId(Guid id);
        EquipeViewModel Adicionar(EquipeViewModel equipeViewModel);
        void Editar(EquipeViewModel equipeViewModel);
        void Deletar(Guid id);
    }
}
