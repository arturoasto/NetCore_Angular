using Microsoft.EntityFrameworkCore;
using NetCore_Angular.Models;

namespace NetCore_Angular.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>().ToTable("Properties");
        }
    }
}
