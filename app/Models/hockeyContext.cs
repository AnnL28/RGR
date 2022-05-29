using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace curs.Models
{
    public partial class hockeyContext : DbContext
    {
        public hockeyContext()
        {
        }

        public hockeyContext(DbContextOptions<hockeyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<League> Leagues { get; set; } = null!;
        public virtual DbSet<Shot> Shots { get; set; } = null!;
        public virtual DbSet<Statistics> Stats { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=C:\\vp_labs\\curs\\Models\\bd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GameN).HasColumnName("game_N");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Time).HasColumnName("time");

            });

            modelBuilder.Entity<League>(entity =>
            {
                entity.ToTable("league");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Region).HasColumnName("region");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("player");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.TeamId).HasColumnName("team");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Shot>(entity =>
            {
                entity.ToTable("shot");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.ScorerId).HasColumnName("scorer");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.GameId).HasColumnName("game_N");

                entity.HasOne(d => d.Player)
                   .WithMany(p => p.Shots)
                   .HasForeignKey(d => d.ScorerId)
                   .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Game)
                   .WithMany(p => p.Shots)
                   .HasForeignKey(d => d.GameId)
                   .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Statistics>(entity =>
            {
                entity.ToTable("statistics");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GameId).HasColumnName("game_N");

                entity.Property(e => e.Team1Id).HasColumnName("team1");

                entity.Property(e => e.Score_team1).HasColumnName("score_team1");

                entity.Property(e => e.Assists_team1).HasColumnName("assists_team1");

                entity.Property(e => e.Plus_minus_team1).HasColumnName("plus/minus_team1");

                entity.Property(e => e.Penalties_team1).HasColumnName("penalties_team1");

                entity.Property(e => e.Team2Id).HasColumnName("team2");

                entity.Property(e => e.Score_team2).HasColumnName("score_team2");

                entity.Property(e => e.Assists_team2).HasColumnName("assists_team2");

                entity.Property(e => e.Plus_minus_team2).HasColumnName("plus/minus_team2");

                entity.Property(e => e.Penalties_team2).HasColumnName("penalties_team2");


                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Stats)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Team1)
                    .WithMany(p => p.Stats1)
                    .HasForeignKey(d => d.Team1Id)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Team2)
                    .WithMany(p => p.Stats2)
                    .HasForeignKey(d => d.Team2Id)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("Name");

                entity.Property(e => e.LeagueId).HasColumnName("league");

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.LeagueId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
