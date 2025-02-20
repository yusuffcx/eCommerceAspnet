using Microsoft.EntityFrameworkCore;
using Entity;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using eCommerce.Models;


namespace DataAccess.Contexts
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOne(e => e.category)
                .HasForeignKey(e => e.CategoryID);
//                .IsRequired();


            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
            new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
            new Category { Id = 3, Name = "History", DisplayOrder = 3 });

            modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1,ImageUrl="" ,CategoryID = 3, Title = "Kuyucaklı Yusuf", Description = "Güzel bir roman.", Author = "Sabahattin Ali", ISBN = "1212454564", ListPrice = 5, ListPrice2 = 4.75, ListPrice50 = 4.25, ListPrice100 = 4 },
            new Product { Id = 2, ImageUrl = "", CategoryID = 3, Title = "Beyoglu Rapsodisi", Description = "Polisiye Romanı.", Author = "Sabahattin Ali", ISBN = "3917854964", ListPrice = 6, ListPrice2 = 5.80, ListPrice50 = 5.50, ListPrice100 = 5.15 },
            new Product { Id = 3, ImageUrl = "", CategoryID = 2, Title = "Dil Belası", Description = "Genel kültür kitabı.", Author = "İmam Gazali", ISBN = "6915445564", ListPrice = 4.75, ListPrice2 = 4.50, ListPrice50 = 4.25, ListPrice100 = 4 });

            modelBuilder.Entity<Company>().HasData(
                new Company()
                {
                    Id = 1,
                    City = "Istanbul",
                    Name = "EnUygun",
                    PhoneNumber = "0212 555 47 86",
                    PostalCode = "34180",
                    StreetAddress = "Bakırköy",
                    State = "Türkiye"
                },

                 new Company()
                 {
                 Id = 2,
                 City = "Istanbul",
                 Name = "KitapEviCom",
                 PhoneNumber = "0212 145 66 56",
                 PostalCode = "34164",
                 StreetAddress = "Kartal",
                 State = "Türkiye"
                },

                 new Company()
                 {
                     Id = 3,
                     City = "Kocaeli",
                     Name = "OKitap",
                     PhoneNumber = "0262 254 96 32",
                     StreetAddress = "Gebze",
                     PostalCode = "41214",
                     State = "Türkiye"
                 });

        }
    }
}
