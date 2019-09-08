using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoDeProjetos.Application.ViewModels.NotMapped
{
    public class DetalhesTarefaViewModel
    {
        public string TarefaId { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Nome do Projeto")]
        public string NomeProjeto { get; set; }

        [Range(0, 100)]
        public int Progresso { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataPrevista { get; set; }

        public string ResponsavelId { get; set; }
 
        public string ProjetoID { get; set; }
        public virtual PessoaViewModel Responsavel { get; set; }
        public virtual ProjetoViewModel Projeto { get; set; }
    
    }
}
