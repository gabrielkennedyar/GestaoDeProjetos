using System;

namespace GestaoDeProjetos.Application.ViewModels
{
    public class PessoaEquipeViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataAlocacao { get; set; }

        public Guid PessoaId { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }

        public Guid EquipeId { get; set; }
        public virtual EquipeViewModel Equipe { get; set; }
    }
}
