using DotnetGraphQLApp.Entities;

namespace DotnetGraphQLApp.Contracts;

public interface IOwnerRepository
{
    IEnumerable<Owner> GetAll();
    Owner GetById(Guid id);
    Owner Create(Owner owner);
    Owner Update(Owner currentOrder, Owner owner);
    void Delete(Owner owner);
}
