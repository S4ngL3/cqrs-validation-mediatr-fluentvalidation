using Application.Abstractions.Messaging;
using Contracts.Dtos.Users;
using Contracts.Entities;
using Contracts.Repositories;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserDto>
    {
        private readonly IRepositoryManager _repositoryManager;

        public CreateUserCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        async Task<UserDto> IRequestHandler<CreateUserCommand, UserDto>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _repositoryManager.UserRepository.Insert(user);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return user.Adapt<UserDto>();
        }
    }
}