using Application.Abstractions.Messaging;
using Application.Logging.Commands;
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
        private readonly IMediator _mediator;
        private readonly IRepositoryManager _repositoryManager;

        public CreateUserCommandHandler(IMediator mediator, IRepositoryManager repositoryManager)
        {
            _mediator = mediator;
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

            await _mediator.Publish(new UserCreatedNotification() { User = user }, cancellationToken);

            return user.Adapt<UserDto>();
        }
    }
}