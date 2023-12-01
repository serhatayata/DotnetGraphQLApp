using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetGraphQLApp.Entities.Context;

public class OwnerContextConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable("Owners", "graphQL");

        builder.HasKey(x => x.Id);
    }
}
