using GestaoDeProjetos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoDeProjetos.Application.ViewModels.NotMapped
{
    public class DetalhesEquipeViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da Equipe")]
        [Display(Name = "Nome da Equipe")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição do projeto")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(AllowEmptyStrings = true)]
        [DisplayName("Data de Adição")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Informe a data prevista do projeto")]
        [DataType(DataType.Date)]
        public DateTime DataPrevista { get; set; }

        [Display(Name = "Status do Projeto")]
        public string Status { get; set; }

        public virtual List<DetalhesEquipeViewModelViewModel> DetalhePessoaEquipe { get; set; }

        public virtual List<Projeto> Projeto { get; set; }


    }
}
