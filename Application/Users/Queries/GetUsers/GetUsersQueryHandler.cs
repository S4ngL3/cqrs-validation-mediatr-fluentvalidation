using Application.Abstractions.Messaging;
using Contracts.Dtos.Users;
using Contracts.Repositories;
using Mapster;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsers
{
    public sealed class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetUsersQueryHandler(IRepositoryManager serviceManager) => _repositoryManager = serviceManager;

        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var usersEntity = await _repositoryManager.UserRepository.GetAsync(cancellationToken);

            var usersDto = usersEntity.Adapt<List<UserDto>>();

            return usersDto;
        }
    }
}