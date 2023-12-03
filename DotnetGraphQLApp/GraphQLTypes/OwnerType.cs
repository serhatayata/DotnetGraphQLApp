using DotnetGraphQLApp.Contracts;
using DotnetGraphQLApp.Entities;
using GraphQL.Types;

namespace DotnetGraphQLApp.GraphQLTypes;

public class OwnerType : ObjectGraphType<Owner>
{
    public OwnerType(IAccountRepository accountRepository)
    {
        Field(o => o.Id, type: typeof(IdGraphType)).Description("Id property from the owner object");
        Field(o => o.Name).Description("Name property from the owner project");
        Field(o => o.Address).Description("Address property from the owner project");
        Field<ListGraphType<AccountType>>("accounts").Description("All accounts for this owner")
                              .Resolve(context => accountRepository.GetAllAcountsPerOwner(context.Source.Id).ToList());
    }
}
