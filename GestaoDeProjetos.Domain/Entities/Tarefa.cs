using System;

namespace GestaoDeProjetos.Domain.Entities
{
    public class Tarefa : EntityBase
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataPrevista { get; set; }

        public Guid ResponsavelId { get; set; }
        public virtual Pessoa Responsavel { get; set; }
    }
}
