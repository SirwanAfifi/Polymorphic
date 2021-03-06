using Microsoft.EntityFrameworkCore;
using Polymorphic.Models;

namespace Polymorphic.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=polymorphic.db");
    }
}