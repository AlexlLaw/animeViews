using System.Collections.Generic;
using AnimeViews.models;
using Microsoft.EntityFrameworkCore;

namespace AnimeViews.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<AnimePessoa> AnimesPessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pessoa>()
                .HasData(
                    new List<Pessoa>() {
                        new Pessoa() {
                            PessoaId = 1,
                            Nome = "Álex Junior Saturnino Sobrinho",
                            Idade = 25
                        }
                    }
                );

            builder.Entity<Anime>()
                .HasData(
                    new List<Anime>() {
                        new Anime() {
                            AnimeId = 1,
                            Obra = "Naruto",
                            DataDeLançamento = "21 de setembro de 1999",
                            Temporadas = 9,
                            QtdDeEpisodios = 220
                        }
                    }
                );

            builder.Entity<AnimePessoa>()
                .HasKey(ap => new {ap.AnimeId, ap.PessoaId});

            builder.Entity<AnimePessoa>()
                .HasOne(ap => ap.Animes)
                .WithMany(p => p.AnimePessoas)
                .HasForeignKey(ap => ap.AnimeId);

            builder.Entity<AnimePessoa>()
                .HasOne(ap => ap.Pessoas)
                .WithMany(p => p.AnimePessoas)
                .HasForeignKey(ap => ap.PessoaId);
        }
    }
}