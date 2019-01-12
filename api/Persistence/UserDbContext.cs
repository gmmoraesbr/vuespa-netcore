using Microsoft.EntityFrameworkCore;
using Model;

namespace Persistence
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(128);

            modelBuilder.Entity<User>()
                .Property(p => p.Email)
                .IsConcurrencyToken()
                .IsRequired()
                .HasMaxLength(128);

            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(64);

            modelBuilder.Entity<User>()
                .HasKey(c => c.UserId);
            
            modelBuilder.Ignore<FigureUser>();
        }
    }
}
