using ETicaret.Net8.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Net8.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Name="Deneme1",DisplayOrder=1},
                new Category { Id=2,Name="Deneme2",DisplayOrder=212},
                new Category { Id = 3, Name = "Deneme2", DisplayOrder = 23 }
                );
         
            base.OnModelCreating(modelBuilder);
        }
    }

}
