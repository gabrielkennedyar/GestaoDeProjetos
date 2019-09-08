
using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoDeProjetos.Application.ViewModels
{
    public class TarefaViewModel
    {
        public TarefaViewModel()
        {
            Id = Guid.NewGuid().ToString();

        }

        [Key]
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da Tarefa")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe Data de Inicio")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Informe Data Prevista")]
        [DataType(DataType.Date)]
        public DateTime DataPrevista { get; set; }

        [Required(ErrorMessage = "Informe Responsável")]
        public string ResponsavelId { get; set; }
        public virtual PessoaViewModel Responsavel { get; set; }

        [Required(ErrorMessage = "Informe o projeto")]
        public string ProjetoId { get; set; }
        public virtual ProjetoViewModel Projeto { get; set; }
    }
}
