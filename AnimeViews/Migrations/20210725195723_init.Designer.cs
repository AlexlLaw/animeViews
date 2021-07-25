﻿// <auto-generated />
using AnimeViews.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimeViews.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210725195723_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AnimePessoa", b =>
                {
                    b.Property<int>("AnimesViewsAnimeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PessoasViewsPessoaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnimesViewsAnimeId", "PessoasViewsPessoaId");

                    b.HasIndex("PessoasViewsPessoaId");

                    b.ToTable("AnimePessoa");
                });

            modelBuilder.Entity("AnimeViews.models.Anime", b =>
                {
                    b.Property<int>("AnimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataDeLançamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Obra")
                        .HasColumnType("TEXT");

                    b.Property<int>("QtdDeEpisodios")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Temporadas")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnimeId");

                    b.ToTable("Animes");

                    b.HasData(
                        new
                        {
                            AnimeId = 1,
                            DataDeLançamento = "21 de setembro de 1999",
                            Obra = "Naruto",
                            QtdDeEpisodios = 220,
                            Temporadas = 9
                        });
                });

            modelBuilder.Entity("AnimeViews.models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Idade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");

                    b.HasData(
                        new
                        {
                            PessoaId = 1,
                            AnimeId = 1,
                            Idade = 25,
                            Nome = "Álex Junior Saturnino Sobrinho"
                        });
                });

            modelBuilder.Entity("AnimePessoa", b =>
                {
                    b.HasOne("AnimeViews.models.Anime", null)
                        .WithMany()
                        .HasForeignKey("AnimesViewsAnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimeViews.models.Pessoa", null)
                        .WithMany()
                        .HasForeignKey("PessoasViewsPessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
