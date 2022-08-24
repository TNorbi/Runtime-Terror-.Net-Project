using Microsoft.EntityFrameworkCore;
using MoviesWebAPI.Data.Models;
using System.Diagnostics.CodeAnalysis;

namespace MoviesWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Ratings> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ratings>().HasKey(c=> new {c.UserId,c.Mov_Id});

            modelBuilder.Entity<Users>()
                .HasMany(m => m.Movies)
                .WithMany(u => u.Users)
                .UsingEntity(join => join.ToTable("Watchlist"));
        }
    }
}
