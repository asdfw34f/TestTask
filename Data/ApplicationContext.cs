using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        { 
        Database.EnsureCreated();

            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders { get; set; }
        public DbSet<FoundersClients> FoundersClients {get;set;}
    }
}
