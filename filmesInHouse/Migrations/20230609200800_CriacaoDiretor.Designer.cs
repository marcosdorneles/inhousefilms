﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using filmesInHouse.Context;

#nullable disable

namespace filmesInHouse.Migrations
{
    [DbContext(typeof(FilmesContext))]
    [Migration("20230609200800_CriacaoDiretor")]
    partial class CriacaoDiretor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("filmesInHouse.Models.Diretor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Diretores");
                });

            modelBuilder.Entity("filmesInHouse.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Diretor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("filmesInHouse.Models.FilmeDiretor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdDiretor")
                        .HasColumnType("int");

                    b.Property<int>("IdFilme")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDiretor");

                    b.HasIndex("IdFilme");

                    b.ToTable("FilmeDiretores");
                });

            modelBuilder.Entity("filmesInHouse.Models.FilmeDiretor", b =>
                {
                    b.HasOne("filmesInHouse.Models.Diretor", "Diretor")
                        .WithMany()
                        .HasForeignKey("IdDiretor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("filmesInHouse.Models.Filme", "Filme")
                        .WithMany()
                        .HasForeignKey("IdFilme")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diretor");

                    b.Navigation("Filme");
                });
#pragma warning restore 612, 618
        }
    }
}
