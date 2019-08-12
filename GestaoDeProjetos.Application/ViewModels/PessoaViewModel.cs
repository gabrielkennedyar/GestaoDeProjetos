using System;
using System.Collections.Generic;

namespace GestaoDeProjetos.Application.ViewModels
{
    public class PessoaViewModel
    {
        public PessoaViewModel()
        {
            EquipesCoordenadas = new List<EquipeViewModel>();
            ProjetosCoordenados = new List<ProjetoViewModel>();
            PessoasEquipes = new List<PessoaEquipeViewModel>();
            Tarefas = new List<TarefaViewModel>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }
        public string Contato { get; set; }
        public string Empresa { get; set; }

        public virtual ICollection<EquipeViewModel> EquipesCoordenadas { get; set; }
        public virtual ICollection<ProjetoViewModel> ProjetosCoordenados { get; set; }
        public virtual ICollection<PessoaEquipeViewModel> PessoasEquipes { get; set; }
        public virtual ICollection<TarefaViewModel> Tarefas { get; set; }
    }
}
