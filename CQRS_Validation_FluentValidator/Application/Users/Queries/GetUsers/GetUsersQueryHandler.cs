using Application.Abstractions.Messaging;
using Contracts.Dtos.Users;
using Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsers
{
    internal sealed class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IServiceManager _serviceManager;

        public GetUsersQueryHandler(IServiceManager serviceManager) => _serviceManager = serviceManager;

        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _serviceManager.UserService.GetAllAsync(cancellationToken);

            return users;
        }
    }
}