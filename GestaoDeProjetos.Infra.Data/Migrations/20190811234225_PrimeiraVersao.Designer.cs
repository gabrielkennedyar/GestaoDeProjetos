﻿// <auto-generated />
using System;
using GestaoDeProjetos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestaoDeProjetos.Infra.Data.Migrations
{
    [DbContext(typeof(GestaoDeProjetosContext))]
    [Migration("20190811234225_PrimeiraVersao")]
    partial class PrimeiraVersao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("GestaoDeProjetos.Domain.Entities.Equipe", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<byte[]>("CoordenadorId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataModificacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasMaxLength(1000);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CoordenadorId");

                    b.ToTable("Equipe");
                });

            modelBuilder.Entity("GestaoDeProjetos.Domain.Entities.Pessoa", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasColumnName("Contato")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataModificacao");

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasColumnName("Empresa")
                        .HasMaxLength(200);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(200);

                    b.Property<string>("Setor")
                        .IsRequired()
                        .HasColumnName("Setor")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("GestaoDeProjetos.Domain.Entities.PessoaEquipe", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<DateTime>("DataAlocacao")
                        .HasColumnName("DataAlocacao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataModificacao");

                    b.Property<byte[]>("EquipeId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<byte[]>("PessoaId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.HasIndex("PessoaId");

                    b.ToTable("PessoaEquipe");
                });

            modelBuilder.Entity("GestaoDeProjetos.Domain.Entities.Projeto", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<byte[]>("CoordenadorId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataModificacao");

                    b.Property<DateTime>("DataPrevista")
                        .HasColumnName("DataPrevista");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasMaxLength(1000);

                    b.Property<byte[]>("EquipeId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(200);

                    b.Property<string>("Prioridade")
                        .IsRequired()
                        .HasColumnName("Prioridade")
                        .HasMaxLength(100);

                    b.Property<int>("Progresso")
                        .HasColumnName("Progresso");

                    b.Property<string>("Relatorio")
                        .IsRequired()
                        .HasColumnName("Relatorio")
                        .HasMaxLength(10000);

                    b.HasKey("Id");

                    b.HasIndex("CoordenadorId");

                    b.HasIndex("EquipeId");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("GestaoDeProjetos.Domain.Entities.Tarefa", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnName("DataInicio");

                    b.Property<DateTime>("DataModificacao");

                    b.Property<DateTime>("DataPrevista")
                        .HasColumnName("DataPrevista");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasMaxLength(200);

                    b.Property<byte[]>("ProjetoId")
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.Property<byte[]>("ResponsavelId")
                        .IsRequired()
                        .HasConversion(new ValueConverter<byte[], byte[]>(v => default(byte[]), v => default(byte[]), new ConverterMappingHints(size: 16)));

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("Tarefa");
                });

            modelBuilder.Entity("GestaoDeProjetos.Domain.Entities.Equipe", b =>
                {
                    b.HasOne("GestaoDeProjetos.Domain.Entities.Pessoa", "Coordenador")
                        .WithMany("EquipesCoordenadas")
                        .HasForeignKey("CoordenadorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GestaoDeProjetos.Domain.Entities.PessoaEquipe", b =>
                {
                    b.HasOne("GestaoDeProjetos.Domain.Entities.Equipe", "Equipe")
                        .WithMany("PessoasEquipes")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GestaoDeProjetos.Domain.Entities.Pessoa", "Pessoa")
                        .WithMany("PessoasEquipes")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GestaoDeProjetos.Domain.Entities.Projeto", b =>
                {
                    b.HasOne("GestaoDeProjetos.Domain.Entities.Pessoa", "Coordenador")
                        .WithMany("ProjetosCoordenados")
                        .HasForeignKey("CoordenadorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GestaoDeProjetos.Domain.Entities.Equipe", "Equipe")
                        .WithMany("Projetos")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GestaoDeProjetos.Domain.Entities.Tarefa", b =>
                {
                    b.HasOne("GestaoDeProjetos.Domain.Entities.Projeto")
                        .WithMany("Tarefas")
                        .HasForeignKey("ProjetoId");

                    b.HasOne("GestaoDeProjetos.Domain.Entities.Pessoa", "Responsavel")
                        .WithMany("Tarefas")
                        .HasForeignKey("ResponsavelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
