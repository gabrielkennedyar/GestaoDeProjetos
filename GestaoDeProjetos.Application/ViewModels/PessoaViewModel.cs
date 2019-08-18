using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjetos.Application.ViewModels
{
    public class PessoaViewModel
    {
        public PessoaViewModel()
        {
            Id = Guid.NewGuid().ToString();
            EquipesCoordenadas = new List<EquipeViewModel>();
            ProjetosCoordenados = new List<ProjetoViewModel>();
            PessoasEquipes = new List<PessoaEquipeViewModel>();
            Tarefas = new List<TarefaViewModel>();
        }

        [Key]
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da pessoa")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a função da pessoa")]
        public string Funcao { get; set; }

        [Required(ErrorMessage = "Informe o setor da pessoa")]
        public string Setor { get; set; }

        [Required(AllowEmptyStrings = true)]
        [DisplayName("Data de Adição")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Informe o contato da pessoa")]
        public string Contato { get; set; }

        [Required(ErrorMessage = "Informe a empresa onde trabalha a pessoa")]
        public string Empresa { get; set; }

        public virtual ICollection<EquipeViewModel> EquipesCoordenadas { get; set; }
        public virtual ICollection<ProjetoViewModel> ProjetosCoordenados { get; set; }
        public virtual ICollection<PessoaEquipeViewModel> PessoasEquipes { get; set; }
        public virtual ICollection<TarefaViewModel> Tarefas { get; set; }
    }
}
