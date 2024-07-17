using Application.Abstractions.Messaging;
using Application.Caching;
using Application.Constants;
using Contracts.Dtos.Users;
using Contracts.Repositories;
using Mapster;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsers
{
    public sealed class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IDistributedCache _cache;
        private static readonly SemaphoreSlim semaphore = new(1, 1);
        private const string usersCacheKey = Constant.CACHE_USER_LIST_KEY;

        public GetUsersQueryHandler(IRepositoryManager serviceManager, IDistributedCache cache)
        {
            _repositoryManager = serviceManager;
            _cache = cache;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            if (!_cache.TryGetValue(usersCacheKey, out IEnumerable<UserDto> usersDto))
            {
                try
                {
                    await semaphore.WaitAsync();
                    if (!_cache.TryGetValue(usersCacheKey, out usersDto))
                    {
                        var usersEntity = await _repositoryManager.UserRepository.GetAsync(cancellationToken);

                        usersDto = usersEntity.Adapt<List<UserDto>>();

                        var cacheEntryOptions = new DistributedCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600));

                        await _cache.SetAsync(usersCacheKey, usersDto, cacheEntryOptions);
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            }

            return usersDto;
        }
    }
}