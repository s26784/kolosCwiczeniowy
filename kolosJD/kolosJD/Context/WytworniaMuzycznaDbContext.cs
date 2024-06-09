using kolosJD.Configs;
using kolosJD.Entities;
using Microsoft.EntityFrameworkCore;

namespace kolosJD.Context;

public class WytworniaMuzycznaDbContext : DbContext
{
    public DbSet<Muzyk> Muzycy { get; set; }
    public DbSet<WykonawcaUtworu> WykonawcaUtworus { get; set; }
    public DbSet<Utwor> Utwory { get; set; }
    public DbSet<Album> Albumy { get; set; }
    public DbSet<Wytwornia> Wytwornie { get; set;}

    public WytworniaMuzycznaDbContext()
    {
        
    }

    public WytworniaMuzycznaDbContext(DbContextOptions<WytworniaMuzycznaDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MuzykEfConfiguration).Assembly);
    }
    
}

 