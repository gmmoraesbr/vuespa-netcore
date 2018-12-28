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
            //modelBuilder.Ignore<User>();
            //modelBuilder.Ignore<Figure>();

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
           .Property<int>("FigureId");

            modelBuilder.Entity<FigureUser>()
                .HasOne(e => e.Figure)
                .WithMany(c => c.FigureUser)
                .HasForeignKey(p => p.FigureId);
        }

    }
}
