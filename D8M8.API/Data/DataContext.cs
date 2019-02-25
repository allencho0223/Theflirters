using Microsoft.EntityFrameworkCore;
using TheFlirters.API.Models;

namespace TheFlirters.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Value> Values { get; set; }
    }
}