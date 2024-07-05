using Application.Abstractions.Messaging;
using Contracts.Entities;
using Contracts.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    internal sealed class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, Unit>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateUserCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            _repositoryManager.UserRepository.Update(user);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
