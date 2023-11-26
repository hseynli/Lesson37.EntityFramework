using Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

class AppContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public AppContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Config.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PhoneConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
    }
}

public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.ToTable("Mobiles").HasKey(p => p.Ident);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
    }
}

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Manufacturers").Property(c => c.Name).IsRequired().HasMaxLength(30);
    }
}

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Phone
{
    public int Ident { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int CompanyId { get; set; }
}