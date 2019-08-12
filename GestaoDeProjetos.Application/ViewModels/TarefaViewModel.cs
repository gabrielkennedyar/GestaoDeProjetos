using System;

namespace GestaoDeProjetos.Application.ViewModels
{
    public class TarefaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataPrevista { get; set; }

        public Guid ResponsavelId { get; set; }
        public virtual PessoaViewModel Responsavel { get; set; }
    }
}
