using DotnetGraphQLApp.Contracts;
using DotnetGraphQLApp.Entities;
using DotnetGraphQLApp.Entities.Context;

namespace DotnetGraphQLApp.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationContext _context;
    public AccountRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Account> GetAll() => _context.Accounts.ToList();
}
