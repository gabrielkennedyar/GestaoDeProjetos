using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjetos.Application.ViewModels.NotMapped
{
    public class DetalhesEquipeViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Display(Name = "Nome da Equipe")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Criação")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Última atualização")]
        [DataType(DataType.Date)]
        public DateTime DataModificacao { get; set; }

        public virtual ICollection<ProjetoViewModel> Projetos { get; set; }
        public virtual ICollection<PessoaEquipeViewModel> PessoasEquipe { get; set; }
    }
}
