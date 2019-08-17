﻿using GestaoDeProjetos.Application.ViewModels.NotMapped;
using System;
using System.Collections.Generic;

namespace GestaoDeProjetos.Application.ViewModels
{
    public class EquipeViewModel
    {
        public EquipeViewModel()
        {
            Id = Guid.NewGuid().ToString();
            Projetos = new List<ProjetoViewModel>();
            PessoasEquipes = new List<DetalhesEquipeViewModelViewModel>();
           
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataPrevista { get; set; }

        public string Status { get; set; }

        public string CoordenadorId { get; set; }
        public virtual PessoaViewModel Coordenador { get; set; }

        public virtual ICollection<ProjetoViewModel> Projetos { get; set; }
        public virtual ICollection<DetalhesEquipeViewModelViewModel> PessoasEquipes { get; set; }

       

    }
}
