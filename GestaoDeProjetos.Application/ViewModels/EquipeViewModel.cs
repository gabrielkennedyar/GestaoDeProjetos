using System;
using System.Collections.Generic;

namespace GestaoDeProjetos.Application.ViewModels
{
    public class EquipeViewModel
    {
        public EquipeViewModel()
        {
            Projetos = new List<ProjetoViewModel>();
            PessoasEquipes = new List<PessoaEquipeViewModel>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public Guid CoordenadorId { get; set; }
        public virtual PessoaViewModel Coordenador { get; set; }

        public virtual ICollection<ProjetoViewModel> Projetos { get; set; }
        public virtual ICollection<PessoaEquipeViewModel> PessoasEquipes { get; set; }
    }
}
