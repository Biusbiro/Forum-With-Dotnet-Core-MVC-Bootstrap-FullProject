using Microsoft.EntityFrameworkCore;
using Forum_API_BackEnd.Models;

namespace Forum_API_BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cathegory> Cathegories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Subcathegory> Subcathegories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
    }
}