using Microsoft.EntityFrameworkCore;
using Sales.Shared.Entites;

namespace Sales.API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<Categoria>().HasIndex(c => c.Descripcion).IsUnique();
    }

    /// <summary>
    /// Garantizar que EF use la cadena de conexión que acaba de agregar.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

        var connectionString = configuration.GetConnectionString("CnSqlServer");

        optionsBuilder.UseSqlServer(connectionString);
    }
}