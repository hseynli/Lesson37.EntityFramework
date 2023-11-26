using Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        modelBuilder.Entity<User>().Property(u => u.Name).HasColumnType("varchar(200)");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.ConnectionString);
    }
}
public class User
{
    public int Id { get; set; }
    //[Column(TypeName = "varchar(200)")]
    public string Name { get; set; }
}