using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data.Map;
using PersonalBlog.Models;

namespace PersonalBlog.Data
{
    public class PostsDbContext : DbContext
    {
        public PostsDbContext(DbContextOptions<PostsDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostsModel> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
        }
    }
}
