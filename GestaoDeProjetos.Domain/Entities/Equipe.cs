using System;
using System.Collections.Generic;

namespace GestaoDeProjetos.Domain.Entities
{
    public class Equipe : EntityBase
    {
        public Equipe()
        {
            Projetos = new List<Projeto>();
            PessoasEquipes = new List<PessoaEquipe>();
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Guid CoordenadorId { get; set; }
        public virtual Pessoa Coordenador { get; set; }

        public virtual ICollection<Projeto> Projetos { get; set; }
        public virtual ICollection<PessoaEquipe> PessoasEquipes { get; set; }
    }
}
