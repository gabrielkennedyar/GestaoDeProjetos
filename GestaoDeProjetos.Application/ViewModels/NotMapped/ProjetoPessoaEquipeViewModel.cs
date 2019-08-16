using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjetos.Application.ViewModels.NotMapped
{
    public class ProjetoPessoaEquipeViewModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do projeto")]
        [Display(Name = "Nome do Projeto")]
        public string NomeProjeto { get; set; }

        [Required(ErrorMessage = "Informe a descrição do projeto")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a prioridade do projeto")]
        public string Prioridade { get; set; }

        [Required(ErrorMessage = "Informe a data prevista do projeto")]
        public DateTime DataPrevista { get; set; }

        [Display(Name = "Relatório")]
        public string Relatorio { get; set; }

        [Range(0, 100)]
        public int Progresso { get; set; }

        [Display(Name = "Coordenador")]
        public string CoordenadorId { get; set; }

        [Display(Name = "Equipe")]
        public string EquipeId { get; set; }
    }
}
