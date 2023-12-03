using DotnetGraphQLApp.Contracts;
using DotnetGraphQLApp.Entities;
using DotnetGraphQLApp.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace DotnetGraphQLApp.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationContext _context;
    public AccountRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Account> GetAll() => _context.Accounts.ToList();

    public IEnumerable<Account> GetAllAcountsPerOwner(Guid ownerId) => 
            _context.Accounts.Where(a => a.OwnerId.Equals(ownerId)).ToList();

    public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
    {
        var accounts = await _context.Accounts
                             .Where(a => ownerIds.Contains(a.OwnerId))
                             .ToListAsync();

        return accounts.ToLookup(x => x.OwnerId);
    }
}
