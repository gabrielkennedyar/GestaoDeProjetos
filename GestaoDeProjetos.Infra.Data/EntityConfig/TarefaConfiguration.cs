using GestaoDeProjetos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeProjetos.Infra.Data.EntityConfig
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).IsFixedLength().HasMaxLength(36);
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(200).HasColumnName("Nome");
            builder.Property(t => t.DataInicio).IsRequired().HasColumnName("DataInicio");
            builder.Property(t => t.DataPrevista).IsRequired().HasColumnName("DataPrevista");

            builder.HasOne(t => t.Responsavel).WithMany(p => p.Tarefas).IsRequired().HasForeignKey(t => t.ResponsavelId);
            builder.HasOne(t => t.Projeto).WithMany(p => p.Tarefas).IsRequired().HasForeignKey(t => t.ProjetoId);
        }
    }
}
