using D8M8.API.Models;
using Microsoft.EntityFrameworkCore;

namespace D8M8.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
    }
}