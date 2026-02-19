using GameTracker.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Context
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Game> games;

        public DbSet<Category> categories;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data source=games.db")
                .UseLazyLoadingProxies()
                .LogTo(Console.WriteLine);
        }
    }
}
