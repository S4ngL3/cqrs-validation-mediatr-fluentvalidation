using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.Contracts.Users;
using Contracts.Dtos.Users;
using Contracts.Entities;
using Contracts.Repositories;
using Mapster;
using Services;

namespace Application.Users.Commands.CreateUser
{
    internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserDto>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IRepositoryManager _repositoryManager;

        public CreateUserCommandHandler(IServiceManager serviceManager, IRepositoryManager repositoryManager)
        {
            _serviceManager = serviceManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userForCreateDto = request.Adapt<UserForCreateDto>();

            return await _serviceManager.UserService.CreateUserAsync(userForCreateDto, cancellationToken);
        }
    }
}