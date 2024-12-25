using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
        }
        public DbSet<Category>Categories { get; set; }

    }
}
