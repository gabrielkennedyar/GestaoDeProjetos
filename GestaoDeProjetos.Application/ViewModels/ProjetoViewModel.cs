using System;
using System.Collections.Generic;

namespace GestaoDeProjetos.Application.ViewModels
{
    public class ProjetoViewModel
    {
        public ProjetoViewModel()
        {
            Tarefas = new List<TarefaViewModel>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; }
        public DateTime DataPrevista { get; set; }
        public string Relatorio { get; set; }
        public int Progresso { get; set; }

        public Guid CoordenadorId { get; set; }
        public virtual PessoaViewModel Coordenador { get; set; }

        public Guid EquipeId { get; set; }
        public virtual EquipeViewModel Equipe { get; set; }

        public virtual ICollection<TarefaViewModel> Tarefas { get; set; }
    }
}
