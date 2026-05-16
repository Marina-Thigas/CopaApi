using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaHAS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CopaHAS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Jogador> TB_JOGADORES {get; set; }
        public DbSet<Estadio> TB_ESTADIOS {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogador>().ToTable("TB_JOGADORES");
            modelBuilder.Entity<Estadio>().ToTable("TB_ESTADIOS");


            modelBuilder.Entity<Jogador>().HasData
            (
                new Jogador(){Id = 1, Nome = "Hugo Souza", NumeroCamisa=1, Posicao = "Goleiro", Status= Models.Enuns.statusJogador.Titular},
                new Jogador(){Id = 2, Nome = "Yuri Alberto", NumeroCamisa=9, Posicao = "Atacante", Status= Models.Enuns.statusJogador.Titular}, 
                new Jogador(){Id = 3, Nome = "Danilo", NumeroCamisa = 2, Posicao = "Lateral Direito", Status = Models.Enuns.statusJogador.Titular},
                new Jogador(){Id = 4, Nome = "Marquinhos", NumeroCamisa = 4, Posicao = "Zagueiro", Status = Models.Enuns.statusJogador.Titular},
                new Jogador(){Id = 5, Nome = "Casemiro", NumeroCamisa = 5, Posicao = "Volante", Status = Models.Enuns.statusJogador.Titular},
                new Jogador(){Id = 6, Nome = "Alex Sandro", NumeroCamisa = 6, Posicao = "Lateral Esquerdo", Status = Models.Enuns.statusJogador.Titular},
                new Jogador(){Id = 7, Nome = "Lucas Paquetá", NumeroCamisa = 7, Posicao = "Meio Campo", Status = Models.Enuns.statusJogador.Titular},
                new Jogador(){Id = 8, Nome = "Bruno Guimarães", NumeroCamisa = 8, Posicao = "Meio Campo", Status = Models.Enuns.statusJogador.Reserva},
                new Jogador(){Id = 9, Nome = "Richarlisson", NumeroCamisa = 10, Posicao = "Atacante", Status = Models.Enuns.statusJogador.Titular},
                new Jogador(){Id = 10, Nome = "Vinicius Jr", NumeroCamisa = 11, Posicao = "Atacante", Status = Models.Enuns.statusJogador.Titular},
                new Jogador(){Id = 11, Nome = "Rodrygo", NumeroCamisa = 19, Posicao = "Atacante", Status = Models.Enuns.statusJogador.DepartamentoMedico},
                new Jogador(){Id = 12, Nome = "Alisson", NumeroCamisa = 23, Posicao = "Goleiro", Status = Models.Enuns.statusJogador.NaoRelacionado}
            );

            modelBuilder.Entity<Estadio>().HasData(
                new Estadio(){Id = 1, Nome = "Maracanã", Capacidade = 20000, Cidade = "Sao Paulo"},
                new Estadio(){Id = 2, Nome = "BLA", Capacidade = 20000, Cidade = "Rio de Janeiro"},
                new Estadio(){Id = 3, Nome = "BLU", Capacidade = 20000, Cidade = "Belo Horizonte"},
                new Estadio(){Id = 4, Nome = "BLI", Capacidade = 20000, Cidade = "Campos de Jordao"},
                new Estadio(){Id = 5, Nome = "CARA", Capacidade = 20000, Cidade = "Porto Alegre"},
                new Estadio(){Id = 6, Nome = "AI", Capacidade = 20000, Cidade = "Uberlandia"},
                new Estadio(){Id = 7, Nome = "POR", Capacidade = 20000, Cidade = "Natal"}
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

    }
}