using DotnetGraphQLApp.Contracts;
using DotnetGraphQLApp.Entities;
using DotnetGraphQLApp.Entities.Context;

namespace DotnetGraphQLApp.Repository;

public class OwnerRepository : IOwnerRepository
{
    private readonly ApplicationContext _context;
    public OwnerRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Owner> GetAll() => _context.Owners.ToList();
}
