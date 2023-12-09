using DotnetGraphQLAppClient.Consumers;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddScoped<IGraphQLClient>(s => new GraphQLHttpClient(configuration["GraphQLURI"], new NewtonsoftJsonSerializer()));
builder.Services.AddScoped<OwnerConsumer>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
