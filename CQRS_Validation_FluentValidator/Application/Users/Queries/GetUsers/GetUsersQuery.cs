using System.Collections.Generic;
using Application.Abstractions.Messaging;
using Application.Contracts.Users;
using Contracts.Dtos.Users;

namespace Application.Users.Queries.GetUsers
{
    public sealed record GetUsersQuery() : IQuery<IEnumerable<UserDto>>;
}
