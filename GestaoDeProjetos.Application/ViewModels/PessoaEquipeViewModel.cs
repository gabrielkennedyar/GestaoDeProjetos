using System;

namespace GestaoDeProjetos.Application.ViewModels
{
    public class DetalhesEquipeViewModelViewModel
    {
        public DetalhesEquipeViewModelViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public DateTime DataAlocacao { get; set; }

        public string PessoaId { get; set; }
        public virtual PessoaViewModel Pessoa { get; set; }

        public string EquipeId { get; set; }
        public virtual EquipeViewModel Equipe { get; set; }
    }
}
