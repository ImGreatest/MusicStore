using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using MusicStore.Models;

namespace MusicStore
{

    public class ContextDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=musicstreamingservice;Username=postgres;Password=889988");
        }

        public ContextDB()
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Album> Albums { get; set; }
        public DbSet<Country> Counties { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
    }
};
