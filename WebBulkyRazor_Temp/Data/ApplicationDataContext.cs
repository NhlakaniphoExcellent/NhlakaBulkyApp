using Microsoft.EntityFrameworkCore;
using NhlakaBulkyWebApp.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace WebBulkyRazor_Temp.Data
{
    public class ApplicationRazorDataContext : DbContext
    {
        public ApplicationRazorDataContext(DbContextOptions<ApplicationRazorDataContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adding data to MS sql table using modelbuilder entity framework
            modelBuilder.Entity<Category>().HasData(

                new Category { ID = 1, Name = "Romance", DisplayOrder = 1 },
                new Category { ID = 2, Name = "Horror", DisplayOrder = 2 },
                new Category { ID = 3, Name = "Action", DisplayOrder = 3 },
                new Category { ID = 4, Name = "Kasi", DisplayOrder = 4 }

            );
        }
    }
}
