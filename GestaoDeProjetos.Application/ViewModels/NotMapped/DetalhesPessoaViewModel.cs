using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoDeProjetos.Application.ViewModels.NotMapped
{
   public class DetalhesPessoaViewModel
    {

        [Key]
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe a função da pessoa")]
        public string Funcao { get; set; }

        [Display(Name = "Nome da Equipe")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = true)]
        [DisplayName("Data de Adição")]
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<ProjetoViewModel> Projetos { get; set; }
        public virtual ICollection<PessoaEquipeViewModel> PessoasEquipe { get; set; }






    }
}
