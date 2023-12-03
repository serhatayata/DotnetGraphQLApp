using DotnetGraphQLApp.Contracts;
using DotnetGraphQLApp.Entities.Context;
using DotnetGraphQLApp.GraphQL.GraphQLSchema;
using DotnetGraphQLApp.Repository;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var environment = builder.Environment;

builder.Services.AddControllers()
                .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<ApplicationContext>(opt =>
    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddScoped<ISchema, AppSchema>();

builder.Services.AddGraphQL(builder => 
            builder.AddSystemTextJson()
           .AddNewtonsoftJson()
           .AddSchema<AppSchema>()
           .AddGraphTypes(typeof(AppSchema).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<KestrelServerOptions>(opt =>
{
    opt.AllowSynchronousIO = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseGraphQL<ISchema>();
app.UseGraphQLGraphiQL();
app.UseGraphQLAltair();
app.UseGraphQLPlayground(options: new GraphQL.Server.Ui.Playground.PlaygroundOptions());

app.MapControllers();

app.Run();
