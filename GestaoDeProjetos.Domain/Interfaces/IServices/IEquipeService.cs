using GestaoDeProjetos.Domain.Entities;
using System;

namespace GestaoDeProjetos.Domain.Interfaces.IServices
{
    public interface IEquipeService : IDisposable
    {
        Equipe Adicionar(Equipe equipe);
        Equipe Atualizar(Equipe equipe);
        Equipe Remover(Equipe equipe);
    }
}
