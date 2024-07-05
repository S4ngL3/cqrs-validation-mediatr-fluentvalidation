using Application.Abstractions.Messaging;
using Contracts.Dtos.Users;

namespace Application.Users.Queries.GetUserById
{
    public sealed record GetUserByIdQuery(int UserId) : IQuery<UserDto>;
}
