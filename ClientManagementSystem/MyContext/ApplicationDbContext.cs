using ClientManagementSystem.Data;
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
