using DatumIT_Blog.Infraestructure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DatumIT_Blog.Infraestructure.Data.Context;

/// <summary>
/// Database Context.
/// </summary>
public sealed class DatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Database Context.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="configuration"></param>
    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Users.
    /// </summary>
    public DbSet<Users>? Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = _configuration["ConnectionStrings:DatabaseConnection"]?.ToString();
        optionsBuilder.UseSqlServer(connection, ef => ef.MigrationsAssembly(_configuration["PresentationProjectName"]));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Users>().HasData(new List<Users>()
        {
            new () { Id = 1, Name = "Mary", },
            new () { Id = 2, Name = "Jhon", }
        });
    }
}