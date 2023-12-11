using Demo.EfCore8.Dal;
using Microsoft.EntityFrameworkCore;

namespace Demo.EfCore8;

public class TestContext : DbContext
{
    public DbSet<Party> Parties { get; set; }
    
    public TestContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Data Source=.;Initial Catalog=Net8Demo;Integrated Security=True;Trust server certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}