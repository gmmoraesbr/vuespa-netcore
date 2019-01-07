using Microsoft.EntityFrameworkCore;
using Model;

namespace Persistence
{
    public class FigureUserDbContext : DbContext
    {
        public DbSet<FigureUser> FigureUser { get; set; }

        public FigureUserDbContext(DbContextOptions<FigureUserDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<FigureUser>()
                .Property<int>("UserOwnerId");

            modelBuilder.Entity<FigureUser>()
                .HasOne<User>(e => e.UserOwner)
                .WithMany(c => c.FigureUserOwner)
                .HasForeignKey(p => p.UserOwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<FigureUser>()
                .Property<int>("UserRequestId");

            modelBuilder.Entity<FigureUser>()
                .HasOne<User>(e => e.UserRequest)
                .WithMany(c => c.FigureUserRequest)
                .HasForeignKey(p => p.UserRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FigureUser>()
                .Property<int>("FigureOwnerId");

            modelBuilder.Entity<FigureUser>()
                .HasOne<Figure>(e => e.FigureOwner)
                .WithMany(c => c.FigureOwner)
                .HasForeignKey(p => p.FigureOwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FigureUser>()
                .Property<int>("FigureRequestId");

            modelBuilder.Entity<FigureUser>()
                .HasOne<Figure>(e => e.FigureRequest)
                .WithMany(c => c.FigureRequest)
                .HasForeignKey(p => p.FigureRequestId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
