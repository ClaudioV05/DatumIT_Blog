using DatumIT_Blog.Infraestructure.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatumIT_Blog.Infraestructure.Data.Context;

/// <summary>
/// Database Context.
/// </summary>
/// <remarks>This class cannot be inherited.</remarks>
public sealed class DatabaseContext : IdentityDbContext
{
    /// <summary>
    /// Database Context.
    /// </summary>
    /// <param name="options"></param>
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    /// <summary>
    /// Blog.
    /// </summary>
    public DbSet<Blog>? Blogs { get; set; }

    /// <summary>
    /// Post.
    /// </summary>
    public DbSet<Post>? Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.ToTable("Blogs");

            entity.HasKey(e => e.BlogId);

            entity.Property(e => e.BlogId)
                  .HasColumnName("BlogId")
                  .ValueGeneratedOnAdd()
                  .UseIdentityColumn()
                  .IsRequired();

            entity.Property(e => e.Url)
                  .HasColumnName("Url")
                  .HasColumnType("nvarchar(255)")
                  .IsRequired();

            entity.HasMany(e => e.Posts)
                  .WithOne(p => p.Blog)
                  .HasForeignKey(fr => fr.BlogId)
                  .HasConstraintName("FK_POST_BLOG")
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Posts");

            entity.HasKey(e => e.PostId);

            entity.Property(e => e.PostId)
                  .HasColumnName("PostId")
                  .ValueGeneratedOnAdd()
                  .UseIdentityColumn()
                  .IsRequired();

            entity.Property(e => e.Title)
                  .HasColumnName("Title")
                  .HasColumnType("nvarchar(128)")
                  .IsRequired();

            entity.Property(e => e.Content)
                  .HasColumnName("Content")
                  .HasColumnType("nvarchar(1024)")
                  .IsRequired();

            entity.Property(e => e.CreatedDate)
                  .HasColumnName("CreatedDate")
                  .HasColumnType("datetime2")
                  .HasDefaultValueSql("GETDATE()")
                  .IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}