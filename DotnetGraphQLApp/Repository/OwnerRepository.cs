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

    public Owner Create(Owner owner)
    {
        owner.Id = Guid.NewGuid();
        _context.Add(owner);
        _context.SaveChanges();
        return owner;
    }

    public Owner Update(Owner currentOrder, Owner owner)
    {
        currentOrder.Name = owner.Name;
        currentOrder.Address = owner.Address;
        _context.SaveChanges();
        return currentOrder;
    }

    public void Delete(Owner owner)
    {
        _context.Remove(owner);
        _context.SaveChanges();
    }

    public IEnumerable<Owner> GetAll() => _context.Owners.ToList();

    public Owner? GetById(Guid id) => _context.Owners.FirstOrDefault(o => o.Id.Equals(id));
}
