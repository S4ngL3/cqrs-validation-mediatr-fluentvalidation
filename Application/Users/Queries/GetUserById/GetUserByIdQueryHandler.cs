using Application.Abstractions.Messaging;
using Contracts.Dtos.Users;
using Contracts.Exceptions;
using Contracts.Repositories;
using Mapster;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserById
{
    internal sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetUserByIdQueryHandler(IRepositoryManager serviceManager) => _repositoryManager = serviceManager;

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repositoryManager.UserRepository.GetByIdAsync(request.UserId, cancellationToken);

            if (user is null)
            {
                throw new UserNotFoundException(request.UserId);
            }

            return user.Adapt<UserDto>();
        }
    }
}