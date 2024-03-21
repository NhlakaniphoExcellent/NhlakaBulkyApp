using Microsoft.EntityFrameworkCore;
using NhlakaBulkyWebApp.Models;

namespace NhlakaBulkyWebApp.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
