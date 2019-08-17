using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjetos.Application.ViewModels
{
    public class ProjetoViewModel
    {
        public ProjetoViewModel()
        {
            Id = Guid.NewGuid().ToString();
            Progresso = 0;
            Tarefas = new List<TarefaViewModel>();            
        }

        [Key]
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do projeto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição do projeto")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a prioridade do projeto")]
        public string Prioridade { get; set; }

        [Required(ErrorMessage = "Informe a data prevista do projeto")]
        public DateTime DataPrevista { get; set; }

        [Display(Name = "Status do Projeto")]
        public string Status { get; set; }

        [Display(Name = "Relatório")]
        public string Relatorio { get; set; }

        [Range(0, 100)]
        public int Progresso { get; set; }

        [ScaffoldColumn(false)]
        public string CoordenadorId { get; set; }
        public virtual PessoaViewModel Coordenador { get; set; }

        [ScaffoldColumn(false)]
        public string EquipeId { get; set; }
        public virtual EquipeViewModel Equipe { get; set; }

        public virtual ICollection<TarefaViewModel> Tarefas { get; set; }
    }
}
