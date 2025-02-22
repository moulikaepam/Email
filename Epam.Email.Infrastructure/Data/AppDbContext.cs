using Microsoft.EntityFrameworkCore;
using Epam.Email.Domain.Entities;

namespace Epam.Email.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Domain.Entities.Email> Emails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Email>()
                .HasIndex(e => e.EmailAddress)
                .IsUnique(); // Ensure email addresses are unique
        }
    }
}
