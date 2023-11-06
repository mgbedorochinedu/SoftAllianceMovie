using Microsoft.EntityFrameworkCore;
using SoftAllianceMovie.Models;

namespace SoftAllianceMovie.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}
