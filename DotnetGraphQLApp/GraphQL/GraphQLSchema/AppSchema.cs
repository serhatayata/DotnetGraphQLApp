using DotnetGraphQLApp.GraphQL.GraphQLQueries;
using GraphQL.Types;

namespace DotnetGraphQLApp.GraphQL.GraphQLSchema;

public class AppSchema : Schema
{
    public AppSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<AppQuery>();
        Mutation = provider.GetRequiredService<AppMutation>();
    }
}
