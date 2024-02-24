using Microsoft.EntityFrameworkCore;
using MissionSixAssignment.Models;  


namespace MissionSixAssignment.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) //constructor
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
