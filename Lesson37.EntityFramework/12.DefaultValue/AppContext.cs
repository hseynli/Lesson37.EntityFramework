using Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

class AppContext : DbContext
{

    public DbSet<User> Users { get; set; }

    public AppContext()
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(u => u.Age).HasDefaultValue(18);

        //modelBuilder.Entity<User>()
        //    .Property(u => u.CreatedAt)
        //    .HasDefaultValueSql("DATETIME('now')");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.ConnectionString);
    }
}
public class User
{
    public int Id { get; set; }
    //[DefaultValue(18)]
    public string? Name { get; set; }
    public int Age { get; set; }
    public DateTime CreatedAt { get; set; }
}