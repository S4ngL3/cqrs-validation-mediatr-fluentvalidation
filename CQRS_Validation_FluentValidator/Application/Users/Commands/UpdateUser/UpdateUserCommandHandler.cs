using Application.Abstractions.Messaging;
using Contracts.Dtos.Users;
using Mapster;
using MediatR;
using Services;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    internal sealed class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, Unit>
    {
        private readonly IServiceManager _serviceManager;

        public UpdateUserCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userForUpdateDto = request.Adapt<UserForUpdateDto>();

            await _serviceManager.UserService.UpdateUserAsync(request.UserId, userForUpdateDto, cancellationToken);


            return Unit.Value;
        }
    }
}
