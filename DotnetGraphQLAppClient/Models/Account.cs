namespace DotnetGraphQLAppClient.Models;

public class Account
{
    public Guid Id { get; set; }
    public TypeOfAccount Type { get; set; }
    public string Description { get; set; }
    public Guid OwnerId { get; set; }
    public virtual Owner Owner { get; set; }
}
