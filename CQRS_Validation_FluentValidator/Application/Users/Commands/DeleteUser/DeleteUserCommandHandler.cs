using Application.Abstractions.Messaging;
using MediatR;
using Services;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.DeleteUser
{
    internal class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, Unit>
    {
        private readonly IServiceManager _serviceManager;

        public DeleteUserCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _serviceManager.UserService.DeleteAsync(request.UserId, cancellationToken);

            return Unit.Value;
        }
    }
}