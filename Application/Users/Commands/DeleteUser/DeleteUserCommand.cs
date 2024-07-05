using Application.Abstractions.Messaging;
using MediatR;

namespace Application.Users.Commands.DeleteUser
{
    public sealed record DeleteUserCommand(int UserId) : ICommand<Unit>;
}
