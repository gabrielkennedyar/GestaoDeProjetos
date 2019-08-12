using GestaoDeProjetos.Domain.Entities;
using System;

namespace GestaoDeProjetos.Domain.Interfaces.IServices
{
    public interface IPessoaService : IDisposable
    {
        Pessoa Adicionar(Pessoa pessoa);
        Pessoa Atualizar(Pessoa pessoa);
        Pessoa Remover(Pessoa pessoa);
    }
}
