using System;

namespace GestaoDeProjetos.Domain.Entities
{
    public class Tarefa : EntityBase
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataPrevista { get; set; }

        public string ResponsavelId { get; set; }
        public virtual Pessoa Responsavel { get; set; }

        public string ProjetoId { get; set; }
        public virtual Projeto Projeto { get; set; }

        public void AtualizarDados(Tarefa tarefa)
        {
            Nome = tarefa.Nome;
            DataInicio = tarefa.DataInicio;
            DataPrevista = tarefa.DataPrevista;
        }
    }
}
