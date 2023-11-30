using DotnetGraphQLApp.Contracts;
using DotnetGraphQLApp.Entities.Context;

namespace DotnetGraphQLApp.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationContext _context;
    public AccountRepository(ApplicationContext context)
    {
        _context = context;
    }
}
