using GestaoDeProjetos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeProjetos.Infra.Data.EntityConfig
{
    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("Projeto");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsFixedLength().HasMaxLength(36);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(200).HasColumnName("Nome");
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(1000).HasColumnName("Descricao");
            builder.Property(p => p.Prioridade).IsRequired().HasMaxLength(100).HasColumnName("Prioridade");
            builder.Property(p => p.DataPrevista).IsRequired().HasColumnName("DataPrevista");
            builder.Property(p => p.Relatorio).IsRequired().HasMaxLength(10000).HasColumnName("Relatorio");
            builder.Property(p => p.Progresso).IsRequired().HasColumnName("Progresso");

            builder.HasOne(p => p.Coordenador).WithMany(p => p.ProjetosCoordenados).IsRequired().HasForeignKey(p => p.CoordenadorId);
            builder.HasOne(p => p.Equipe).WithMany(e => e.Projetos).IsRequired().HasForeignKey(p => p.EquipeId);
        }
    }
}
