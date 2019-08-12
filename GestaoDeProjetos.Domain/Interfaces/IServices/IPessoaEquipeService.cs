using GestaoDeProjetos.Domain.Entities;
using System;

namespace GestaoDeProjetos.Domain.Interfaces.IServices
{
    public interface IPessoaEquipeService : IDisposable
    {
        PessoaEquipe Adicionar(PessoaEquipe pessoaEquipe);
        PessoaEquipe Atualizar(PessoaEquipe pessoaEquipe);
        PessoaEquipe Remover(PessoaEquipe pessoaEquipe);
    }
}
