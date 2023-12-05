using GraphQL.Types;

namespace DotnetGraphQLApp.GraphQLTypes;

public class OwnerInputType : InputObjectGraphType
{
    public OwnerInputType()
    {
        Name = "ownerInput";
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<NonNullGraphType<StringGraphType>>("address");
    }
}
