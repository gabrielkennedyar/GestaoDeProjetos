using System;

namespace GestaoDeProjetos.Domain.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}
