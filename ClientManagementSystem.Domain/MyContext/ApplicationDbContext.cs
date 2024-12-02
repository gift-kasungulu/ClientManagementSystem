using ClientManagementSystem.Data;
using ClientManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementSystem.MyContext
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base (options)
        {
                
        } 

        public DbSet<Client> Clients { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Subscription> subscriptions { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Collateral> Collaterals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(c => c.ClientId)
                .ValueGeneratedOnAdd();

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
