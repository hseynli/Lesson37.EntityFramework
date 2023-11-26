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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Phone>().Ignore(b => b.CurrentRate);
    }

}
public class Phone
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    //[NotMapped]
    public int CurrentRate { get; set; }
}