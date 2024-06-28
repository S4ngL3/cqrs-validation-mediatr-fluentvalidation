using Application.Abstractions.Messaging;
using Contracts.Dtos.Users;
using Contracts.Exceptions;
using Mapster;
using Services;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserById
{
    internal sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IServiceManager _serviceManager;

        public GetUserByIdQueryHandler(IServiceManager serviceManager) => _serviceManager = serviceManager;

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _serviceManager.UserService.GetUserByIdAsync(request.UserId, cancellationToken);

            if (user is null)
            {
                throw new UserNotFoundException(request.UserId);
            }

            return user.Adapt<UserDto>();
        }
    }
}