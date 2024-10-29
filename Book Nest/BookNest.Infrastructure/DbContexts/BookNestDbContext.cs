using BookNest.Domain.Entities;
using BookNest.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.DbContexts
{
    public class BookNestDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
    
        public BookNestDbContext(DbContextOptions<BookNestDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfigurations());
            modelBuilder.ApplyConfiguration(new BookConfigurations());
            modelBuilder.ApplyConfiguration(new BranchConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
            modelBuilder.ApplyConfiguration(new RatingConfigurations());
            modelBuilder.ApplyConfiguration(new ReservationConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}