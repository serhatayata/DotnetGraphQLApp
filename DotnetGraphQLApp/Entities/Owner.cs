namespace DotnetGraphQLApp.Entities;

public class Owner
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public virtual ICollection<Account> Accounts { get; set; }
}
