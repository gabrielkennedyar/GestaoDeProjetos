﻿using System;
using System.Collections.Generic;

namespace GestaoDeProjetos.Domain.Entities
{
    public class Projeto : EntityBase
    {
        public Projeto()
        {
            Tarefas = new List<Tarefa>();
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; }
        public DateTime DataPrevista { get; set; }
        public string Relatorio { get; set; }
        public int Progresso { get; set; }

        public Guid CoordenadorId { get; set; }
        public virtual Pessoa Coordenador { get; set; }

        public Guid EquipeId { get; set; }
        public virtual Equipe Equipe { get; set; }

        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
