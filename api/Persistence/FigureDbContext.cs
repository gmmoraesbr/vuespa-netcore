using Microsoft.EntityFrameworkCore;
using Model;

namespace Persistence
{
    public class FigureDbContext : DbContext
    {
        public DbSet<Figure> Figure { get; set; }

        public FigureDbContext(DbContextOptions<FigureDbContext> options) : base(options) {}

    }
}
