using Microsoft.EntityFrameworkCore;
using VideoGameList.Models;

namespace VideoGameList.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Games> Games{ get; set; }
    }
}
