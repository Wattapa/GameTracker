using GameTracker.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> games { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<PlaySession> playSessions { get; set; }

        public DbSet<Studio> studios { get; set; }
        public AppDbContext(DbContextOptions optionsBuilder) : base()
        {
        }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data source=games.db")
                .UseLazyLoadingProxies();
                //.LogTo(Console.WriteLine);
        }
    }
}
