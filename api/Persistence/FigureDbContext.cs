using Microsoft.EntityFrameworkCore;
using Model;

namespace Persistence
{
    public class FigureDbContext : DbContext
    {
        public DbSet<Figure> Figure { get; set; }

        public FigureDbContext(DbContextOptions<FigureDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Figure>()
                .HasKey(c => c.FigureId);

            modelBuilder.Entity<Figure>()
                .Property<int>("UserId");

            modelBuilder.Entity<Figure>()
                .HasOne(e => e.User)
                .WithMany(c => c.Figure)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Ignore<FigureUser>();
        }
    }
}
