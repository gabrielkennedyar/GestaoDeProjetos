using GestaoDeProjetos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeProjetos.Infra.Data.EntityConfig
{
    public class EquipeConfiguration : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.ToTable("Equipe");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome).IsRequired().HasMaxLength(200).HasColumnName("Nome");
            builder.Property(e => e.Descricao).IsRequired().HasMaxLength(1000).HasColumnName("Descricao");

            builder.HasOne(e => e.Coordenador).WithMany(p => p.EquipesCoordenadas).IsRequired().HasForeignKey(e => e.CoordenadorId);
        }
    }
}
