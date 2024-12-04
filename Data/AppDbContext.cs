using Microsoft.EntityFrameworkCore;
using LoginSystemApp.Models;
 
namespace LoginSystemApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
 
        public DbSet<User> Users { get; set; }
    }
}
