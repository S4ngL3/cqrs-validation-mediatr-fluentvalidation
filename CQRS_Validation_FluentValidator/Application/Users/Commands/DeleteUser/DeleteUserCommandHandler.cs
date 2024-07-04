using Application.Abstractions.Messaging;
using Contracts.Entities;
using Contracts.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.DeleteUser
{
    internal class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteUserCommandHandler(IRepositoryManager serviceManager)
        {
            _repositoryManager = serviceManager;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = request.UserId
            };

            _repositoryManager.UserRepository.Delete(user);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}