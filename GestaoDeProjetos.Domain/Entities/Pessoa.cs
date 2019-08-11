using System.Collections.Generic;

namespace GestaoDeProjetos.Domain.Entities
{
    public class Pessoa : EntityBase
    {
        public Pessoa()
        {
            EquipesCoordenadas = new List<Equipe>();
            ProjetosCoordenados = new List<Projeto>();
            PessoasEquipes = new List<PessoaEquipe>();
            Tarefas = new List<Tarefa>();
        }

        public string Nome { get; set; }
        public string Setor { get; set; }
        public string Contato { get; set; }
        public string Empresa { get; set; }

        public virtual ICollection<Equipe> EquipesCoordenadas { get; set; }
        public virtual ICollection<Projeto> ProjetosCoordenados { get; set; }
        public virtual ICollection<PessoaEquipe> PessoasEquipes { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
