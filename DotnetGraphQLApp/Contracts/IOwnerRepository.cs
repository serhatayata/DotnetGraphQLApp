﻿using DotnetGraphQLApp.Entities;

namespace DotnetGraphQLApp.Contracts;

public interface IOwnerRepository
{
    IEnumerable<Owner> GetAll();
    Owner GetById(Guid id);
}
