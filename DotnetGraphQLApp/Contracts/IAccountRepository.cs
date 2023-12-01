using DotnetGraphQLApp.Entities;

namespace DotnetGraphQLApp.Contracts;

public interface IAccountRepository
{
    IEnumerable<Account> GetAll();
}