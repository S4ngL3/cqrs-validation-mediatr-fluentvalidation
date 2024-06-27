using Application.Abstractions.Messaging;
using Application.Contracts.Users;
using Contracts.Dtos.Users;

namespace Application.Users.Commands.CreateUser
{
    public sealed record CreateUserCommand(string FirstName, string LastName) : ICommand<UserDto>;
}
