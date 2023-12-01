using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DotnetGraphQLApp.Entities.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OwnerContextConfiguration());
        modelBuilder.ApplyConfiguration(new AccountContextConfiguration());
    }

    public DbSet<Owner> Owners { get; set; }
    public DbSet<Account> Accounts { get; set; }
}
