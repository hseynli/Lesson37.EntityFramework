using Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


class ContextApp : DbContext
{
    public DbSet<Phone> Phones { get; set; }

    public ContextApp()
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.ConnectionString);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Tablet>();
    //}

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Ignore<Company>();
    //}
}

public class Phone
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    // Naviqation property
    public Company Manufacturer { get; set; }
}

//[NotMapped]
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class Tablet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}