using GestaoDeProjetos.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace GestaoDeProjetos.Application.IAppServices
{
    public interface IProjetoAppService : IDisposable
    {
        IEnumerable<ProjetoViewModel> ObterTodos();
        ProjetoViewModel ObterPorId(string id);
        ProjetoViewModel Adicionar(ProjetoViewModel projetoViewModel, string coordenadorId, string equipeId);
        ProjetoViewModel Editar(ProjetoViewModel projetoViewModel, string coordenadorId, string equipeId);
        void Deletar(string id);
    }
}
