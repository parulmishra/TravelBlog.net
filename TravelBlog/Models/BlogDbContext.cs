using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TravelBlog.Models
{
    public class BlogDbContext: DbContext
    {
        public BlogDbContext()
        { }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<People> Peoples { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=3306;database=TravelBlog;uid=parul;pwd=parul;");
        }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
