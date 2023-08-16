using System;
using Microsoft.EntityFrameworkCore;
using PlayersStatistics.Infrastructure.Models;

namespace PlayersStatistics.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Match> Matches { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .Property(m => m.IsDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Player>()
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}

