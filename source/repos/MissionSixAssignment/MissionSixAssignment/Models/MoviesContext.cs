using Microsoft.EntityFrameworkCore;

namespace MissionSixAssignment.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) //constructor
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
