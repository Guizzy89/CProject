using CProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } 
        public DbSet<Repairer> Repairers { get; set; }
        public DbSet<Customer> Customers { get; set; } 
    }

}
