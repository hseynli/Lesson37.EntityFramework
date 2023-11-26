using Library;
using Microsoft.EntityFrameworkCore;

public class AppContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public AppContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(b => b.Name).HasMaxLength(50);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.ConnectionString);
    }
}
public class User
{
    public int Id { get; set; }
    //[MaxLength(50)]
    public string Name { get; set; }
}
