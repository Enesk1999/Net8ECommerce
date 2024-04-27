using ETicaret.Model.Models;
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
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1 ,Name="Ayakkabı",DisplayOrder=1},
                new Category { Id = 2, Name="T-shirt",DisplayOrder=12, },
                new Category { Id = 3, Name = "SweatShirt", DisplayOrder = 2},
                new Category { Id = 4, Name = "Pantolon", DisplayOrder = 4},
                new Category { Id = 5, Name = "Eşofman", DisplayOrder = 5},
                new Category { Id = 6, Name = "Gömlek", DisplayOrder = 15}
                );
            modelBuilder.Entity<Product>().HasData(
  
                new Product
                {
                    Id = 1,
                    Title = "Kumaş Baggy Pantolon",
                    Author = "XM",
                    Description = "Tasarım Ön Gül Baskı Baggy Pantolon - Bej",
                    CategoryId = 4,
                    ISBN = "HG1133213",
                    ListPrice = 699.99,
                    Price = 599.99,
                    Price50 = 500.00,
                    Price100 = 450.99,
                    ImageUrl = "1"
                },
                new Product
                {
                    Id = 2,
                    Title = "Sweatshirt - Beyaz",
                    Author = "Zhara",
                    Description = "Kuş Detaylı Sweatshirt - Beyaz",
                    CategoryId = 3,
                    ISBN = "SW35335334",
                    ListPrice = 350.99,
                    Price = 325.99,
                    Price50 = 310.99,
                    Price100 = 300,
                    ImageUrl = "2"
                },
                 new Product
                 {
                     Id = 3,
                     Title = "Sırt Nakışlı Kısa Kol Gömlek - İndigo",
                     Author = "BHRR",
                     Description = "About Basic Sırt Nakışlı Kısa Kol Gömlek - İndigo",
                     CategoryId = 6,
                     ISBN = "HGGF35335334",
                     ListPrice = 550.99,
                     Price = 425.99,
                     Price50 = 410.99,
                     Price100 = 400,
                     ImageUrl = "2"
                 }


                );
         
            base.OnModelCreating(modelBuilder);
        }
    }

}
