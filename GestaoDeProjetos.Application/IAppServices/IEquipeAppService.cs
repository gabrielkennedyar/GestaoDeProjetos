using GestaoDeProjetos.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GestaoDeProjetos.Application.IAppServices
{
    public interface IEquipeAppService : IDisposable
    {
        IEnumerable<EquipeViewModel> ObterTodos();
        EquipeViewModel ObterPorId(string id);
        EquipeViewModel Adicionar(EquipeViewModel equipeViewModel, string coordenadorId, string[] integrantesId);
        void Editar(EquipeViewModel equipeViewModel, string coordenadorId, string[] integrantesId);
        void Deletar(string id);
    }
}
