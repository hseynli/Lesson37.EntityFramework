using Library;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

class AppContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public AppContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(b => b.Name).IsRequired();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.ConnectionString);
    }
}

public class User
{
    public int Id { get; set; }
    //[Required]
    public string Name { get; set; }
}