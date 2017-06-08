using Microsoft.EntityFrameworkCore;

namespace toss2.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options) { }
    }
}