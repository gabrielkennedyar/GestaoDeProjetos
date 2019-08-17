using GestaoDeProjetos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeProjetos.Infra.Data.EntityConfig
{
    public class PessoaEquipeConfiguration : IEntityTypeConfiguration<PessoaEquipe>
    {
        public void Configure(EntityTypeBuilder<PessoaEquipe> builder)
        {
            builder.ToTable("PessoaEquipe");

            builder.HasKey(pe => pe.Id);

            builder.Property(pe => pe.Id).IsFixedLength().HasMaxLength(36);
            builder.Property(pe => pe.DataAlocacao).IsRequired().HasColumnName("DataAlocacao");

            builder.HasOne(pe => pe.Pessoa).WithMany(p => p.PessoasEquipes).IsRequired().HasForeignKey(pe => pe.PessoaId);
            builder.HasOne(pe => pe.Equipe).WithMany(e => e.PessoasEquipes).IsRequired().HasForeignKey(pe => pe.EquipeId);
        }
    }
}
