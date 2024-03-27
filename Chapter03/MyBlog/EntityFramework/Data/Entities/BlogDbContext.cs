using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

public class BlogDbContext : DbContext
{
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=BlogDb;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define the many-to-many relationship between BlogPost and Tag
        modelBuilder.Entity<BlogPost>()
            .HasMany(b => b.Tags)
            .WithMany(t => t.BlogPosts)
            .UsingEntity(j => j.ToTable("BlogPostTags")); // Join table for many-to-many

        // Other model configurations can be placed here
    }
}
