using DotnetGraphQLApp.Contracts;
using DotnetGraphQLApp.Entities;
using DotnetGraphQLApp.GraphQLTypes;
using GraphQL;
using GraphQL.Types;

namespace DotnetGraphQLApp.GraphQL.GraphQLQueries;

public class AppMutation : ObjectGraphType
{
    public AppMutation(IOwnerRepository ownerRepository)
    {
        Field<OwnerType>("createOwner")
            .Arguments(new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" })
            .Resolve(context =>
            {
                var owner = context.GetArgument<Owner>("owner");
                var result = ownerRepository.Create(owner);
                return result;
            });

        Field<OwnerType>("updateOwner")
            .Arguments(
                new QueryArgument<NonNullGraphType<OwnerInputType>> { Name = "owner" },
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" })
            .Resolve(context =>
            {
                var owner = context.GetArgument<Owner>("owner");
                var ownerId = context.GetArgument<Guid>("ownerId");

                var currentOrder = ownerRepository.GetById(ownerId);
                if (currentOrder == null)
                {
                    context.Errors.Add(new ExecutionError("Couldn't find owner in db"));
                    return null;
                }

                return ownerRepository.Update(currentOrder, owner);
            });

        Field<StringGraphType>("deleteOwner")
            .Arguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ownerId" })
            .Resolve(context =>
            {
                var ownerId = context.GetArgument<Guid>("ownerId");
                var owner = ownerRepository.GetById(ownerId);

                if (owner == null)
                {
                    context.Errors.Add(new ExecutionError("Couldn't find owner in db"));
                    return null;
                }

                ownerRepository.Delete(owner);
                return $"ID : {ownerId} has been deleted";
            });
    }
}
