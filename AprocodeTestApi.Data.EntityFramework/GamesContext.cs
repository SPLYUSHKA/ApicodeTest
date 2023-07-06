using ApricodeTestApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AprocodeTestApi.Data.EntityFramework
{
    public class GamesContext : DbContext
    {
        public GamesContext(DbContextOptions options) : base(options) 
        { 

        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

    }
}