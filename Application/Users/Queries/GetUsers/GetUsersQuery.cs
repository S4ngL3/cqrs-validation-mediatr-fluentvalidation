using Application.Abstractions.Messaging;
using Contracts.Dtos.Users;
using System.Collections.Generic;

namespace Application.Users.Queries.GetUsers
{
    public sealed record GetUsersQuery() : IQuery<IEnumerable<UserDto>>;
}
