using System;

namespace GestaoDeProjetos.Domain.Entities
{
    public class PessoaEquipe : EntityBase
    {
        public DateTime DataAlocacao { get; set; }

        public string PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public string EquipeId { get; set; }
        public virtual Equipe Equipe { get; set; }
    }
}
