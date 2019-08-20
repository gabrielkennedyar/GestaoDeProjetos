using System;

namespace GestaoDeProjetos.Application.ViewModels
{
    public class TarefaViewModel
    {
        public TarefaViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataPrevista { get; set; }

        public string ResponsavelId { get; set; }
        public virtual PessoaViewModel Responsavel { get; set; }
    }
}
