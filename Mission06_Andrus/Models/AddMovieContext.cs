using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Andrus.Models
{
    // Database context for EF Core
    public class AddMovieContext : DbContext
    {
        // Constructor: sets up the database using options (like connection string)
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base(options)
        {
        }

        // Represents the Movies table in the database
        public DbSet<AddMovie> Movies { get; set; }

    }
}
