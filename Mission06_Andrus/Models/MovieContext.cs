using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Andrus.Models
{
    // Database context for EF Core
    public class MovieContext : DbContext
    {
        // Constructor: sets up the database using options (like connection string)
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        // Represents the Movies table in the database

        //public DbSet<AddMovie> Movies { get; set; }
        public DbSet<RealMovie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed the Categories table with initial data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 2, CategoryName = "Drama" },
                new Category { CategoryId = 3, CategoryName = "Television" },
                new Category { CategoryId = 4, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 5, CategoryName = "Comedy" },
                new Category { CategoryId = 6, CategoryName = "Family" },
                new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 8, CategoryName = "VHS" }

            );
        }

    }
}
