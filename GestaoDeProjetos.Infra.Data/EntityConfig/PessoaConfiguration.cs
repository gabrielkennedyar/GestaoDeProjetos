using GestaoDeProjetos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoDeProjetos.Infra.Data.EntityConfig
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).IsFixedLength().HasMaxLength(36);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(200).HasColumnName("Nome");
            builder.Property(p => p.Funcao).IsRequired().HasMaxLength(1000).HasColumnName("Funcao");
            builder.Property(p => p.Setor).IsRequired().HasMaxLength(100).HasColumnName("Setor");
            builder.Property(p => p.Contato).IsRequired().HasMaxLength(50).HasColumnName("Contato");
            builder.Property(p => p.Empresa).IsRequired().HasMaxLength(200).HasColumnName("Empresa");
        }
    }
}
