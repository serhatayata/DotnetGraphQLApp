using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetGraphQLApp.Entities.Context;

public class AccountContextConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts", "graphQL");

        builder.HasKey(a => a.Id);

        builder.HasOne(b => b.Owner)
               .WithMany(b => b.Accounts)
               .HasForeignKey(b => b.OwnerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
