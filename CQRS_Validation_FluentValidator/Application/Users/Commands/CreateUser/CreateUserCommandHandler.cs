using Application.Abstractions.Messaging;
using Contracts.Dtos.Users;
using Mapster;
using Services;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserDto>
    {
        private readonly IServiceManager _serviceManager;

        public CreateUserCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userForCreateDto = request.Adapt<UserForCreateDto>();

            return await _serviceManager.UserService.CreateUserAsync(userForCreateDto, cancellationToken);
        }
    }
}