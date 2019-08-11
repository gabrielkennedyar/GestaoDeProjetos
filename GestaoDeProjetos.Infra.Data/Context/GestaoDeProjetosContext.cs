using GestaoDeProjetos.Domain.Entities;
using GestaoDeProjetos.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GestaoDeProjetos.Infra.Data.Context
{
    public class GestaoDeProjetosContext : DbContext
    {
        public GestaoDeProjetosContext(DbContextOptions<GestaoDeProjetosContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<PessoaEquipe> PessoasEquipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>(new PessoaConfiguration().Configure);
            modelBuilder.Entity<Equipe>(new EquipeConfiguration().Configure);
            modelBuilder.Entity<Projeto>(new ProjetoConfiguration().Configure);
            modelBuilder.Entity<Tarefa>(new TarefaConfiguration().Configure);
            modelBuilder.Entity<PessoaEquipe>(new PessoaEquipeConfiguration().Configure);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataModificacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataModificacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataModificacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataModificacao").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
