using DotnetGraphQLApp.Contracts;
using DotnetGraphQLApp.GraphQLTypes;
using GraphQL;
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

        Field<OwnerType>(name: "owner")
            .Description("Owner type description")
            .Arguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" })
            .Resolve(context =>
            {
                Guid id;
                if (!Guid.TryParse(context.GetArgument<string>("ownerId"), out id))
                {
                    context.Errors.Add(new ExecutionError("Wrong value for guid"));
                    return null;
                }

                return ownerRepository.GetById(id);
            });

        Field<ListGraphType<AccountType>>(name: "accounts")
            .Description("Account type description")
            .Resolve(context => accountRepository.GetAll());
    }
}
