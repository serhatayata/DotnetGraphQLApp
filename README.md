## GraphQL .NET 8 implementation

In this project, we use some GraphQL libraries you can see below;

- GraphQL 
- GraphQL.DataLoader
- GraphQL.Server.Transports.AspNetCore
- GraphQL.NewtonsoftJson
- GraphQL.Server.Ui.Playground
- GraphQL.SystemTextJson

### GraphQL query or mutations

Some of the queries or mutations need query variables

```
{
  "ownerId": "8E5B7DC0-5A73-9729-3EC3-E065F410C66D",
  "showName" : true
}
```

### Queries

- Simple query
```
{
  owners {
    id
    name
    address
    accounts {
      id
      description
    }
  }
}
```

- Aliases
```
{
  first:owner(ownerId: "8E5B7DC0-5A73-9729-3EC3-E065F410C66D")
  {
    id
    firstName:name
    address
  },
  second:owner(ownerId: "0FC73BFC-83C9-69E7-9BC1-96111495C97B") 
  {
    id
    firstName: name
    address
  }
}
```

- Fragment
```
{
   first: owners {
     ...ownerFields
   }
   second: owner(ownerId: "1644f451-cc2b-41dd-fb6a-2481f8e0d1ac") {
     ...ownerFields
   }
}

fragment ownerFields on OwnerType {
  id
  name
  address
  accounts {
    id
    type
  }
}
```

- Named query
```
query ownerQuery($ownerID: ID!, $showName: Boolean!){
  owner(ownerId: $ownerID){
    id
    name @include (if: $showName)
    address
    accounts {
      id
      type
    }
  }
}

query ownersQuery {
  owners {
    id
    name
    address
    accounts {
      id
      type
      description        
    }
  }
}
```

### Mutation

- Create
```
mutation($owner: ownerInput!){
  createOwner(owner: $owner){
    id,
    name,
    address
  }
}
```

- Update
```
mutation($owner: ownerInput!, $ownerId: ID!){
  updateOwner(owner: $owner, ownerId: $ownerId)
  {
    id,
    name,
    address
  }
}
```

- Delete
```
mutation($ownerId: ID!)
{
  deleteOwner(ownerId: $ownerId)
}
```
