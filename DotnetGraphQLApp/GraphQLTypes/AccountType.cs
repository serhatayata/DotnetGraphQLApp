using DotnetGraphQLApp.Entities;
using GraphQL.Types;

namespace DotnetGraphQLApp.GraphQLTypes;

public class AccountType : ObjectGraphType<Account>
{
    public AccountType()
    {
        Field(o => o.Id, type: typeof(IdGraphType)).Description("Id property from the account object");
        Field<AccountTypeEnumType>("type").Resolve(context => context.Source.Type);
        Field(o => o.Description).Description("Description property from the account project");
        Field(o => o.OwnerId).Description("OwnerId property from the account project");
    }
}
