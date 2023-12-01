using DotnetGraphQLApp.Contracts;
using DotnetGraphQLApp.GraphQLTypes;
using GraphQL.Types;

namespace DotnetGraphQLApp.GraphQL.GraphQLQueries;

public class AppQuery : ObjectGraphType
{
    public AppQuery(
        IOwnerRepository ownerRepository,
        IAccountRepository accountRepository)
    {
        Name = "RootQuery";
        Description = "Root query description";

        Field<ListGraphType<OwnerType>>(name: "owners")
            .Description("Owner type description")
            .Resolve(context => ownerRepository.GetAll());

        Field<ListGraphType<AccountType>>(name: "accounts")
            .Description("Account type description")
            .Resolve(context => accountRepository.GetAll());
    }
}
