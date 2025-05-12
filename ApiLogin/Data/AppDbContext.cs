using ApiLogin.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLogin.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        DbSet<User> User { get; set; }
    }
}
