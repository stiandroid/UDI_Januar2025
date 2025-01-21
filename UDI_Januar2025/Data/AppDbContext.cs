namespace UDI_Januar2025.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Person> Personer { get; set; }
    public DbSet<Sak> Saker { get; set; }
    public DbSet<Vedtak> Vedtak { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasKey(p => p.Personnummer);

        modelBuilder.Entity<Sak>()
            .HasKey(s => s.SakId);
    }
}
